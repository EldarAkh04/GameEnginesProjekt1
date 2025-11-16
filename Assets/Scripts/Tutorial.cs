using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public static Tutorial instance;

    public GameObject tutorialPanel;
    public static bool isVisible;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        tutorialPanel.SetActive(false);
    }
    public void ShowTutorial() 
    {
        tutorialPanel.SetActive(true);
    }

    public void LeaveTuorial()
    {
        tutorialPanel.SetActive(false);
        //SceneManager.LoadScene("StarMenu");
    }
}