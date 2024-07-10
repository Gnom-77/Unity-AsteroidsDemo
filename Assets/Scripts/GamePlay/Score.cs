using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameManager gameManager;


    void Update()
    {
        scoreText.text = "Score: " + gameManager.score;
    }
}
