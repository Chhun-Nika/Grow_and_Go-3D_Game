using System.Collections;
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

            // Subscribe early in Awake
            if (OrderManager.Instance != null)
                OrderManager.Instance.OnOrdersUpdated += RefreshPapers;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Wait until activeOrders exist
        if (OrderManager.Instance != null && OrderManager.Instance.activeOrders.Count > 0)
        {
            RefreshPapers();
        }
        else
        {
            // Wait a frame and try again
            StartCoroutine(WaitAndRefresh());
        }
    }

    private IEnumerator WaitAndRefresh()
    {
        yield return new WaitForEndOfFrame(); // wait for OrderManager.Start()
        RefreshPapers();
    }


    void OnEnable()
    {
        if (OrderManager.Instance != null)
            OrderManager.Instance.OnOrdersUpdated += RefreshPapers;
    }

    void OnDisable()
    {
        if (OrderManager.Instance != null)
            OrderManager.Instance.OnOrdersUpdated -= RefreshPapers;
    }

    public void RefreshPapers()
    {
        ClearPapers();

        if (OrderManager.Instance == null || paperPrefab == null || spawnPoints == null)
            return;

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
