using System.Collections;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CameraShake : MonoBehaviour
{
    private static CameraShake instance;
    public static CameraShake Instance
    {
        get { return instance; }
    }

    private CinemachineVirtualCamera vCamera;
    [SerializeField] float Amplitude;
    [SerializeField] float Frequency;
    [SerializeField] float TimeShake;
    private bool isShaking = false;

    private void Awake()
    {
        instance = this;
        vCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void StartShake()
    {
        if (!isShaking)
        {
            StartCoroutine(ShakeCoroutine(Amplitude, Frequency, TimeShake));
        }
    }

    public void StartShake(float amplitude, float frequency, float timeShake)
    {
        if (!isShaking)
        {
            StartCoroutine(ShakeCoroutine(amplitude, frequency, timeShake));
        }
    }

    private IEnumerator ShakeCoroutine(float amplitude, float frequency, float timeShake)
    {
        isShaking = true;

        vCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitude;
        vCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = frequency;

        yield return new WaitForSeconds(timeShake);

        vCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        vCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0;

        isShaking = false;
    }
}
