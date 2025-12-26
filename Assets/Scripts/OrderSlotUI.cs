using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OrderSlotUI : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text tomatoText;
    [SerializeField] private TMP_Text cornText;
    [SerializeField] private Button button;

    private OrderData order;

    void Awake()
    {
        // Fallback: auto-find UI elements if missing
        if (titleText == null)
            titleText = transform.Find("TitleText")?.GetComponent<TMP_Text>();
        if (tomatoText == null)
            tomatoText = transform.Find("TomatoText")?.GetComponent<TMP_Text>();
        if (cornText == null)
            cornText = transform.Find("CornText")?.GetComponent<TMP_Text>();
        if (button == null)
            button = GetComponentInChildren<Button>(true);

        // Debug missing references
        if (!titleText || !tomatoText || !cornText || !button)
            Debug.LogError("OrderSlotUI: UI references missing!", this);
    }

    public void SetOrder(OrderData data)
    {
        if (data == null || titleText == null || tomatoText == null || cornText == null || button == null)
            return;

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
        gameObject.SetActive(false);
    }

    public void OnClickDetail()
    {
        if (order == null) return;
        if (OrderUI.Instance == null)
        {
            Debug.LogError("OrderUI.Instance is null!");
            return;
        }
        OrderUI.Instance.ShowDetail(order);
    }
}