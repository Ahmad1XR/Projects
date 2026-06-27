using UnityEngine;
using UnityEngine.SceneManagement;

public class TP : MonoBehaviour
{
    public string nextLevelName; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
         
            PlayerPrefs.SetString("NextLevel", "LoadingScene");

          
            SceneManager.LoadScene("LoadingScene");
        }
    }
}
