import stat
import string
import os
from turtle import color
import numpy as np
import matplotlib.pyplot as plt
import copy
import time
import sys
import open3d as o3d

class PyO3DHelperClass:
    
    intrinsic = o3d.camera.PinholeCameraIntrinsic(o3d.camera.PinholeCameraIntrinsicParameters.PrimeSenseDefault)
    
    # voxel downsampling
    @staticmethod
    def downsampling(self, pointCloud, voxel_size = 0.5 , showOutput = False):
        pointCloud_down = pointCloud.voxel_down_sample(voxel_size=voxel_size)
        if showOutput:
            o3d.visualization.draw_geometries([pointCloud_down])
        return pointCloud_down
    
    @staticmethod
    def readPointCloud3D(self, pcd):
        return o3d.io.read_point_cloud(pcd)

    @staticmethod
    def showPointCloud3D(self, pcdInput):
        if pcdInput is string:
            #pcd = o3d.io.read_point_cloud("C:/Users/T0571/Downloads/poly.ply")
            #pcdInput = o3d.io.read_point_cloud("C:/Users/T0571/source/repos/OpenCV_Vision_Pro/OpenCV_Vision_Pro/pointCloudDeepLearning.ply")
            pcdInput = o3d.io.read_point_cloud(pcdInput)
        
        if type(pcdInput) is list:
            o3d.visualization.draw_geometries(pcdInput)
        else:
            o3d.visualization.draw_geometries([pcdInput])

    def vertexNormalEstimation(self, pcd, radius = 0.1, max_nn=30, showOutput = False):
        pcd.estimate_normals(search_param=o3d.geometry.KDTreeSearchParamHybrid(radius=radius,max_nn=max_nn))
        if showOutput:
            o3d.visualization.draw_geometries([pcd])
            
    def vertexNormalEstimation(self, pcd, search_param = o3d.geometry.KDTreeSearchParamHybrid(radius=0.1,max_nn=30), showOutput = False):
        pcd.estimate_normals(search_param=search_param)
        if showOutput:
            o3d.visualization.draw_geometries([pcd])
   
    # alpha shape = generalisation of a convex hull
    def surfaceReconstruction(self, pcd, alpha = 0.07, showOutput = False):
        mesh = o3d.geometry.TriangleMesh.create_from_point_cloud_alpha_shape(pcd,alpha) # tetra_mesh, pt_map = o3d.geometry.TetraMesh.create_from_point_cloud(downpcd)
        mesh.compute_vertex_normals()
        if showOutput:
            o3d.visualization.draw_geometries([mesh],mesh_show_back_face=True)
        return mesh
    
    def setIntrinsicMatrix(self, MatrixFromTXTPath,m00 = 640,m01 = 480,m02 = 525,m10 = 525,m11 = 320,m12 = 240):
        if MatrixFromTXTPath is not None:
            self.intrinsic = np.loadtxt(MatrixFromTXTPath)
        else:
            self.intrinsic = o3d.camera.PinholeCameraIntrinsic(m00,m01,m02,m10,m11,m12).intrinsic_matrix
    
    def generatePointCloudFromRGBD(self, colorImagePath, depthImagePath, flip = True, downSampling = False, voxel_size = 0.5):
        color = o3d.io.read_image(colorImagePath)
        depth = o3d.io.read_image(depthImagePath)
        rgbd = o3d.geometry.RGBDImage.create_from_color_and_depth(color,depth)
    
        pcd = o3d.geometry.PointCloud.create_from_rgbd_image(rgbd,self.intrinsic)

        if downSampling:
            pcd = self.downsampling(pcd, voxel_size)
        
        if flip:
            pcd.transform([[1,0,0,0],[0,-1,0,0],[0,0,-1,0],[0,0,0,1]]) #flip
            
        return pcd
    
    def loopFolderToGenerate(self, colorFolder, depthFolder, colorImageExtension = ".jpg", depthImageExtension = ".png", colorImageFormat = "06d", depthImageFormat = "06d", max_Image_count=1):
        pcds = []
        for i in range(0,max_Image_count,2):
            pcd = self.generatePointCloudFromRGBD(os.path.join(colorFolder,("{:"+colorImageFormat+"}").format(i)+colorImageExtension), 
                                       os.path.join(depthFolder,("{:"+depthImageFormat+"}").format(i)+depthImageExtension))
            pcds.append(pcd)
        return pcds
    
    """
       Ref-Faster: https://www.youtube.com/watch?v=cjSPf7OMx4w&list=PLkmvobsnE0GEZugH1Di2Cr_f32qYkv7aN&index=8
       Ref: http://www.open3d.org/docs/release/tutorial/pipelines/multiway_registration.html
    """
    def alignMultiplePcd(self, pcds_down,voxel_size = 0.1):
        def pairwise_registration(source, target):
            print("Apply point-to-plane ICP")
            target.estimate_normals(search_param=o3d.geometry.KDTreeSearchParamHybrid(radius=voxel_size * 2.0, max_nn=30))
            icp_coarse = o3d.pipelines.registration.registration_icp(
                source, target, max_correspondence_distance_coarse, np.identity(4),
                o3d.pipelines.registration.TransformationEstimationPointToPlane())
            icp_fine = o3d.pipelines.registration.registration_icp(
                source, target, max_correspondence_distance_fine,
                icp_coarse.transformation,
                o3d.pipelines.registration.TransformationEstimationPointToPlane())
            transformation_icp = icp_fine.transformation
            information_icp = o3d.pipelines.registration.get_information_matrix_from_point_clouds(
                source, target, max_correspondence_distance_fine,
                icp_fine.transformation)
            return transformation_icp, information_icp
        def full_registration(pcds, max_correspondence_distance_coarse,
                                max_correspondence_distance_fine):
            pose_graph = o3d.pipelines.registration.PoseGraph()
            odometry = np.identity(4)
            pose_graph.nodes.append(o3d.pipelines.registration.PoseGraphNode(odometry))
            n_pcds = len(pcds)
            for source_id in range(n_pcds):
                for target_id in range(source_id + 1, n_pcds):
                    transformation_icp, information_icp = pairwise_registration(
                        pcds[source_id], pcds[target_id])
                    print("Build o3d.pipelines.registration.PoseGraph")
                    if target_id == source_id + 1:  # odometry case
                        odometry = np.dot(transformation_icp, odometry)
                        pose_graph.nodes.append(
                            o3d.pipelines.registration.PoseGraphNode(np.linalg.inv(odometry)))
                        pose_graph.edges.append(
                            o3d.pipelines.registration.PoseGraphEdge(source_id,
                                                            target_id,
                                                            transformation_icp,
                                                            information_icp,
                                                            uncertain=False))
                    else:  # loop closure case
                        pose_graph.edges.append(
                            o3d.pipelines.registration.PoseGraphEdge(source_id,
                                                            target_id,
                                                            transformation_icp,
                                                            information_icp,
                                                            uncertain=True))
            return pose_graph
        print("Full registration ...")
        max_correspondence_distance_coarse = voxel_size * 15
        max_correspondence_distance_fine = voxel_size * 1.5
        with o3d.utility.VerbosityContextManager(o3d.utility.VerbosityLevel.Debug) as cm:
            pose_graph = full_registration(pcds_down,
                                            max_correspondence_distance_coarse,
                                            max_correspondence_distance_fine)
 
       
        print("Optimizing PoseGraph ...")
        option = o3d.pipelines.registration.GlobalOptimizationOption(
            max_correspondence_distance=max_correspondence_distance_fine,
            edge_prune_threshold=0.25,
            reference_node=0)
        
        with o3d.utility.VerbosityContextManager(o3d.utility.VerbosityLevel.Debug) as cm:
            o3d.pipelines.registration.global_optimization(
                pose_graph, o3d.pipelines.registration.GlobalOptimizationLevenbergMarquardt(),
                o3d.pipelines.registration.GlobalOptimizationConvergenceCriteria(), option)
        
        pcd_combined = o3d.geometry.PointCloud()
        for point_id in range(len(pcds_down)):
            pcds_down[point_id].transform(pose_graph.nodes[point_id].pose)
            pcd_combined += pcds_down[point_id]
        pcd_combined_down = pcd_combined.voxel_down_sample(voxel_size=0.02)
        o3d.io.write_point_cloud("new_registration.pcd", pcd_combined_down)
        
        o3d.visualization.draw_geometries([pcd_combined_down])

'''
pcds = PyO3DHelperClass.loopFolderToGenerate("C:/Users/T0571/Downloads/rgbd_lobby/lobby/image","C:/Users/T0571/Downloads/rgbd_lobby/lobby/depth")
PyO3DHelperClass.alignMultiplePcd(pcds)
'''

"""
print("Transform points and display")
for point_id in range(len(pcds_down)):
    print(pose_graph.nodes[point_id].pose)
    pcds_down[point_id].transform(pose_graph.nodes[point_id].pose)
o3d.visualization.draw_geometries(pcds_down)
"""
