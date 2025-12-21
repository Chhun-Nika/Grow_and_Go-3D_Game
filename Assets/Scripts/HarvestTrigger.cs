using UnityEngine;

public class HarvestTrigger : MonoBehaviour
{
	public TomatoScript tomato;

	private void OnTriggerStay(Collider other)
	{
		if (!other.CompareTag("Player")) return;

		if (tomato == null)
		{
			// Try to find the TomatoScript on the plants in this area (e.g., child or nearby)
			TomatoScript foundTomato = GetComponentInChildren<TomatoScript>();
			if (foundTomato != null)
				tomato = foundTomato;
		}

		if (Input.GetKeyDown(KeyCode.E) && tomato != null)
		{
			tomato.Harvest();
			tomato = null; // reset after harvesting
		}
	}
}
