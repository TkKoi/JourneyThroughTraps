using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace TombOfTheMaskClone
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class CameraFollow : MonoBehaviour
    {
        private PlayerMovement playerMovement;
        private CinemachineVirtualCamera cinemachineVirtualCamera;
        void Start()
        {
            cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
            playerMovement = FindObjectOfType<PlayerMovement>();
            cinemachineVirtualCamera.Follow = playerMovement.gameObject.transform;
        }
    }
}
