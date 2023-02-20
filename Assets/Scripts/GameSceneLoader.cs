using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// mainly to load the scenes
/// </summary>
public class GameSceneLoader : MonoBehaviour
{
    [SerializeField, Tooltip("List of side scenes to be loaded at Awake")]
    List<string> sceneNames = new List<string>();
    [SerializeField, Tooltip("Main Game Scene to load at Awake")]
    string main_game_scene;

    Coroutine loadSceneRoutine;

    /// <summary>
    /// load the scenes at awake instead of start
    /// </summary>
    private void Awake()
    {
        //SceneManager.LoadScene(main_game_scene, LoadSceneMode.Additive);
        loadSceneRoutine = StartCoroutine(LoadScene());
        // we wont be using async so that it will just be loaded immediately!
        foreach (var sceneName in sceneNames)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
    }

    IEnumerator LoadScene()
    {
        // load the death scenes first!
        var asyncLoadLevel =  SceneManager.LoadSceneAsync(main_game_scene, LoadSceneMode.Additive);
        while (!asyncLoadLevel.isDone)
        {
            Debug.Log("Loading the Scene");
            yield return null;
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(main_game_scene));
        loadSceneRoutine = null;
    }
}
