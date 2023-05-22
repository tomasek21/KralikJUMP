using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    private int jumps;
    private float distanceTraveled;
    private float highestScore;

    private static ScoreBoard instance;
    public static ScoreBoard Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        jumps = 0;
        distanceTraveled = 0f;
        highestScore = PlayerPrefs.GetFloat("HighestScore", 0f);
    }

    public void IncrementJumps()
    {
        jumps++;
    }

    public void UpdateDistanceTraveled(float distance)
    {
        distanceTraveled = Mathf.Max(distanceTraveled, distance);
    }

    public int GetJumps()
    {
        return jumps;
    }

    public float GetDistanceTraveled()
    {
        return distanceTraveled;
    }

    public float GetHighestScore()
    {
        return highestScore;
    }

    public void SaveHighestScore()
    {
        if (distanceTraveled > highestScore)
        {
            highestScore = distanceTraveled;
            PlayerPrefs.SetFloat("HighestScore", highestScore);
        }
    }
}
