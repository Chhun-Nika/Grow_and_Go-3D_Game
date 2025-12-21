using UnityEngine;

public class PlantSelectUI : MonoBehaviour
{
    public PlantLand currentLand;
    public GameObject tomatoPrefab;

    public void PlantTomato()
    {
        if (currentLand == null) return;

        if (!StorageManager.Instance.RemoveTomatoes(1))
        {
            Debug.Log("Not enough tomatoes to plant!");
            return; 
        }

        GameObject tomatoObj = Instantiate(
            tomatoPrefab,
            currentLand.plantPoint.position,
            currentLand.plantPoint.rotation
        );

        TomatoScript tomatoScript = tomatoObj.GetComponent<TomatoScript>();
        if (tomatoScript != null)
        {
            tomatoScript.plantedLand = currentLand;
            currentLand.plantedTomato = tomatoScript;

  
            currentLand.harvestTrigger.tomato = tomatoScript;
        }

        currentLand.isEmpty = false;
        currentLand.SetBlocked(true);
        gameObject.SetActive(false);
    }

}
