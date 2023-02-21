using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

/// <summary>
/// mainly to load the scenes
/// </summary>
public class GameSequence : MonoBehaviour
{
    [SerializeField, Tooltip("Player")]
    Player player;
    [SerializeField, Tooltip("Canvas")]
    GameObject canvas;

    public void Start_Game()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }
        //player.SetActive(false);
        canvas.SetActive(false);

        //player.GetComponent<playerController>().enabled = true;
        player.GetComponent<SwingingArmMotion>().enabled = true;

        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionY;
    }
}
