using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TMP_Text scoreText;
    public TMP_Text highscoreText;
    public TMP_Text deathText;

    int score = 0;
    int highscore = 0;
    int deaths = 0;

    private void Awake()
    {
        if (instance)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        highscoreText.text = "High Score: " + highscore.ToString();
        scoreText.text = "Current Score: " + score.ToString();
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
        deathText.text = "Deaths: " + deaths.ToString();
        StartCoroutine(LoadScene());

    }

    public int GetScore()
    {
        return score;
    }
    IEnumerator LoadScene()
    {
        string curMap = SceneManager.GetActiveScene().name;
        yield return SceneManager.UnloadSceneAsync(curMap, UnloadSceneOptions.None);
        yield return SceneManager.LoadSceneAsync(curMap, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(curMap));
        // it should be done!
    }

}
