using UnityEngine;

public class HarvestTrigger : MonoBehaviour
{
    public TomatoScript tomato;
    public CornScript corn;

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (tomato == null)
        {
            TomatoScript foundTomato = GetComponentInChildren<TomatoScript>();
            if (foundTomato != null)
                tomato = foundTomato;
        }

        if (corn == null)
        {
            CornScript foundCorn = GetComponentInChildren<CornScript>();
            if (foundCorn != null)
                corn = foundCorn;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (tomato != null)
            {
                tomato.Harvest();
                tomato = null;
            }
            else if (corn != null)
            {
                corn.Harvest();
                corn = null;
            }
        }
    }
}
