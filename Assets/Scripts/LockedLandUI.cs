using UnityEngine;
using TMPro;

public class LockedLandUI : MonoBehaviour
{
    public static LockedLandUI Instance;
    public TMP_Text messageText;

    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void Show(int level)
    {
        messageText.text = $"Land Locked\nReach Level {level}";
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
