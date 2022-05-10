using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    void Awake() 
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        scoreText.text = "You Scored:\n" + scoreKeeper.GetScore();
    }
    //Singleton Scorekeeper 4:46 I have everything I need here but it's not working out.
    // getting a "null reference exception"


}
