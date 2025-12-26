using UnityEngine;

public class FenceLockTrigger : MonoBehaviour
{
    public int requiredLevel = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (LevelManager.Instance.CurrentLevel < requiredLevel)
        {
            LockedLandUI.Instance.Show(requiredLevel);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        LockedLandUI.Instance.Hide();
    }
}
