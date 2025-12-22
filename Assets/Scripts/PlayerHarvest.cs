using UnityEngine;

public class PlayerHarvest : MonoBehaviour
{
    private TomatoScript nearbyTomato;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tomato"))
        {
            nearbyTomato = other.GetComponent<TomatoScript>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tomato"))
        {
            if (nearbyTomato != null && other.gameObject == nearbyTomato.gameObject)
            {
                nearbyTomato = null;
            }
        }
    }

    void Update()
    {
        if (nearbyTomato != null)
        {
            if (Input.GetKeyDown(KeyCode.E)) // Press E to harvest
            {
                nearbyTomato.Harvest();
                nearbyTomato = null;
            }
        }
    }
}
