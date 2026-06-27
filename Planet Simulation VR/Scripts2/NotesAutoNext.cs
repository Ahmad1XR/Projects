using UnityEngine;

public class NotesAutoNext : MonoBehaviour
{
    void Start()
    {
        Invoke(nameof(LoadNext), 7f);
    }

    void LoadNext()
    {
        SceneTransitionManager.singleton.GoToScene(2);
    }
}