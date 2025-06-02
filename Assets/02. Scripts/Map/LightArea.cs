using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LightArea : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private Light _mainLight; 
    [SerializeField] private Light _minimapLight;
    
    private BoxCollider _area;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            _mainLight.gameObject.SetActive(true);
            _minimapLight.enabled = false;
            RenderSettings.subtractiveShadowColor = new Color(107,122 ,160);
            RenderSettings.fog = false;
            RenderSettings.ambientMode = AmbientMode.Skybox;
            RenderSettings.ambientIntensity = 1;
            
            SoundManager.Instance.StopBGM();
            GameManager.Instance.IsInMaze = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            _mainLight.gameObject.SetActive(false);
            _minimapLight.enabled = true;
            RenderSettings.ambientLight = new Color(0.1f, 0.1f, 0.1f);
            RenderSettings.ambientIntensity = 0.1f;
            RenderSettings.fog = true;
            RenderSettings.fogMode = FogMode.Exponential;
            RenderSettings.fogDensity = 0.05f;
            
            SoundManager.Instance.PlayBGM("MazeBGM", true);
            GameManager.Instance.IsInMaze = true;
        }
    }
}
