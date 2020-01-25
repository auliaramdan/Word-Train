using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private List<Questions> questionList = new List<Questions>();
    [SerializeField] private QuizController controller;
    [SerializeField] private TextMeshProUGUI scoreHolder;
    [SerializeField] private GameObject scorePanel;

    private int score = 0;
    private int questionIndex = 0;

    private void Start() {
        controller.SetQuestion(questionList[0], questionIndex + 1);
    }
    
    public void CheckAnswer()
    {
        if (controller.CorrectAnswerToggle.isOn) score++;
        questionIndex++;
        StartCoroutine(NextQuestion());
        
        //scoreHolder.text = score.ToString();
        //scorePanel.SetActive(true);
    }

    private IEnumerator NextQuestion() {
        controller.RevealAnswer();
        yield return new WaitForSeconds(1);
        if(questionIndex < questionList.Count) {
            controller.SetQuestion(questionList[questionIndex], questionIndex + 1);
        } else {
            scoreHolder.text = score.ToString();
            scorePanel.SetActive(true);
        }
    }
}
