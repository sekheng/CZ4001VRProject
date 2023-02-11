using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// mainly to load the scenes
/// </summary>
public class SceneLoader : MonoBehaviour
{
    [SerializeField, Tooltip("List of scenes to be loaded at Awake")]
    List<string> sceneNames = new List<string>();

    /// <summary>
    /// load the scenes at awake instead of start
    /// </summary>
    private void Awake()
    {
        // we wont be using async so that it will just be loaded immediately!
        foreach (var sceneName in sceneNames)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
    }
}
