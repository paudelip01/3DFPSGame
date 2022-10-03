using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalScore : MonoBehaviour
{

    public static int CurrentScore;
    public int InternalScore;
    public GameObject ScoreText;
    public GameObject FinalText;

    void Update()
    {
        InternalScore = CurrentScore;
        ScoreText.GetComponent<Text>().text = "" + InternalScore;
        FinalText.GetComponent<Text>().text = "" + InternalScore;
    }
}