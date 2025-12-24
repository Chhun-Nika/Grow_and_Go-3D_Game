using UnityEngine;

public class OrderPaper : MonoBehaviour
{
    public int orderIndex;

    void OnMouseDown()
    {
        if (OrderManager.Instance == null) return;

        if (orderIndex < OrderManager.Instance.activeOrders.Count)
        {
            var order = OrderManager.Instance.activeOrders[orderIndex];
            OrderUI.Instance.ShowDetail(order);
        }
    }
}
