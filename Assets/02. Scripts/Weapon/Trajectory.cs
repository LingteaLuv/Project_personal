using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    private LineRenderer _renderer;
    private Camera _camera;
    
    private void Awake()
    {
        Init();
    }
    
    public void UpdateTrajectory(GameObject curArrow, float arrowSpeed)
    {
        int pointCount = 30;
        float deltaTime = 0.1f;

        Vector3[] trajectorys = new Vector3[pointCount];
        Vector3 startPos = transform.position;

        transform.rotation = Quaternion.Euler(_camera.transform.eulerAngles.x, _camera.transform.eulerAngles.y, 0);
        
        curArrow.transform.rotation = transform.rotation;
        
        float speed = arrowSpeed;
        Vector3 startVel = transform.forward * speed;

        for (int i = 0; i < pointCount; i++)
        {
            trajectorys[i] = CalculatePoint(startPos, startVel, deltaTime * i);
        }

        _renderer.positionCount = pointCount;
        _renderer.SetPositions(trajectorys);
    }
    
    private Vector3 CalculatePoint(Vector3 startPos, Vector3 startVel, float time)
    {
        Vector3 gravity = Physics.gravity;
        return startPos + startVel * time + 0.5f * gravity * time * time;
    }
    
    private void Init()
    {
        _renderer = GetComponent<LineRenderer>();
        _camera = transform.parent.GetComponentInChildren<Camera>();
    }
}
