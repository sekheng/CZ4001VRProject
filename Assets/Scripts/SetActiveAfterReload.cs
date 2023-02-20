using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveAfterReload : MonoBehaviour
{
    [SerializeField, Tooltip("Set the list of gameobjects to be active after the score manager event")]
    List<GameObject> setGOActive = new();

    private void Start()
    {
        ScoreManager.instance.FinishEvent += SetGOActive;
    }

    private void OnDestroy()
    {
        ScoreManager.instance.FinishEvent -= SetGOActive;
    }

    void SetGOActive()
    {
        foreach (GameObject go in setGOActive)
        {
            go.SetActive(true);
        }
    }
}
