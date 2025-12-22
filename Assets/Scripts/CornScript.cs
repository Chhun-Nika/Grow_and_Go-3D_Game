using System.Collections;
using UnityEngine;

public class CornScript : MonoBehaviour
{
    public GameObject[] growthStages;
    public float[] stageTimes;

    private GameObject currentStage;
    private int currentIndex = 0;

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

        currentStage = Instantiate(
            growthStages[index],
            transform.position,
            Quaternion.identity,
            transform
        );
    }

    IEnumerator GrowRoutine()
    {
        while (currentIndex < growthStages.Length - 1)
        {
            yield return new WaitForSeconds(stageTimes[currentIndex] * 60f);

            currentIndex++;
            SpawnStage(currentIndex);
        }
    }

    public void Harvest()
    {
        if (currentIndex != growthStages.Length - 1)
            return;

        if (StorageManager.Instance != null)
            StorageManager.Instance.AddCorn(3);   

        if (LevelManager.Instance != null)
            LevelManager.Instance.AddExp(5);

        if (UIManager.Instance != null)
            UIManager.Instance.PlayStarFlyEffect(transform.position);

        if (plantedLand != null)
        {
            plantedLand.isEmpty = true;
            plantedLand.SetBlocked(false);

            if (plantedLand.harvestTrigger != null)
                plantedLand.harvestTrigger.corn = null;
        }

        StopAllCoroutines();
        Destroy(gameObject);
    }
}
