using UnityEngine;

public class StorageTrigger : MonoBehaviour
{
    public GameObject storageUIPanel; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            storageUIPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            storageUIPanel.SetActive(false);
        }
    }
}
