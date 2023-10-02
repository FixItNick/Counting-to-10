using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;




public class Button : MonoBehaviour
{
    public TMP_Text buttonText;
    public GameObject gameLogic;

    public void SetText(string answerText)
    {
        buttonText.text = answerText;
    }

    public void IsCorrect()
    {
        if (tag.Contains("Correct"))
        {
            gameLogic.GetComponent<GameLogic>().GetNextQuestion();
        }
    }

}
