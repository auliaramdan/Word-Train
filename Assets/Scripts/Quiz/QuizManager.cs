using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private List<QuizController> controllers = new List<QuizController>();
    [SerializeField] private TextMeshProUGUI scoreHolder;
    [SerializeField] private GameObject scorePanel;

    private int score;
    
    public void CheckAnswer()
    {
        for (int i = 0; i < controllers.Count; i++)
        {
            if (controllers[i].CorrectAnswerToggle.isOn) score++;
        }
        scoreHolder.text = score.ToString();
        scorePanel.SetActive(true);
    }
}
