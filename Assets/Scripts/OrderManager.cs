using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance;

    public List<OrderData> activeOrders = new();
    public int maxOrders = 5;

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

        int orderCount = Random.Range(1, maxOrders + 1);

        for (int i = 0; i < orderCount; i++)
        {
            OrderData o = new OrderData
            {
                orderId = i + 1,
                tomatoAmount = Random.Range(1, 4),
                cornAmount = Random.Range(0, 3),
                expReward = Random.Range(3, 8)
            };

            activeOrders.Add(o);
        }

      
        if (OrderPaperSpawner.Instance != null)
            OrderPaperSpawner.Instance.RefreshPapers();

        if (OrderUI.Instance != null)
            OrderUI.Instance.RefreshUI();
    }

}
