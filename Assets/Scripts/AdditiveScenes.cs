using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditiveScenes : MonoBehaviour
{
    [SerializeField, Tooltip("scenes to load at awake")]
    private List<string> listOfScenes = new();

    // Start is called before the first frame update
    void Awake()
    {
        // load other scenes based on the the listed
        foreach (string sceneName in listOfScenes)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
    }

    private void Start()
    {
        // hardcode to the first scene to be active
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(listOfScenes[0]));
    }
}
