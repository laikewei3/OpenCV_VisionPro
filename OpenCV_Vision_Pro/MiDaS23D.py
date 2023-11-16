from tkinter import messagebox
import torch
import cv2
import numpy as np
import matplotlib.pyplot as plt 
from PyO3DHelperClass import PyO3DHelperClass

class MiDaS23D:
    '''
    model_type = "DPT_Large"     # MiDaS v3 - Large     (highest accuracy, slowest inference speed)
    model_type = "DPT_Hybrid"   # MiDaS v3 - Hybrid    (medium accuracy, medium inference speed)
    model_type = "MiDaS_small"  # MiDaS v2.1 - Small   (lowest accuracy, highest inference speed)
    '''
    def __init__(self, model_type = "DPT_Large"):
        # Q matrix - Camera parameters - Can also be found using stereoRectify
        self.Q = np.array(([1.0, 0.0, 0.0, -160.0],
                      [0.0, 1.0, 0.0, -120.0],
                      [0.0, 0.0, 0.0, 350.0],
                      [0.0, 0.0, 1.0/90.0, 0.0]),dtype=np.float32)
        self.midas = torch.hub.load("intel-isl/MiDaS", model_type)
        self.device = torch.device("cuda") if torch.cuda.is_available() else torch.device("cpu")
        self.midas.to(self.device)
        self.midas.eval()

        self.__midas_transforms = torch.hub.load("intel-isl/MiDaS", "transforms")

        if model_type == "DPT_Large" or model_type == "DPT_Hybrid":
            self.transform = self.__midas_transforms.dpt_transform
        else:
            self.transform = self.__midas_transforms.small_transform
            
    #Function to create point cloud file     
    def _savePlyFile(self, vertices, colors, filename="pointCloudDeepLearning.ply"):
        try:
            colors = colors.reshape(-1,3)
            vertices = np.hstack([vertices.reshape(-1,3),colors])
            
            ply_header = '''ply
		        format ascii 1.0
		        element vertex %(vert_num)d
		        property float x
		        property float y
		        property float z
		        property uchar red
		        property uchar green
		        property uchar blue
		        end_header
		        '''
            with open(filename, 'w') as f:
                f.write(ply_header %dict(vert_num=len(vertices)))
                np.savetxt(f,vertices,'%f %f %f %d %d %d')  
            messagebox.showinfo("Save", "Save Successfully to: \n"+filename)
        except:
            messagebox.showwarning("Save", "Failed to save to: \n"+filename)
        
                 
    def _openCamera(self, cap, showMiDaS = True):
        success, img = cap.read()
        if showMiDaS:
            img = self._applyMiDaS23D(img)
        return img
            
    def _applyMiDaS23D(self, img):
        img = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)
        input_batch = self.transform(img).to(self.device)

        with torch.no_grad():
            prediction = self.midas(input_batch)

            prediction = torch.nn.functional.interpolate(
                prediction.unsqueeze(1),
                size=img.shape[:2],
                mode="bicubic",
                align_corners=False,
            ).squeeze()

        output = prediction.cpu().numpy()
        output = cv2.normalize(output, None, 0, 1, norm_type=cv2.NORM_MINMAX,dtype=cv2.CV_32F)
    
        points_3d = cv2.reprojectImageTo3D(output,self.Q,handleMissingValues=True)
        mask_map = output > 0.4
    
        output_points = points_3d[mask_map]
        output_colors = img[mask_map]
        
        output = (output*255).astype(np.uint8)
        output = cv2.applyColorMap(output, cv2.COLORMAP_MAGMA)   
            
        return output, output_points, output_colors
    
"""
#Test Code
cap = cv2.VideoCapture(1)
midas = MiDaS23D()
while True:
    output, output_points, output_colors = midas._openCamera(cap)
    cv2.imshow("Depth Map",output)
    if cv2.waitKey(5) == ord('q'):
        break
midas._savePlyFile(output_points, output_colors)
PyO3DHelperClass.downsampling(PyO3DHelperClass.readPointCloud3D("C:/Users/T0571/source/repos/OpenCV_Vision_Pro/OpenCV_Vision_Pro/pointCloudDeepLearning.ply"),showOutput=True)
"""