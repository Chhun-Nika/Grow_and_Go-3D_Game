using UnityEngine;

public class PlantSelectUI : MonoBehaviour
{
    public PlantLand currentLand;
    public GameObject tomatoPrefab;

    public void PlantTomato()
    {
        if (currentLand == null) return;
        Instantiate(
            tomatoPrefab,
            currentLand.plantPoint.position,
            currentLand.plantPoint.rotation
         );
        currentLand.isEmpty = false;
        gameObject.SetActive(false);
    }

    public void Cancel()
    {
        gameObject.SetActive(false);
    }
}
