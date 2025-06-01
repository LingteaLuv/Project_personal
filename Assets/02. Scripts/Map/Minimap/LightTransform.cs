using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTransform : MonoBehaviour
{
    private void LateUpdate()
    {
        Camera camera = transform.parent.GetComponentInChildren<Camera>();
        if (camera != null)
        {
            transform.position = camera.transform.position;
        }
    }

}
