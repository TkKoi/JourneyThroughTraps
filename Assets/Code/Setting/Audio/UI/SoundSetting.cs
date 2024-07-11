using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    public static SoundSetting instance;
    private bool isMuted = false;
    private const string muteKey = "SoundIsMuted";


    [SerializeField] private Sprite muteSprite;
    [SerializeField] private Sprite unMuteSprite;
    [SerializeField] private Image muteImage;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        isMuted = PlayerPrefs.GetInt(muteKey, 0) == 1;
        UpdateSoundState();
    }

    // Method to handle button press for toggling sound
    public void ToggleSound()
    {
        // SoundPlayer.Instance.PlaySound("Click");
        isMuted = !isMuted;
        UpdateSoundState();

        PlayerPrefs.SetInt(muteKey, isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }

    // Method to check if the sound is muted
    public bool IsMuted()
    {
        return isMuted;
    }

    // Method to update the sound state and CanvasGroup animation
    private void UpdateSoundState()
    {
        muteImage.sprite = isMuted ? muteSprite : unMuteSprite;
    }
}