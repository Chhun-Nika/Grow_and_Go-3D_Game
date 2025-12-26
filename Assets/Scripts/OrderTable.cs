//using UnityEngine;

//public class OrderTable : MonoBehaviour
//{
//    public GameObject[] orderPapers; // Assign in inspector
//    public GameObject orderUI;       // Assign UI panel GameObject

//    private OrderUI orderUIScript;

//    private void Start()
//    {
//        if (orderUI != null)
//            orderUIScript = orderUI.GetComponent<OrderUI>();

//        UpdatePapers();
//    }

//    // Enable order papers according to how many active orders exist
//    public void UpdatePapers()
//    {
//        if (OrderManager.Instance == null)
//        {
//            Debug.LogError("OrderManager.Instance is null");
//            return;
//        }

//        var orders = OrderManager.Instance.activeOrders;
//        int orderCount = orders.Count;

//        for (int i = 0; i < orderPapers.Length; i++)
//        {
//            bool shouldShow = i < orderCount;
//            orderPapers[i].SetActive(shouldShow);

//            if (shouldShow)
//            {
//                // Assign orderData and orderUI to OrderButton on the paper
//                var orderButton = orderPapers[i].GetComponent<OrderButton>();
//                if (orderButton != null)
//                {
//                    orderButton.orderData = orders[i];
//                    orderButton.orderUI = orderUIScript;
//                }
//            }
//        }
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (!other.CompareTag("Player")) return;

//        if (orderUI != null)
//            orderUI.SetActive(true);

//        if (orderUIScript != null)
//            orderUIScript.ShowOrders();
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (!other.CompareTag("Player")) return;

//        if (orderUI != null)
//            orderUI.SetActive(false);
//    }
//}
