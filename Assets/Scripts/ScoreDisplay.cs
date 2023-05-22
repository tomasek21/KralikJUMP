using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Text currentScoreText;
    public Text highestScoreText;

    private void Update()
    {
        int currentScore = ScoreBoard.Instance.GetJumps();
        float currentDistance = ScoreBoard.Instance.GetDistanceTraveled();
        float highestScore = ScoreBoard.Instance.GetHighestScore();

        currentScoreText.text = "Score: " + currentScore.ToString();
        highestScoreText.text = "Highest Score: " + highestScore.ToString("F2");
    }
}
