using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// mainly to load the scenes
/// </summary>
public class GameSequence : MonoBehaviour
{
    [SerializeField, Tooltip("Death Scene to load upon death")]
    string death_scene;
    [SerializeField, Tooltip("Player")]
    GameObject player;
    [SerializeField, Tooltip("Canvas")]
    GameObject canvas;

    Coroutine loadSceneRoutine;

    /*IEnumerator LoadScene()
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
    }*/

    public void Load_Game()
    {
        //player.SetActive(false);
        canvas.SetActive(false);

        player.GetComponent<playerController>().enabled = true;
        player.GetComponent<SwingingArmMotion>().enabled = true;

        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionY;

        //SceneManager.LoadScene(main_game_scene, LoadSceneMode.Additive);
        /*loadSceneRoutine = StartCoroutine(LoadScene());
        // we wont be using async so that it will just be loaded immediately!
        foreach (var sceneName in sceneNames)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }*/
    }
}
