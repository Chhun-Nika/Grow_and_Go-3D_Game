using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsUI : MonoBehaviour
{
    public static SettingsUI Instance;

    [Header("Toggles")]
    public Toggle musicToggle;

    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    void Start()
    {
        // Sync toggle states
        musicToggle.isOn = MusicManager.Instance.musicSource.volume > 0;
        

        musicToggle.onValueChanged.AddListener(OnMusicToggle);
    }

    public void Open()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f; // Pause game
    }

    public void Close()
    {
        Time.timeScale = 1f; // Resume game
        gameObject.SetActive(false);
    }

    void OnMusicToggle(bool isOn)
    {
        MusicManager.Instance.musicSource.volume = isOn ? 1f : 0f;
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("WelcomeScene"); // change name if needed
    }
}
