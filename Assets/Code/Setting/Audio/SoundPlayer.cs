using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    private const string SoundPath = "Audios/Sounds/";
    private AudioSource audioSource;
    private Dictionary<string, AudioClip> soundDictionary = new Dictionary<string, AudioClip>();
    public static SoundPlayer Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optionally, if you want the SoundManager to persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Adds a sound to the dictionary by name
    public void AddSound(string soundName, AudioClip soundClip)
    {
        if (!soundDictionary.ContainsKey(soundName))
        {
            soundDictionary.Add(soundName, soundClip);
        }
        else
        {
            Debug.LogWarning("Sound with name " + soundName + " already exists in the dictionary.");
        }
    }

    // Plays a sound by name
    public void PlaySound(string soundName)
    {
        if (PlayerPrefs.GetInt("SoundIsMuted") == 0)
        {
            if (soundDictionary.ContainsKey(soundName))
            {
                audioSource.PlayOneShot(soundDictionary[soundName]);
            }
            else
            {
                Debug.LogWarning("Sound with name " + soundName + " not found in the dictionary.");
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Example of adding a sound
        // Assumes you already have an object with an audio source, and this script is attached to the same object
        // You can add sounds in the Unity editor in the inspector of this object
        AddSound("Click", Resources.Load<AudioClip>(SoundPath + "Click"));
        AddSound("Lose", Resources.Load<AudioClip>(SoundPath + "Lose"));
        AddSound("Win", Resources.Load<AudioClip>(SoundPath + "Win"));
        AddSound("Star", Resources.Load<AudioClip>(SoundPath + "Star"));
        AddSound("Swipe", Resources.Load<AudioClip>(SoundPath + "Swipe"));
    }
}