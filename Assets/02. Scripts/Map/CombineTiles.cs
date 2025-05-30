using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class CombineTiles : MonoBehaviour
{
    private void Start()
    {
        Init();
    }

    private void Update()
    {
        
    }

    private void Init()
    {
        // 바닥 타일을 다 찾아서 Combine
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        for (int i = 0; i < meshFilters.Length; i++)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
        }

        GameObject floor = new GameObject("CombinedFloor");
        floor.tag = "Wall";
        Mesh combinedMesh = new Mesh();
        
        combinedMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;

        combinedMesh.CombineMeshes(combine);
        floor.AddComponent<MeshFilter>().mesh = combinedMesh;
        floor.AddComponent<MeshRenderer>().sharedMaterial = meshFilters[0].GetComponent<MeshRenderer>().sharedMaterial;
        floor.AddComponent<MeshCollider>();
        
        NavMeshSurface navSurface = floor.AddComponent<NavMeshSurface>();
        navSurface.collectObjects = CollectObjects.Children; 
        navSurface.BuildNavMesh(); 
    }
}
