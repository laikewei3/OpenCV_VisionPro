from ast import Param
import time
from tkinter import messagebox
import PySimpleGUI as sg
import os.path
from PIL import Image, ImageTk
import cv2
from PyO3DHelperClass import PyO3DHelperClass
from MiDaS23D import MiDaS23D


class Params3D:
    inputType = ""
    images = dict()

menu_def = [
    ['Input',
        ['RGBD','Depth Map(MiDaS)',['Camera::MiDaSCam', 'Image::MiDaSImg']],
    ]    
]

image_viewer_column = [
    [sg.Text(size=(None, 1), key="-TOUT-", auto_size_text=True)],
    [sg.Image(key="-IMAGE-", background_color='white',size=(400,400))],
]

color_image_column = [
    [sg.Text("Color Image Folder")],
    [sg.In(size=(20, 1), enable_events=True, key="-COLOR_FOLDER-NAME")],
    [sg.FolderBrowse(enable_events=True, key="-COLOR_FOLDER-")],
    [
        sg.Listbox(
            values=[], enable_events=True, size=(20, 20), key="-COLOR_FOLDER-LIST"
        )
    ],
]

depth_image_column = [
    [sg.Text("Depth Image Folder")],
    [sg.In(size=(20, 1), enable_events=True, key="-DEPTH_FOLDER-NAME")],
    [sg.FolderBrowse(enable_events=True, key="-DEPTH_FOLDER-")],
    [
        sg.Listbox(
            values=[], enable_events=True, size=(20, 20), key="-DEPTH_FOLDER-LIST"
        )
    ],
]

#Ref: https://blog.csdn.net/io569417668/article/details/106533242
RGBDLayout = [
    [
        sg.Column(color_image_column),
        sg.VSeperator(),
        sg.Column(depth_image_column)
    ]
]

#Ref New Version: https://www.youtube.com/watch?v=m-juq6yOqPk
MiDaSLayout = [
    [sg.Text("Select Image")],
    [sg.In(size=(20, 1), enable_events=True, key="-MiDaS Input-Text")],
    [sg.FileBrowse(enable_events=True, key="-MiDaS Input-")]
]

layout = [
    [   
        [sg.Menu(menu_def)],
        [sg.Column(image_viewer_column),
         sg.VSeperator(),
         sg.Column(MiDaSLayout, key="--MiDasLayout--",visible=False),
         sg.Column(RGBDLayout, key="--RGBDLayout--",visible=False),
        ],
        [sg.Button("Generate Point Cloud",enable_events=True, key="-Generate Button-")]
    ]
]

# Create the window
window = sg.Window("3D in Python",layout)

params = Params3D()
# Create an event loop
while True:
    event, values = window.read()
    # End program if user closes window 
    if event == sg.WIN_CLOSED:
        break
    
    # check Input Type
    if event == "RGBD":
        window["--MiDasLayout--"].update(visible=False)
        window["--RGBDLayout--"].update(visible=True)
        params.inputType = "RGBD"
    elif event == "Camera::MiDaSCam":
        window["--MiDasLayout--"].update(visible=False)
        window["--RGBDLayout--"].update(visible=False)
        params.inputType = "MiDaS"
        midas = MiDaS23D()
        cap = cv2.VideoCapture(1)
        while True:
            output = midas._openCamera(cap,False)
            cv2.imshow("MiDaS Input",output)
            if cv2.waitKey(5) == ord('q'):#keyboard.is_pressed('q'):
                break
            
        cap.release()
        cv2.destroyAllWindows()
        params.images["MiDaS"] = output
        img_bytes = cv2.imencode('.ppm',output)[1].tobytes()
        window["-IMAGE-"].update(data = img_bytes)
    elif event == "Image::MiDaSImg":
        window["--MiDasLayout--"].update(visible=True)
        window["--RGBDLayout--"].update(visible=False)
        params.inputType = "MiDaS"
        midas = MiDaS23D()
    
    # Image Type
    if event == "-COLOR_FOLDER-" or event == "-DEPTH_FOLDER-":
        folder = values[event]
        window[event+"NAME"].update(folder)
        try:
            # Get list of files in folder
            file_list = os.listdir(folder)
            params.images.pop("MiDaS",None)
            params.images[event] = folder;
        except:
            file_list = []
        fnames = [
            f
            for f in file_list
            if os.path.isfile(os.path.join(folder, f))
            and f.lower().endswith((".png", ".gif",".jpg",".jpeg",".bmp"))
        ]
        window[event+"LIST"].update(fnames)
    elif event.endswith("FOLDER-LIST"):  # A file was chosen from the listbox
        try:
            filename = values[event[:-4]] +"/"+ values[event][0]
            window["-TOUT-"].update(filename)
            im = Image.open(filename)
            im = im.resize((400,400), resample=Image.BICUBIC)
            image = ImageTk.PhotoImage(image=im)
            window["-IMAGE-"].update(data = image)
        except:
            pass
    elif event == "-MiDaS Input-":
        file = values[event]
        window[event+"Text"].update(file)
        try:
            window["-TOUT-"].update(file)
            im = Image.open(file)
            im = im.resize((400,400), resample=Image.BICUBIC)
            image = ImageTk.PhotoImage(image=im)
            window["-IMAGE-"].update(data = image)
            params.images.pop("-COLOR_FOLDER-",None)
            params.images.pop("-DEPTH_FOLDER-",None)
            params.images["MiDaS"] = cv2.imread(file);
        except:
            file_list = []
    
    # Output
    if event == "-Generate Button-":
        if params.inputType == "":
            messagebox.showerror("No Input","No Input Selected. Please Choose the Input Menu Selection!") 
            continue
        elif params.inputType == "RGBD":
            if "-COLOR_FOLDER-" not in params.images:
                messagebox.showerror("Input Error","No color image!") 
                continue
            if "-DEPTH_FOLDER-" not in params.images:
                messagebox.showerror("Input Error","No depth image!") 
                continue
            pcds = PyO3DHelperClass.loopFolderToGenerate(params.images["-COLOR_FOLDER-"],params.images["-DEPTH_FOLDER-"],max_Image_count=60)
            pcds_align = PyO3DHelperClass.alignMultiplePcd(pcds)
            #PyO3DHelperClass.showPointCloud3D(pcds_align)
            PyO3DHelperClass.surfaceReconstruction(pcds_align,showOutput=True)
        else:
            if "MiDaS" not in params.images:
                messagebox.showerror("Input Error","No image Capture/ Selected!") 
                continue
            output, output_points, output_colors = midas._applyMiDaS23D(params.images["MiDaS"])
            img_bytes = cv2.imencode('.ppm',output)[1].tobytes()
            window["-IMAGE-"].update(data = img_bytes)
            midas._savePlyFile(output_points, output_colors)
            #PyO3DHelperClass.downsampling(PyO3DHelperClass.readPointCloud3D("C:/Users/T0571/source/repos/OpenCV_Vision_Pro/OpenCV_Vision_Pro/pointCloudDeepLearning.ply"),showOutput=True)
            
window.close()

