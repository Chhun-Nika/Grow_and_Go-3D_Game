using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    public TMP_Text coinText;

    void Start()
    {
        UpdateCoin();
    }

    public void UpdateCoin()
    {
        if (CurrencyManager.Instance == null) return;

        coinText.text = CurrencyManager.Instance.Coins.ToString();
    }
}
