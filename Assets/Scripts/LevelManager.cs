using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private int currentLevel = 1;
    [SerializeField] private int currentExp = 0;
    [SerializeField] private int expToNextLevel = 10;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public int CurrentLevel => currentLevel;
    public int CurrentExp => currentExp;
    public int ExpToNextLevel => expToNextLevel;

    public void AddExp(int amount)
    {
        currentExp += amount;

        if (currentExp >= expToNextLevel)
            LevelUp();
    }

    void LevelUp()
    {
        currentExp -= expToNextLevel;
        currentLevel++;
        expToNextLevel += 5;

        Debug.Log("Level Up! Level: " + currentLevel);
    }


}
