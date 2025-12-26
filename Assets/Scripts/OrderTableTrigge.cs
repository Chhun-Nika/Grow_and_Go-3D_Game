using UnityEngine;

public class OrderTableTrigger : MonoBehaviour
{
    public GameObject orderUIPanel;

    private void Start()
    {
        orderUIPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Debug.Log("Player entered order table");
        orderUIPanel.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Debug.Log("Player left order table");
        orderUIPanel.SetActive(false);
    }
}
