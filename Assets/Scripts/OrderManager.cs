//using System.Collections.Generic;
//using UnityEngine;

//public class OrderManager : MonoBehaviour
//{
//    public static OrderManager Instance;

//    public List<OrderData> activeOrders = new();
//    public int maxOrders = 5;

//    void Awake()
//    {
//        if (Instance == null)
//            Instance = this;
//        else
//            Destroy(gameObject);
//    }

//    void Start()
//    {
//        GenerateOrders();
//    }

//    public void GenerateOrders()
//    {
//        activeOrders.Clear();

//        for (int i = 0; i < 3; i++)
//        {
//            OrderData order = new OrderData();
//            order.orderId = i + 1;

//            order.tomatoAmount = Random.Range(1, 4);
//            order.cornAmount = Random.Range(1, 3);

//            order.coinReward = order.tomatoAmount * 5 + order.cornAmount * 8;
//            order.expReward = 3 + order.tomatoAmount + order.cornAmount;

//            activeOrders.Add(order);
//        }

//        OrderUI.Instance.RefreshUI();
//    }


//}

using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance;

    public List<OrderData> activeOrders = new();
    public int maxOrders = 5;

    // Event to notify listeners when orders change
    public delegate void OrdersUpdated();
    public event OrdersUpdated OnOrdersUpdated;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        GenerateOrders();
    }

    public void GenerateOrders()
    {
        activeOrders.Clear();

        for (int i = 0; i < 3; i++)
        {
            OrderData order = new OrderData();
            order.orderId = i + 1;
            order.tomatoAmount = Random.Range(1, 4);
            order.cornAmount = Random.Range(1, 3);
            order.coinReward = order.tomatoAmount * 5 + order.cornAmount * 8;
            order.expReward = 3 + order.tomatoAmount + order.cornAmount;

            activeOrders.Add(order);
        }

        // Update UI and papers automatically
        if (OrderUI.Instance != null)
            OrderUI.Instance.RefreshUI();

        OnOrdersUpdated?.Invoke();
    }

    public void CompleteOrder(OrderData order)
    {
        if (!activeOrders.Contains(order)) return;

        activeOrders.Remove(order);

        // Refresh UI and papers
        if (OrderUI.Instance != null)
            OrderUI.Instance.RefreshUI();

        OnOrdersUpdated?.Invoke();

        // If no orders left, generate new ones
        if (activeOrders.Count == 0)
            GenerateOrders();
    }
}