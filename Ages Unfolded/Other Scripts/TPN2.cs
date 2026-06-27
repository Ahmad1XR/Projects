using UnityEngine;
using UnityEngine.SceneManagement;

public class TPN2 : MonoBehaviour
{
    public string nextLevelName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            PlayerPrefs.SetString("NextLevel", "Gamefinish");


            SceneManager.LoadScene("Gamefinish");
        }
    }
}
