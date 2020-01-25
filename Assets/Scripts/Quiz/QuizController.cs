using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizController : MonoBehaviour
{
    [SerializeField] private Toggle[] answerToggles = new Toggle[4];
    [SerializeField] private TextMeshProUGUI questionHolder;
    [SerializeField] private Questions question;

    private Toggle correctAnswerToggle;
    private int[] shuffleIndex = { 0, 1, 2, 3};

    public Toggle CorrectAnswerToggle { get => correctAnswerToggle;}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void ShuffleAnswer(ref int[] array)
    {
        for (int i = 0; i < 4; i++)
        {
            Swap(ref array[i], ref array[Random.Range(0, array.Length - 2)]);
        }
    }

    private void Swap(ref int data1, ref int data2)
    {
        int t = data1;
        data1 = data2;
        data2 = t;
    }

    public void SetQuestion(Questions _question, int currentIndex) {
        question = _question;
        StartQuestion(currentIndex);
    }

    private void StartQuestion(int currentIndex) {
        questionHolder.text = currentIndex + ".<indent=6%>" + question.question + "</indent>";

        ShuffleAnswer(ref shuffleIndex);

        for (int i = 0; i < answerToggles.Length; i++)
        {
            answerToggles[i].isOn = false;
            Toggle temp = answerToggles[i];
            answerToggles[i] = answerToggles[shuffleIndex[i]];
            answerToggles[shuffleIndex[i]] = temp;
        }

        answerToggles[0].GetComponentInChildren<TextMeshProUGUI>().text = question.correctAnswer;
        correctAnswerToggle = answerToggles[0];
        for (int i = 1; i < answerToggles.Length; i++)
        {
            answerToggles[i].GetComponentInChildren<TextMeshProUGUI>().text = question.wrongAnswers[i-1];
        }
    }

    public void RevealAnswer() {
        for (int i = 0; i < answerToggles.Length; i++)
        {
            if(answerToggles[i] == correctAnswerToggle) continue;
            answerToggles[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
        }
    }
}