using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    public AudioSource sfxSource;
    public AudioClip buttonClick;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void PlayButtonClick(float volume = 1f)
    {
        sfxSource.PlayOneShot(buttonClick, volume);
    }
}
