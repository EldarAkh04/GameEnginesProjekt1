using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Der Ordner (Namespace)

public class MenuManager : MonoBehaviour
{
    public void OnStartClick()
    {
        // KORREKTUR: Verwenden Sie die Klasse SceneManager.
        SceneManager.LoadScene("SampleScene"); 
    }

    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}