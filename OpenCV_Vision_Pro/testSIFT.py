import open3d as o3d
import numpy as np
import laspy
import PyO3DHelperClass

path = "C://Users//T0571//Downloads//ALS2018_UP_Golm_06May2018.laz"
pc = laspy.read(path)

xyz = np.vstack((pc.x,pc.y,pc.z)).transpose()
print(xyz.shape)


pcd = o3d.geometry.PointCloud()
pcd.points = o3d.utility.Vector3dVector(xyz)

pcd.estimate_normals(o3d.geometry.KDTreeSearchParamHybrid(radius=1,max_nn=32))
#o3d.visualization.draw_geometries([pcd])

pcd.orient_normals_to_align_with_direction([0.,0.,1.])

#o3d.visualization.draw_geometries([pcd])

pcd = pcd.voxel_down_sample(voxel_size=2)
o3d.visualization.draw_geometries([pcd])

mesh = o3d.geometry.TriangleMesh.create_from_point_cloud_alpha_shape(pcd,0.7)
mesh.compute_vertex_normals()
o3d.visualization.draw_geometries([mesh],mesh_show_back_face=True)