using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 
using System.Collections;

public class LoadingManager1 : MonoBehaviour
{
    public GameObject tipTextObject; 
    public string[] tips;

    private TMP_Text tipText;
    private string sceneToLoad = "LVL 2";

    void Start()
    {
      
        sceneToLoad = PlayerPrefs.GetString("NextLevel", "LVL 2");

        if (tipTextObject != null)
            tipText = tipTextObject.GetComponent<TMP_Text>();

        if (tips.Length > 0 && tipText != null)
        {
            int index = Random.Range(0, tips.Length);
            tipText.text = tips[index];
        }

        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("LVL 2"); 
        operation.allowSceneActivation = false;

        float minimumTime = 5f;
        float timer = 0f;

        while (!operation.isDone)
        {
            timer += Time.deltaTime;

            if (operation.progress >= 0.9f && timer >= minimumTime)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

}
