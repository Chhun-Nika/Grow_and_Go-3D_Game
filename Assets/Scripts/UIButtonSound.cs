using UnityEngine;

public class UIButtonSound : MonoBehaviour
{
    [Range(0f, 2f)]
    public float clickVolume = 1f;

    public void PlayClickSound()
    {
        if (SFXManager.Instance != null)
            SFXManager.Instance.PlayButtonClick(clickVolume);
    }
}
