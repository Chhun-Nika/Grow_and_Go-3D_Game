using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public int level = 1;
    public int currentExp = 0;
    public int expToNextLevel = 10;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddExp(int amount)
    {
        currentExp += amount;

        if (currentExp >= expToNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        currentExp -= expToNextLevel;
        level++;

        // Increase next level requirement (Hay Day style)
        expToNextLevel += 10;

        Debug.Log("LEVEL UP! New Level: " + level);
    }
}
