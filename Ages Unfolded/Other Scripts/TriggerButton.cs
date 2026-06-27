using UnityEngine;

public class TriggerButton : MonoBehaviour
{
    public ButtonPuzzle puzzle;
    public int buttonNumber;
    public AudioSource pushBS;
    private bool playerOnButton = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnButton = true; 
          
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnButton = false; 
            
        }
    }

    private void Update()
    {
        if (playerOnButton && Input.GetKeyDown(KeyCode.E)) 
        {
            puzzle.PressButton(buttonNumber);
            pushBS.Play();
            
        }
    }
}
   
