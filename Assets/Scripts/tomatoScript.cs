using System.Collections;
using UnityEngine;

public class TomatoScript : MonoBehaviour
{
    public GameObject[] growthStages;
    public float[] stageTimes;

    private GameObject currentStage;
    private int currentIndex = 0;

    // Reference to the land this tomato is planted on
    public PlantLand plantedLand;

    void Start()
    {
        SpawnStage(0);
        StartCoroutine(GrowRoutine());
    }

    void SpawnStage(int index)
    {
        if (currentStage != null)
            Destroy(currentStage);

        currentStage = Instantiate(growthStages[index], transform.position, Quaternion.identity, transform);
    }

    IEnumerator GrowRoutine()
    {
        while (currentIndex < growthStages.Length - 1)
        {
            float waitTime = stageTimes[currentIndex] * 60f;
            yield return new WaitForSeconds(waitTime);

            currentIndex++;
            SpawnStage(currentIndex);
        }

        Debug.Log("Tomato fully grown! Ready to harvest.");
    }

    public void Harvest()
    {
        if (currentIndex != growthStages.Length - 1)
        {
            Debug.Log("Tomato is not fully grown yet.");
            return;
        }

        int harvestAmount = 2;

        if (StorageManager.Instance != null)
            StorageManager.Instance.AddTomatoes(harvestAmount);

        if (LevelManager.Instance != null)
            LevelManager.Instance.AddExp(3);

        if (UIManager.Instance != null)
        {
            UIManager.Instance.PlayStarFlyEffect(transform.position);
        }

        if (plantedLand != null)
        {
            plantedLand.plantedTomato = null;
            plantedLand.isEmpty = true;
            plantedLand.SetBlocked(false);

            if (plantedLand.harvestTrigger != null)
                plantedLand.harvestTrigger.tomato = null;
        }

        StopAllCoroutines();
        Destroy(gameObject);
    }

}
