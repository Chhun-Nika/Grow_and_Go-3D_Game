using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;

    [SerializeField] private int coins = 0; // give test coins

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

    public int Coins => coins;

    public void AddCoins(int amount)
    {
        coins += amount;
        Debug.Log($"[Currency] +{amount}, Total: {coins}");

        UpdateUI();
    }

    public bool SpendCoins(int amount)
    {
        if (coins < amount)
        {
            Debug.Log("[Currency] Not enough coins");
            return false;
        }

        coins -= amount;
        Debug.Log($"[Currency] -{amount}, Remaining: {coins}");

        UpdateUI();
        return true;
    }

    void UpdateUI()
    {
        CoinUI ui = FindObjectOfType<CoinUI>();
        if (ui != null)
            ui.UpdateCoin();
    }
}
