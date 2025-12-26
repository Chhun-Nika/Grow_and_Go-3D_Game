using UnityEngine;
using TMPro;

public class ShopUI : MonoBehaviour
{
    public TMP_Text feedbackText; // optional (e.g. "Not enough coins")

    private const int CROP_PRICE = 10;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void OpenShop()
    {
        gameObject.SetActive(true);
        if (feedbackText != null)
            feedbackText.text = "";
    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
    }

    public void BuyTomato()
    {
        if (!CurrencyManager.Instance.SpendCoins(CROP_PRICE))
        {
            ShowNoMoney();
            return;
        }

        StorageManager.Instance.AddTomatoes(1);
        Debug.Log("Bought 1 Tomato");
    }

    public void BuyCorn()
    {
        if (!CurrencyManager.Instance.SpendCoins(CROP_PRICE))
        {
            ShowNoMoney();
            return;
        }

        StorageManager.Instance.AddCorn(1);
        Debug.Log("Bought 1 Corn");
    }

    void ShowNoMoney()
    {
        Debug.Log("Not enough coins to buy crop");

        if (feedbackText != null)
            feedbackText.text = "Not enough coins!";
    }
}
