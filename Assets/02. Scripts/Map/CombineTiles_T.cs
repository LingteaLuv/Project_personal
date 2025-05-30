using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

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
        foreach (MeshFilter mesh in meshFilters)
        {
            if (mesh.sharedMesh.name.StartsWith("Cube"))
            {
                wallMeshFilters.Add(mesh);
            }
            else
            {
                planeMeshFilters.Add(mesh);
            }
        }
        CombineInstance[] wallCombine = Initiate(wallMeshFilters);
        CombineInstance[] planeCombine = Initiate(planeMeshFilters);

        GameObject wall = Combine(wallCombine, wallMeshFilters);
        GameObject floor = Combine(planeCombine, planeMeshFilters);

        floor.name = "CombinedFloor";
        wall.name = "CombinedWall";
        
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
