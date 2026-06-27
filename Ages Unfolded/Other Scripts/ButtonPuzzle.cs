using UnityEngine;

public class ButtonPuzzle : MonoBehaviour
{
    public GameObject[] buttons;  
    public GameObject door;     
    private int currentStep = 0;
    public AudioSource wrongeS;
    public AudioSource correctS;
    public AudioSource openMdoor;
    public void PressButton(int buttonNumber)
    {
        if (buttonNumber == currentStep)
        {
            Debug.Log("Correct button: " + buttons[buttonNumber].name);
            currentStep++;
            buttons[buttonNumber].GetComponent<SpriteRenderer>().color = Color.green;
            correctS.Play();

            if (currentStep >= buttons.Length)
                openMdoor.Play();
                OpenDoor();
        }
        else
        {
      
            Debug.Log("Wrong button! Resetting puzzle...");
            ResetPuzzle();
            wrongeS.Play();
        }
    }

    void OpenDoor()
    {
        Debug.Log("Door opened!");
        
    }

    void ResetPuzzle()
    {
        currentStep = 0;
        foreach (GameObject btn in buttons)
            btn.GetComponent<SpriteRenderer>().color = Color.white;
        wrongeS.Play();
    }
    public bool IsCompleted()
    {
        return currentStep >= buttons.Length;
    }
}
