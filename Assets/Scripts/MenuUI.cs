using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public InputField nameInput;
    public TextMeshProUGUI bestScoreInformation;

    private void Start()
    {

        if(GameManager.Instance.saveData.bestPlayer != null)
        {
            bestScoreInformation.text = $"Best Score : {GameManager.Instance.saveData.bestPlayer} - {GameManager.Instance.saveData.bestScore}";
        }

    }

    public void UpdateName()
    {
        GameManager.Instance.saveData.currentUser = nameInput.textComponent.text;
    }

    public void StartButton()
    {
        // Load main scene
        GameManager.Instance.Save();
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        // Exit Application
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ScoreButton()
    {
        SceneManager.LoadScene(2);
    }
}
