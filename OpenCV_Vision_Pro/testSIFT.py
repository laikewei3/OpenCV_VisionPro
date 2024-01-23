import open3d as o3d
import numpy as np

print("AAAAAAAAA")
# Ref: https://medium.com/@amnahhmohammed/gentle-introduction-to-point-cloud-registration-using-open3d-pt-1.2-18df4cb8b16c
global pcd_combined
pcd_combined = o3d.geometry.PointCloud()
def draw_registration_result(source,transformation):
    global pcd_combined
    source.transform(transformation)
    pcd_combined += source
    pcd_combined = pcd_combined.voxel_down_sample(voxel_size=1.2)
    return source

"""
Fast Point Feature Histograms (FPFH)
- describe the local geometry of a point in a 3D space by looking at its neighboring points.
* looks at each point and its nearby neighbors
* calculates a histogram based on the angles between these points.
    ~ histogram serves as a “fingerprint” that captures the local geometry around each point 
      that will be used when trying to find matches of the same point in the target point cloud.
"""
def preprocess_point_cloud(pcd,voxel_size=1.2):
    # IF Want, down sample here
    radius_normal = voxel_size * 2
    '''
    normal of each point is crucial information for the FPFH algorithm where it requires every point 
    in the point cloud “p” and the surface normal, n, at that point, as well as relevant information 
    from p’s nearest neighbors.
    '''
    pcd.estimate_normals(o3d.geometry.KDTreeSearchParamHybrid(radius=radius_normal, max_nn=30))
    
    bbox = o3d.geometry.AxisAlignedBoundingBox(min_bound=(-85,-80,-150), max_bound=(110,80,150))
    pcd = pcd.crop(bbox)    
    pcd,ind = pcd.remove_statistical_outlier(nb_neighbors=50, std_ratio=2.0)

    radius_feature = voxel_size * 5
    pcd_fpfh = o3d.pipelines.registration.compute_fpfh_feature(pcd,
               o3d.geometry.KDTreeSearchParamHybrid(radius=radius_feature, max_nn=100))
    
    return pcd, pcd_fpfh

#RANSAC ALGO - GLOBAL
"""
RANSAC (Random Sample Consensus)
- effective algorithm for dealing with outliers in data
- works by randomly:
    * selecting a subset of data points
    * fitting a model to these points
    * scoring the model based on how many other points fit it
    * repeated multiple times
    * model with the highest score is selected: inliers, not selected: outliers
"""
def execute_RANSAC_global_registration(source,target,source_fpfh,target_fpfh,voxel_size = 1.2):
    distance_threshold = voxel_size * 1
    print("RANSAC registration")
    '''
    Pruning to reject and eliminate incorrect matches
    - technique that reduces the size of a trained model by eliminating some of its parameters
    - create a smaller, faster, and more efficient model while maintaining its accuracy
    1. CorrespondenceCheckerBasedOnDistance:
        - checks if the aligned point clouds are close: distance between them is less than a specified threshold.
    2. CorrespondenceCheckerBasedOnEdgeLength:
        - checks if the lengths of any two arbitrary edges (lines formed by two vertices) individually drawn from 
          source and target correspondences are similar
    '''
    result = o3d.pipelines.registration.registration_ransac_based_on_feature_matching(
        source,target,source_fpfh,target_fpfh,False,distance_threshold,
        o3d.pipelines.registration.TransformationEstimationPointToPoint(True),1,[
            o3d.pipelines.registration.CorrespondenceCheckerBasedOnEdgeLength(0.99),
            o3d.pipelines.registration.CorrespondenceCheckerBasedOnDistance(distance_threshold)],
            o3d.pipelines.registration.RANSACConvergenceCriteria(15000000,0.99))
    '''
    RANSACConvergenceCriteria: define the maximum number of RANSAC iterations and the confidence probability
    - larger these two numbers are, the more accurate the result is, but also the more time the algorithm takes.
    '''
    return result

#FAST ZHOU1.2016 - GLOBAL //NOT ACCURATE???
def execute_FAST_global_registration(source,target,source_fpfh,target_fpfh,voxel_size = 1.2):
    distance_threshold = voxel_size * 0.1
    print("FAST registration")
    result = o3d.pipelines.registration.registration_fgr_based_on_feature_matching(
        source, target, source_fpfh, target_fpfh,
        o3d.pipelines.registration.FastGlobalRegistrationOption(
            maximum_correspondence_distance=distance_threshold))
    return result

#POINT-TO-PLACE LOCAL REFINEMENT
def refine_registration(source,target,transformation, voxel_size = 1.2):
    distance_threshold = voxel_size * 1
    print("Point-to-plane registration")
    result = o3d.pipelines.registration.registration_icp(
                source, target, distance_threshold,
                transformation,
                o3d.pipelines.registration.TransformationEstimationPointToPlane())
    return result

#pcd0, pcd0_fpfh =  preprocess_point_cloud(o3d.io.read_point_cloud("C://Users//T0571//Desktop//Ref.ply"),1.2)

'''
pcd_combined += pcd0
global prevSource
for i in range(3,31):#1.25300
    
    print(i,end=":")    
    """
    color = o3d.io.read_image(os.path.join("C://Users//T0571//Downloads//rgbd_loft//loft//image","{:06d}".format(i)+".jpg"))
    depth = o3d.io.read_image(os.path.join("C://Users//T0571//Downloads//rgbd_loft//loft//depth","{:06d}".format(i)+".png"))
    
    rgbd = o3d.geometry.RGBDImage.create_from_color_and_depth(color,depth)
    
    pcd = o3d.geometry.PointCloud.create_from_rgbd_image(rgbd,o3d.camera.PinholeCameraIntrinsic(o3d.camera.PinholeCameraIntrinsicParameters.PrimeSenseDefault))

    pcd = pcd.voxel_down_sample(voxel_size=0.05)
    pcd.transform([[1,0,0,0],[0,-1,0,0],[0,0,-1,0],[0,0,0,1]]) #flip
            
    #pcds.append(pcd)
    #return pcds
    #o3d.visualization.draw_geometries([pcd])
    o3d.io.write_point_cloud("C://Users//T0571//Downloads//pcd_try//PCD_"+str(i)+".pcd", pcd)
    """ 
    pcd_combinedX, pcd_combined_fpfh = preprocess_point_cloud(pcd_combined,1.2)
    
    prevSource = pcd_combinedX
    pcd,pcd_fpfh = preprocess_point_cloud(o3d.io.read_point_cloud("C://Users//T0571//Desktop//hairclip//{:03d}.ply".format(i)),1.2)
    
    result_ransac = execute_RANSAC_global_registration(pcd,pcd_combined,pcd_fpfh,pcd_combined_fpfh,1.2)
    result_icp = refine_registration(pcd,pcd_combined,result_ransac.transformation,1.2)
    
    prevSource = draw_registration_result(pcd,result_icp.transformation)
    o3d.visualization.draw_geometries([pcd_combined])
    
  
#pcd_combined = pcd_combined.voxel_down_sample(voxel_size=0.1)
o3d.visualization.draw_geometries([pcd_combined])'''  
#o3d.io.write_point_cloud("C://Users//T0571//Desktop//new_registration.pcd", pcd_combined)
pcd = o3d.io.read_point_cloud("C://Users//T0571//Desktop//New folder (7)//penguin//out.ply")
pcd.normals = o3d.utility.Vector3dVector(np.zeros((1, 3)))  # invalidate existing normals
pcd.estimate_normals()
#pcd = mesh.sample_points_poisson_disk(30000)
#o3d.visualization.draw_geometries([tetra_mesh],mesh_show_back_face=False)

radii = np.arange(0.01,5,0.005)
rec_mesh = o3d.geometry.TriangleMesh.create_from_point_cloud_ball_pivoting(
    pcd, o3d.utility.DoubleVector(radii))
o3d.visualization.draw_geometries([rec_mesh])

'''
# Estimate Normal
pcd.normals = o3d.utility.Vector3dVector(np.zeros((1, 3)))  # invalidate existing normals
pcd.estimate_normals()
o3d.visualization.draw_geometries([pcd], point_show_normal=True)
'''

print("Completed")

