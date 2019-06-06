using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int score;
   
    private Board board;
    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Board>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        if(score >= 500)
        {
            scoreText.text = "You Win!";
        }
    }
    public void IncreaseScore(int increase)
    {
        score += increase;
    }


}
