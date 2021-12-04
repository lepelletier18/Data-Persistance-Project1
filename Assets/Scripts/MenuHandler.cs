using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuHandler : MonoBehaviour
{

    public TMP_Text bestScore;

    private void Awake()
    {
        
    }

    private void Start()
    {

        bestScore.text = "Best Score: " + GameManager.instance.BestScoreName + " " + GameManager.instance.BestScore;
    }

    private void Update()
    {
        
    }


    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        GameManager.instance.SavePlayerData();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
