using System.Collections;
using UnityEngine;

public class TomatoScript : MonoBehaviour
{
    public GameObject[] growthStages;   // 4 prefabs: stage 1 ? stage 4
    public float[] stageTimes;          // Times for each stage change in minutes

    private GameObject currentStage;
    private int currentIndex = 0;

    void Start()
    {
        // Start with stage 1
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
            // Convert minutes to seconds
            float waitTime = stageTimes[currentIndex] * 60f;

            yield return new WaitForSeconds(waitTime);

            currentIndex++;
            SpawnStage(currentIndex);
        }

        Debug.Log("Tomato fully grown! Ready to harvest.");
    }
}
