using UnityEngine;

public class ShopArea : MonoBehaviour
{
    public GameObject shopUI; // ShopPopup Canvas

    void Start()
    {
        shopUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        shopUI.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        shopUI.SetActive(false);
    }
}
