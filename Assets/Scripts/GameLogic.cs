using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    private List<int> gameNumbers = new List<int>();
    private GameObject instance;


    [SerializeField] private int gameLength;
    //[SerializeField] private GameObject gameMenu;
    [SerializeField] public GameObject selectionButtons;
    public Button[] buttons;


    // Start is called before the first frame update
    void Start()
    {
        buttons = selectionButtons.GetComponentsInChildren<Button>();
        CreateNumberList(gameNumbers, gameLength);
        GetNextQuestion();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetNextQuestion()
    {
        if (gameNumbers.Count > 0)
        {
            if (instance != null)
            {
                Destroy(instance);
            }
            int[] buttonValues = CreateButtonValues();
            ConfigureGameButtons(buttonValues);
            LoadQuestionPrefab(buttonValues[0]);
        }
        else
        {
            //end game
        }
    }

    //Creates a List of integers starting at 1 up to the defined number
    void CreateNumberList(List<int> list, int iterations)
    {
        for (int i = 1; i <= iterations; i++)
        {
            list.Add(i);
        }
    }

    void ConfigureGameButtons(int[] buttonValues)
    {
        int[] buttonOrder = RandomiseButtonOrder();
        for (int i = 0; i < 3; i++)
        {
            buttons[buttonOrder[i]].SetText(buttonValues[i].ToString());
        }
        buttons[buttonOrder[0]].tag = "Correct";

    }

    void LoadQuestionPrefab(int prefabNum)
    {
        instance = Instantiate(Resources.Load(prefabNum.ToString(), typeof(GameObject))) as GameObject;
    }

    int[] CreateButtonValues()
    {
        //get number from remaining list, set as correctNumber
        int correctNumber = gameNumbers[UnityEngine.Random.Range(0, gameNumbers.Count)];
        gameNumbers.Remove(correctNumber);

        //gets two incorrect numbers from the list
        List<int> remainingNumbers = new List<int>();
        CreateNumberList(remainingNumbers, gameLength);
        remainingNumbers.Remove(correctNumber);
        int incorrectNumber1 = remainingNumbers[UnityEngine.Random.Range(0, remainingNumbers.Count)];
        remainingNumbers.Remove(incorrectNumber1);
        int incorrectNumber2 = remainingNumbers[UnityEngine.Random.Range(0, remainingNumbers.Count)];

        int[] buttonValues = { correctNumber, incorrectNumber1, incorrectNumber2 };

        return buttonValues;
    }

    int[] RandomiseButtonOrder()
    {
        List<int> buttonOrder = new List<int>() { 0, 1, 2 };
        //CreateNumberList(buttonOrder, 3);
        int[] randomButtonOrder = new int[3];
        randomButtonOrder[0] = buttonOrder[UnityEngine.Random.Range(0, buttonOrder.Count)];
        buttonOrder.Remove(randomButtonOrder[0]);
        randomButtonOrder[1] = buttonOrder[UnityEngine.Random.Range(0, buttonOrder.Count)];
        buttonOrder.Remove(randomButtonOrder[1]);
        randomButtonOrder[2] = buttonOrder[0];
        Debug.Log("Button order" + randomButtonOrder.ToString());
        return randomButtonOrder;
    }

    void CheckCorrectChoice()
    {

    }

}
