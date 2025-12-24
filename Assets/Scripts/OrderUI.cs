using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class OrderUI : MonoBehaviour
{
    public static OrderUI Instance;

    [Header("Order Slots")]
    public List<OrderSlotUI> orderSlots;

    [Header("Detail Panel")]
    public GameObject detailPanel;
    public TMP_Text titleText;
    public TMP_Text tomatoText;
    public TMP_Text cornText;

    private OrderData currentOrder;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        // Optional: hide detail panel at start
        detailPanel.SetActive(false);
        // Optionally, hide whole OrderUI panel if you want to toggle later
        // gameObject.SetActive(false);
    }

    public void Open(int selectedIndex)
    {
        gameObject.SetActive(true);
        RefreshUI();
    }

    public void Cancel()
    {
        if (currentOrder == null) return;

        // Remove the current order without selling
        OrderManager.Instance.activeOrders.Remove(currentOrder);

        // Close the detail and main panel
        detailPanel.SetActive(false);
        gameObject.SetActive(false);

        // Refresh UI and papers
        RefreshUI();
        if (OrderPaperSpawner.Instance != null)
            OrderPaperSpawner.Instance.RefreshPapers();

        // Clear currentOrder reference
        currentOrder = null;

        // If no orders left, generate new ones
        if (OrderManager.Instance.activeOrders.Count == 0)
        {
            OrderManager.Instance.GenerateOrders();
        }
    }

    public void RefreshUI()
    {
        if (OrderManager.Instance == null)
        {
            Debug.LogWarning("OrderManager.Instance is null in OrderUI.RefreshUI");
            return;
        }

        var orders = OrderManager.Instance.activeOrders;

        for (int i = 0; i < orderSlots.Count; i++)
        {
            if (i < orders.Count)
                orderSlots[i].SetOrder(orders[i]);
            else
                orderSlots[i].Clear();
        }
    }

    public void ShowDetail(OrderData order)
    {
        currentOrder = order;
        detailPanel.SetActive(true);

        titleText.text = "Order #" + order.orderId;
        tomatoText.text = "Tomato: " + order.tomatoAmount;
        cornText.text = "Corn: " + order.cornAmount;
    }

    public void Sell()
    {
        if (currentOrder == null) return;

        // Check storage
        if (!StorageManager.Instance.HasEnoughForOrder(currentOrder))
        {
            Debug.Log("Not enough items in storage");
            return;
        }

        // Deduct storage
        StorageManager.Instance.DeductForOrder(currentOrder);

        // Remove order
        OrderManager.Instance.activeOrders.Remove(currentOrder);

        // Close detail panel
        detailPanel.SetActive(false);

        // Refresh UI & papers
        RefreshUI();
        if (OrderPaperSpawner.Instance != null)
            OrderPaperSpawner.Instance.RefreshPapers();

        // Check if all orders are completed
        if (OrderManager.Instance.activeOrders.Count == 0)
        {
            // Generate new orders
            OrderManager.Instance.GenerateOrders();
        }
    }


}
