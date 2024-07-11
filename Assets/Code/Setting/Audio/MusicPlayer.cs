using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    private AudioSource audioSource;
    private int currentClipIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        PlayNextClip();
    }
    void Update()
    {
        if (PlayerPrefs.GetInt("MusicIsMuted") == 0)
        {
            audioSource.volume = 0.3f;
            if (!audioSource.isPlaying)
            {
                PlayNextClip();
            }
        }
        else
        {
            audioSource.volume = 0f;
        }
    }

    private void PlayNextClip()
    {
        if (clips.Length == 0)
        {
            return;
        }

        audioSource.clip = clips[currentClipIndex];
        audioSource.Play();
        currentClipIndex = (currentClipIndex + 1) % clips.Length; // �������� ������ �� ����������� ����������
    }
}