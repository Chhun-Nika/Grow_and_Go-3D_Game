using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlyingIcon : MonoBehaviour
{
    public float duration = 1f;

    public void FlyTo(Vector3 startScreenPos, Vector3 targetScreenPos, Transform parent, System.Action onComplete = null)
    {
        gameObject.SetActive(true);
        transform.SetParent(parent, false);
        transform.position = startScreenPos;
        StartCoroutine(FlyRoutine(targetScreenPos, onComplete));
    }

    IEnumerator FlyRoutine(Vector3 targetPos, System.Action onComplete)
    {
        Vector3 startPos = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        onComplete?.Invoke();

        gameObject.SetActive(false);
    }
}
