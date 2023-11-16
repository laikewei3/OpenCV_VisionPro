import cv2
import numpy as np

images = []
images.append(cv2.imread("C:/Users/T0571/Downloads/HDR TUTO/1.JPG"))
images.append(cv2.imread("C:/Users/T0571/Downloads/HDR TUTO/2.JPG"))
images.append(cv2.imread("C:/Users/T0571/Downloads/HDR TUTO/3.JPG"))
images.append(cv2.imread("C:/Users/T0571/Downloads/HDR TUTO/4.JPG"))

times = np.array([ 1/30.0, 0.25, 2.5, 15.0 ], dtype=np.float32)

# Align input images
#alignMTB = cv2.createAlignMTB()
#alignMTB.process(images, images)

# Obtain Camera Response Function (CRF)
calibrateDebevec = cv2.createCalibrateDebevec()
responseDebevec = calibrateDebevec.process(images, times)

# Merge images into an HDR linear image
mergeDebevec = cv2.createMergeDebevec()
hdrDebevec = mergeDebevec.process(images, times, responseDebevec)
cv2.imshow("HDR", hdrDebevec)



# Tonemap using Drago's method to obtain 24-bit color image
tonemapDrago = cv2.createTonemapDrago(1.0, 0.7)
ldrDrago = tonemapDrago.process(hdrDebevec)
ldrDrago = 3 * ldrDrago
cv2.imshow("ldr",ldrDrago)
cv2.waitKey(10000)
"""
#Ask the user for url input
#url = "https://www.youtube.com/watch?v=_QoGyX2kgxc"

#video = pafy.new(url)
#best = video.getbest(preftype="mp4")

#cap = cv2.VideoCapture(best.url)

#Asking the user for video start time and duration in seconds
#milliseconds = 1000
#start_time = int(input("Enter Start time: "))
#end_time = int(input("Enter Length: "))
#end_time = start_time + end_time

# Passing the start and end time for CV2
#cap.set(cv2.CAP_PROP_POS_MSEC, start_time*milliseconds)

#Will execute till the duration specified by the user
#while True: #and cap.get(cv2.CAP_PROP_POS_MSEC)<=end_time*milliseconds:
  #      success, img = cap.read()
   #     cv2.imshow("Image", img)
   #     cv2.waitKey(10)
"""

