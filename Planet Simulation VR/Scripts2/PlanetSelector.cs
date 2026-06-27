using UnityEngine;

public class PlanetSelector : MonoBehaviour
{
    public static PlanetSelector Instance;

    public string selectedSceneName;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectPlanet(string sceneName)
    {
        selectedSceneName = sceneName;
        Debug.Log("Selected: " + sceneName);
    }

}
