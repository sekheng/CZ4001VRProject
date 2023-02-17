using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public delegate void FinishedEventDeli();
    public event FinishedEventDeli FinishEvent;

    public TMP_Text scoreText;
    public TMP_Text highscoreText;
    public TMP_Text deathText;

    int score = 0;
    int highscore = 0;
    int deaths = 0;

    Coroutine loadSceneRoutine;
    // finish unloading scene flag
    bool isUnloadedScene = true;

    private void Awake()
    {
        if (instance)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            ObserverSystem.Instance.SubscribeEvent(LoadingTransition.FinishedTweening, FinishLoadingScene);
        }
    }

    private void OnDestroy()
    {
        ObserverSystem.Instance.UnsubscribeEvent(LoadingTransition.FinishedTweening, FinishLoadingScene);
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
        if (loadSceneRoutine == null)
        {
            deaths += 1;
            deathText.text = "Deaths: " + deaths.ToString();
            loadSceneRoutine = StartCoroutine(LoadScene());
        }
    }

    public int GetScore()
    {
        return score;
    }

    void FinishLoadingScene()
    {
        isUnloadedScene = true;
    }

    IEnumerator LoadScene()
    {
        string deathSceneName = "Died";
        isUnloadedScene = false;
        // load the death scenes first!
        yield return SceneManager.LoadSceneAsync(deathSceneName, LoadSceneMode.Additive);
        string curMap = SceneManager.GetActiveScene().name;
        while (isUnloadedScene == false)
        {
            yield return null;
        }
        yield return SceneManager.UnloadSceneAsync(curMap, UnloadSceneOptions.None);
        yield return SceneManager.LoadSceneAsync(curMap, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(curMap));
        isUnloadedScene = false;
        // it should be done!
        FinishEvent?.Invoke();
        while (isUnloadedScene == false)
        {
            yield return null;
        }
        yield return SceneManager.UnloadSceneAsync(deathSceneName, UnloadSceneOptions.None);
        loadSceneRoutine = null;
    }

}
