using UnityEngine;

public class HologramDisable : MonoBehaviour
{
    public GameObject[] allPlanets;
    public GameObject selectedPlanet;

    public Transform centerPoint; 
    public Vector3 enlargedScale = new Vector3(2f, 2f, 2f); 

    public void SelectPlanet()
    {
        foreach (GameObject planet in allPlanets)
        {
            planet.SetActive(false);
        }

        if (selectedPlanet != null)
        {
            selectedPlanet.SetActive(true);

            selectedPlanet.transform.position = centerPoint.position;

            selectedPlanet.transform.localScale = enlargedScale;
        }
    }
}
