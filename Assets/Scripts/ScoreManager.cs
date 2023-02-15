using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text highscoreText;
    public Text deathText;

    int score = 0;
    int highscore = 0;
    int deaths = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "Current score: " + score.ToString();
        highscoreText.text = "High score: " + highscore.ToString();
        deathText.text = "Deaths: " + deaths.ToString();
    }

    // Call this method to add points to player
    public void AddPoints()
    {
        score += 1;
        scoreText.text = "Current score: " + score.ToString();

        // Update high score
        if (highscore < score)
            PlayerPrefs.SetInt("highscore", score);

    }

    public void AddDeaths()
    {
        deaths += 1;
        deathText = "Deaths: " + deaths.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
