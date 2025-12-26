using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StorageUI : MonoBehaviour
{
    public TMP_Text tomatoCountText;
    public TMP_Text cornCountText;

    void Update()
    {
        // Update tomato count text every frame (or could be optimized)
        int count = StorageManager.Instance.GetTomatoCount();
        tomatoCountText.text = "" + count;

        int countCorn = StorageManager.Instance.GetCornCount();
        cornCountText.text = "" + countCorn;
    }
}
