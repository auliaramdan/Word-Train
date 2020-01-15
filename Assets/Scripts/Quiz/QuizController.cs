using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizController : MonoBehaviour
{
    [SerializeField] private Toggle[] answerToggles = new Toggle[5];
    [SerializeField] private string[] wrongAnswers = new string[4];
    [SerializeField] private string correctAnswer;

    private Toggle correctAnswerToggle;
    private int[] shuffleIndex = { 0, 1, 2, 3, 4 };

    public Toggle CorrectAnswerToggle { get => correctAnswerToggle; set => correctAnswerToggle = value; }

    // Start is called before the first frame update
    void Start()
    {
        ShuffleAnswer(ref shuffleIndex);

        for (int i = 0; i < answerToggles.Length; i++)
        {
            Toggle temp = answerToggles[i];
            answerToggles[i] = answerToggles[shuffleIndex[i]];
            answerToggles[shuffleIndex[i]] = temp;
        }

        answerToggles[0].GetComponentInChildren<TextMeshProUGUI>().text = correctAnswer;
        correctAnswerToggle = answerToggles[0];
        for (int i = 1; i < answerToggles.Length; i++)
        {
            answerToggles[i].GetComponentInChildren<TextMeshProUGUI>().text = wrongAnswers[i-1];
        }
    }

    private void ShuffleAnswer(ref int[] array)
    {
        for (int i = 0; i < 5; i++)
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
}