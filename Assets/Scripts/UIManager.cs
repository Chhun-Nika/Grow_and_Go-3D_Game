using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public FlyingIcon flyingStarIcon;
    public RectTransform expStarIcon; // The star icon in your HUD

    void Awake()
    {
        Instance = this;
    }

    // Call this to play the star flying effect
    public void PlayStarFlyEffect(Vector3 worldPosition)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPosition);
        flyingStarIcon.FlyTo(screenPos, expStarIcon.position, flyingStarIcon.transform.parent);
    }
}
