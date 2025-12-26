using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FenceLevelLock : MonoBehaviour
{
    [Header("Requirements")]
    public int requiredLevel = 3;
    public int unlockCost = 50;

    [Header("Fence Colliders")]
    public Collider blockingCollider;   // IsTrigger = false
    public Collider triggerCollider;    // IsTrigger = true

    [Header("UI")]
    public GameObject uiRoot;
    public TMP_Text messageText;
    public Button unlockButton;

    private bool unlocked = false;

    void Start()
    {
        uiRoot.SetActive(false);

        if (unlockButton != null)
            unlockButton.onClick.AddListener(UnlockLand);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (unlocked) return;
        if (!other.CompareTag("Player")) return;

        uiRoot.SetActive(true);

        int playerLevel = LevelManager.Instance.CurrentLevel;
        int playerCoins = CurrencyManager.Instance.Coins;

        // LEVEL TOO LOW
        if (playerLevel < requiredLevel)
        {
            messageText.text = "Reach Level " + requiredLevel + " to unlock this land";
            unlockButton.gameObject.SetActive(false);
            return;
        }

        // LEVEL OK
        unlockButton.gameObject.SetActive(true);

        // NOT ENOUGH COINS
        if (playerCoins < unlockCost)
        {
            messageText.text = "Need " + unlockCost + " coins to unlock";
            unlockButton.interactable = false;
            
        }
        else
        {
            messageText.text = "Unlock land for " + unlockCost + " coins";
            unlockButton.interactable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        uiRoot.SetActive(false);
    }

    public void UnlockLand()
    {
        if (unlocked) return;

        if (LevelManager.Instance.CurrentLevel < requiredLevel)
            return;

        Debug.Log("Trying to spend coins...");

        if (!CurrencyManager.Instance.SpendCoins(unlockCost))
        {
            Debug.Log("SpendCoins FAILED");
            return;
        }

        unlocked = true;

        blockingCollider.enabled = false;
        triggerCollider.enabled = false;

        uiRoot.SetActive(false);

        Debug.Log("Land unlocked with coins + level");
    }

}
