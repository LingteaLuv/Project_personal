using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
using Unity.Collections;

public class CombineTiles_T : MonoBehaviour
{
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        List<MeshFilter> wallMeshFilters = new List<MeshFilter>();
        List<MeshFilter> planeMeshFilters = new List<MeshFilter>();
        List<MeshFilter> safeZoneMeshFilters = new List<MeshFilter>();
        foreach (MeshFilter mesh in meshFilters)
        {
            if (mesh.sharedMesh.name.StartsWith("Cube"))
            {
                wallMeshFilters.Add(mesh);
            }
            else
            {
                if (mesh.gameObject.layer == 8)
                {
                    planeMeshFilters.Add(mesh);
                }
                else
                {
                    safeZoneMeshFilters.Add(mesh);
                }
            }
        }
        CombineInstance[] wallCombine = Initiate(wallMeshFilters);
        CombineInstance[] planeCombine = Initiate(planeMeshFilters);
        CombineInstance[] safeZoneCombine = Initiate(safeZoneMeshFilters);

        GameObject wall = Combine(wallCombine, wallMeshFilters);
        GameObject floor = Combine(planeCombine, planeMeshFilters);
        GameObject safeZone = Combine(safeZoneCombine, safeZoneMeshFilters);

        floor.name = "CombinedFloor";
        wall.name = "CombinedWall";
        safeZone.name = "CombinedSafeZone";
        
        NavMeshSurface navSurface = floor.AddComponent<NavMeshSurface>();
        navSurface.collectObjects = CollectObjects.Children; 
        navSurface.BuildNavMesh(); 
    }

    private CombineInstance[] Initiate(List<MeshFilter> meshFilters)
    {
        CombineInstance[] temp = new CombineInstance[meshFilters.Count];
        for (int i = 0; i < meshFilters.Count; i++)
        {
            temp[i].mesh = meshFilters[i].sharedMesh;
            temp[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
        }
        return temp;
    }

    private GameObject Combine(CombineInstance[] combine, List<MeshFilter> meshFilters)
    {
        GameObject temp = new GameObject();
        Mesh combinedMesh = new Mesh();
        combinedMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        
        combinedMesh.CombineMeshes(combine);
        
        temp.AddComponent<MeshFilter>().mesh = combinedMesh;
        temp.AddComponent<MeshRenderer>().sharedMaterial = meshFilters[0].GetComponent<MeshRenderer>().sharedMaterial;
        temp.AddComponent<MeshCollider>();

        temp.tag = "Wall";

        return temp;
    }
}
