using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// This class manages the display of a loading screen and progress bar while asynchronously loading scenes in Unity.
/// </summary>
public class ShowLoadingPanel : MonoBehaviour
{
    [Tooltip("The loading screen UI object")]
    [SerializeField] private GameObject loadingScreen;
    [Tooltip("The loading progress bar image")]
    [SerializeField] private Image loadingImage;

    private static ShowLoadingPanel instance; // Singleton instance of the loading panel

    private void Awake()
    {
        // Ensure only one instance of the loading panel exists
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Deactivate the loading screen initially
        loadingScreen.SetActive(false);
    }

    /// <summary>
    /// Loads a scene asynchronously while displaying a loading screen and progress bar.
    /// </summary>
    /// <param name="levelToLoad">The name of the scene to load.</param>
    public static void LoadLevel(string levelToLoad)
    {
        if (instance != null)
        {
            // Activate the loading screen UI
            if (instance.loadingScreen != null)
            {
                Time.timeScale = 1; // Ensure time scale is normal
                instance.loadingScreen.SetActive(true);
            }

            // Start the asynchronous loading process
            instance.StartCoroutine(instance.LoadLevelAsync(levelToLoad));
        }
        else
        {
            Debug.LogError("LoadLevel instance is not set.");
        }
    }

    private IEnumerator LoadLevelAsync(string levelToLoad)
    {
        // Check if loading screen objects are properly set
        if (loadingScreen == null || loadingImage == null)
        {
            Debug.LogError("Loading screen or loading image is not set.");
            yield break;
        }

        // Load the scene asynchronously
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);

        // Check for errors in scene loading
        if (loadOperation == null)
        {
            Debug.LogError($"Failed to load scene: {levelToLoad}");
            yield break;
        }

        // Update loading progress until scene is fully loaded
        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f); // Normalize progress value
            loadingImage.fillAmount = progressValue; // Update the loading bar fill amount
            yield return null; // Wait for the next frame
        }

        // Deactivate loading screen once scene is loaded
        if (loadingScreen != null)
        {
            loadingScreen.SetActive(false);
        }
    }
}