using Cinemachine;
using UnityEngine;

namespace JourneyThroughTraps
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
