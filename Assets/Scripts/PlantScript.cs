using UnityEngine;

public class PlantLand : MonoBehaviour
{
    public bool isEmpty = true;
    public GameObject plantSelectUI;
    public Transform plantPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isEmpty)
        {
            PlantSelectUI ui = plantSelectUI.GetComponent<PlantSelectUI>();
            plantSelectUI.SetActive(true);
            ui.currentLand = this;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            plantSelectUI.SetActive(false);
        }
    }
}
