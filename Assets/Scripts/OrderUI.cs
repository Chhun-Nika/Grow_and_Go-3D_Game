using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class OrderUI : MonoBehaviour
{
    public static OrderUI Instance;

    [Header("Order Slots")]
    [SerializeField] private List<OrderSlotUI> orderSlots;

    [Header("Detail Panel")]
    [SerializeField] private GameObject detailPanel;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text tomatoText;
    [SerializeField] private TMP_Text cornText;
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private TMP_Text expText;

    private OrderData currentOrder;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        // Debug: check references
        if (orderSlots == null || orderSlots.Count == 0)
            Debug.LogError("OrderUI: orderSlots list is empty or missing!", this);
        if (detailPanel == null)
            Debug.LogError("OrderUI: detailPanel missing!", this);
        if (titleText == null || tomatoText == null ||  cornText == null ||  coinText == null ||  expText == null)
            Debug.LogError("OrderUI: TMP_Text references missing!", this);
    }

    void Start()
    {
        // Hide detail panel at start
        if (detailPanel != null)
            detailPanel.SetActive(false);

        // Delay refresh to ensure OrderManager exists
        StartCoroutine(InitAfterFrame());
    }

    private IEnumerator InitAfterFrame()
    {
        yield return null; // wait one frame
        RefreshUI();        // safe: OrderManager.Instance should exist
    }

    public void Open(int selectedIndex)
    {
        gameObject.SetActive(true);
        RefreshUI();
    }

    public void Cancel()
    {
        if (currentOrder == null) return;

        if (OrderManager.Instance != null)
            OrderManager.Instance.activeOrders.Remove(currentOrder);

        if (detailPanel != null)
            detailPanel.SetActive(false);

        gameObject.SetActive(false);

        RefreshUI();

        if (OrderPaperSpawner.Instance != null)
            OrderPaperSpawner.Instance.RefreshPapers();

        currentOrder = null;

        if (OrderManager.Instance != null && OrderManager.Instance.activeOrders.Count == 0)
            OrderManager.Instance.GenerateOrders();
    }

    public void RefreshUI()
    {
        if (OrderManager.Instance == null || orderSlots == null) return;

        var orders = OrderManager.Instance.activeOrders;

        for (int i = 0; i < orderSlots.Count; i++)
        {
            if (orderSlots[i] == null) continue;

            if (i < orders.Count)
                orderSlots[i].SetOrder(orders[i]);
            else
                orderSlots[i].Clear();
        }
    }

    public void ShowDetail(OrderData order)
    {
        if (order == null) return;
        currentOrder = order;

        if (detailPanel != null)
            detailPanel.SetActive(true);

        if (titleText != null) titleText.text = "Order #" + order.orderId;
        if (tomatoText != null) tomatoText.text = "Tomato: " + order.tomatoAmount;
        if (cornText != null) cornText.text = "Corn: " + order.cornAmount;
        if (coinText != null) coinText.text = "Coins: " + order.coinReward;
        if (expText != null) expText.text = "EXP: " + order.expReward;
    }

    public void Sell()
    {
        if (currentOrder == null) return;

        if (StorageManager.Instance != null && !StorageManager.Instance.HasEnoughForOrder(currentOrder))
        {
            Debug.Log("Not enough items");
            return;
        }

        if (StorageManager.Instance != null)
            StorageManager.Instance.DeductForOrder(currentOrder);

        if (CurrencyManager.Instance != null)
            CurrencyManager.Instance.AddCoins(currentOrder.coinReward);

        if (LevelManager.Instance != null)
            LevelManager.Instance.AddExp(currentOrder.expReward);

        if (OrderManager.Instance != null)
            OrderManager.Instance.activeOrders.Remove(currentOrder);
        if (detailPanel != null)
            detailPanel.SetActive(false);

        currentOrder = null;

        RefreshUI();

        if (OrderPaperSpawner.Instance != null)
            OrderPaperSpawner.Instance.RefreshPapers();

        if (OrderManager.Instance != null && OrderManager.Instance.activeOrders.Count == 0)
            OrderManager.Instance.GenerateOrders();
    }
}