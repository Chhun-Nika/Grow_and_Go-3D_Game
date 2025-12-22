using UnityEngine;

public class StorageManager : MonoBehaviour
{
    public static StorageManager Instance;

    private int tomatoCount = 4;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object alive if you want between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Add tomatoes to storage
    public void AddTomatoes(int amount)
    {
        tomatoCount += amount;
        Debug.Log($"Added {amount} tomatoes. Total: {tomatoCount}");
    }

    // Remove tomatoes from storage (when planting)
    public bool RemoveTomatoes(int amount)
    {
        if (tomatoCount >= amount)
        {
            tomatoCount -= amount;
            Debug.Log($"Removed {amount} tomatoes. Total: {tomatoCount}");
            return true;
        }
        else
        {
            Debug.LogWarning("Not enough tomatoes!");
            return false;
        }
    }

    // Get current tomato count
    public int GetTomatoCount()
    {
        return tomatoCount;
    }
}
