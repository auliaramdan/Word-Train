using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Question", order = 1)]
public class Questions : ScriptableObject
{
    [TextArea(0, 10)]
    public string question;
    [TextArea(0, 10)]
    public string[] wrongAnswers = new string[3];
    [TextArea(0, 10)]
    public string correctAnswer;
}
