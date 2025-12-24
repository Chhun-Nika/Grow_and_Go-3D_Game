using UnityEngine;

public class OrderPaperSpawner : MonoBehaviour
{
    public static OrderPaperSpawner Instance;

    public GameObject paperPrefab;
    public Transform[] spawnPoints;

    private GameObject[] papers;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            papers = new GameObject[spawnPoints.Length];
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RefreshPapers()
    {
        ClearPapers();

        if (OrderManager.Instance == null)
        {
            Debug.LogWarning("OrderManager.Instance is null in RefreshPapers");
            return;
        }

        int count = OrderManager.Instance.activeOrders.Count;

        for (int i = 0; i < count && i < spawnPoints.Length; i++)
        {
            papers[i] = Instantiate(
                paperPrefab,
                spawnPoints[i].position,
                spawnPoints[i].rotation,
                spawnPoints[i]
            );

            var orderPaper = papers[i].GetComponent<OrderPaper>();
            if (orderPaper != null)
                orderPaper.orderIndex = i;
            else
                Debug.LogWarning("Paper prefab missing OrderPaper script");
        }
    }

    void ClearPapers()
    {
        if (papers == null) return;

        for (int i = 0; i < papers.Length; i++)
        {
            if (papers[i] != null)
                Destroy(papers[i]);
            papers[i] = null;
        }
    }
}
