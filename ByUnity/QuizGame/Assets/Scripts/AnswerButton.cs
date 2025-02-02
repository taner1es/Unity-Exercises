﻿using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public Text answerText;

    public AnswerData answerData;
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void Setup(AnswerData data)
    {
        answerData = data;
        answerText.text = answerData.answerText;
    }

    public void HandleClick()
    {
        gameController.AnswerButtonClicked(answerData.isCorrect);
    }
}
