using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    public ButtonPuzzle puzzle;  
    public string nextLevelName;  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (puzzle.IsCompleted()) 
            {
                Debug.Log("Level Complete! Loading next level...");
                SceneManager.LoadScene(nextLevelName);
            }
            else
            {
                Debug.Log("Puzzle not solved yet!");
            }
        }
    }
}
