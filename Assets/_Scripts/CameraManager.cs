using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera standartCamera;
    
    private void Awake()
    {
        GameManager.Instance.cameraManager = this;
    }

    public void SetTarget(GameObject target)
    {
        standartCamera.Follow = target.transform;
    }
}
