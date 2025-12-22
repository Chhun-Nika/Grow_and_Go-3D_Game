using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StorageUI : MonoBehaviour
{
    public TMP_Text tomatoCountText; 

    void Update()
    {
        // Update tomato count text every frame (or could be optimized)
        int count = StorageManager.Instance.GetTomatoCount();
        tomatoCountText.text = "" + count;
    }
}
