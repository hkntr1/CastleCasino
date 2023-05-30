using Cinemachine;
using DG.Tweening;
using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cm;
    public static Action onFloorUp;
    void Start()
    {
        onFloorUp += () =>
        {
            cm.transform.DOMoveY(cm.transform.position.y + 0.3f, 0.5f);
        };
    }
}
