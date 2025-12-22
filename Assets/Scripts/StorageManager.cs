using UnityEngine;

public class StorageManager : MonoBehaviour
{
    public static StorageManager Instance;

    [SerializeField] private int tomatoCount = 4;
    [SerializeField] private int cornCount = 2;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ADD TOMATO
    public void AddTomatoes(int amount)
    {
        tomatoCount += amount;
        Debug.Log($"[Storage] +{amount} Tomato | Total: {tomatoCount}");
    }

    // REMOVE TOMATO (PLANTING)
    public bool RemoveTomatoes(int amount)
    {
        if (tomatoCount < amount)
        {
            Debug.LogWarning("[Storage] Not enough Tomato");
            return false;
        }

        tomatoCount -= amount;
        Debug.Log($"[Storage] -{amount} Tomato | Total: {tomatoCount}");
        return true;
    }

    // ADD CORN
    public void AddCorn(int amount)
    {
        cornCount += amount;
        Debug.Log($"[Storage] +{amount} Corn | Total: {cornCount}");
    }

    // REMOVE CORN (PLANTING)
    public bool RemoveCorn(int amount)
    {
        if (cornCount < amount)
        {
            Debug.LogWarning("[Storage] Not enough Corn");
            return false;
        }

        cornCount -= amount;
        Debug.Log($"[Storage] -{amount} Corn | Total: {cornCount}");
        return true;
    }

    public int GetTomatoCount() => tomatoCount;
    public int GetCornCount() => cornCount;
}
