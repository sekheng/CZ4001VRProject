using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// to go back to player's original position when they died
/// </summary>
public class PlayerStartPos : MonoBehaviour
{
    [Header("Debugging Purpose")]
    [SerializeField, Tooltip("Player initial Position")]
    Vector3 playerInitialPos;
    Quaternion playerInitialRot;

    static PlayerStartPos instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        ScoreManager.instance.FinishEvent += SceneFinishedLoading;
    }

    private void OnDisable()
    {
        ScoreManager.instance.FinishEvent -= SceneFinishedLoading;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerInitialPos = transform.position;
        playerInitialRot = transform.rotation;
    }

    // Update is called once per frame
    void SceneFinishedLoading()
    {
        transform.position = playerInitialPos;
        transform.rotation = playerInitialRot;
    }
}
