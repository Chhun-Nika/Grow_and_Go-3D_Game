using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OrderSlotUI : MonoBehaviour
{
    public TMP_Text titleText;
    public TMP_Text tomatoText;
    public TMP_Text cornText;

    private OrderData order;
    private Button button;

    void Awake()
    {
        button = GetComponentInChildren<Button>();

        if (button == null)
            Debug.LogError("OrderSlotUI: Button not found!");
    }

    public void SetOrder(OrderData data)
    {
        Debug.Log($"titleText is {(titleText == null ? "NULL" : "OK")}");
        Debug.Log($"tomatoText is {(tomatoText == null ? "NULL" : "OK")}");
        Debug.Log($"cornText is {(cornText == null ? "NULL" : "OK")}");

        order = data;

        titleText.text = "Order #" + data.orderId;
        tomatoText.text = "Tomato: " + data.tomatoAmount;
        cornText.text = "Corn: " + data.cornAmount;

        gameObject.SetActive(true);
        button.interactable = true;
    }


    public void Clear()
    {
        order = null;
        gameObject.SetActive(false);  // hide empty slot
    }

    // Button OnClick → OrderSlotUI.OnClickDetail
    public void OnClickDetail()
    {
        if (order == null) return;

        OrderUI.Instance.ShowDetail(order);
    }
}
