using UnityEngine;

public class PlantLand : MonoBehaviour
{
    public bool isEmpty = true;
    public GameObject plantSelectUI;
    public Transform plantPoint;
    public HarvestTrigger harvestTrigger;

    public Collider landTrigger;   // UI trigger
    public Collider blockingCollider; // solid blocker

    [HideInInspector]
    public TomatoScript plantedTomato;
    [HideInInspector]
    public CornScript plantedCorn;

    void Start()
    {
        landTrigger.enabled = true;
        blockingCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isEmpty) return;

        if (other.CompareTag("Player"))
        {
            PlantSelectUI ui = plantSelectUI.GetComponent<PlantSelectUI>();
            ui.currentLand = this;
            plantSelectUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            plantSelectUI.SetActive(false);
        }
    }

    public void SetBlocked(bool blocked)
    {
        blockingCollider.enabled = blocked;
        landTrigger.enabled = !blocked;
    }
}
