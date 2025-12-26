using UnityEngine;

public class LandBlock : MonoBehaviour
{
    public PlantLand plantLand;
    public GameObject fence;
    public FenceLockTrigger fenceTrigger;

    public int requiredLevel = 2;

    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        bool unlocked = LevelManager.Instance.CurrentLevel >= requiredLevel;

        // Block or unblock land
        plantLand.SetBlocked(!unlocked);

        // Fence visibility
        fence.SetActive(!unlocked);

        // Update fence message level
        if (fenceTrigger != null)
            fenceTrigger.requiredLevel = requiredLevel;
    }
}
