using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        if (GameManager.Instance.saveData != null && GameManager.Instance.saveData.lstScore != null)
        {
            List<Score> listScore = GameManager.Instance.saveData.lstScore;
            string formatedText = "";
            int i = 1;
            foreach (Score s in listScore.OrderByDescending(a => a.score))
            {
                formatedText += $"{i}. \t {s.score} \t {s.player} \t\t {s.date}\n";
                i++;
            }
            scoreText.text = formatedText;
        }
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
