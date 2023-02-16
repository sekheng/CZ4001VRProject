using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public GameObject player;

    private void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.transform.parent.gameObject.tag);
        if (col.gameObject.transform.parent.gameObject.tag == "Vehicles")
        {
            //Debug.Log(col.gameObject.name);
            // Kill the player
            player.gameObject.SetActive(false);

            // Reload scene to reset game
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);


            //Do death update here
            ScoreManager.instance.AddDeaths(); //Add to death counter
        }
    }

    private void OnTriggerEnter(Collider trig)
    {
        if (trig.gameObject.tag == "Score Trigger")
        {
            //Debug.Log(trig.gameObject.name);
            trig.gameObject.SetActive(false);
            
            //Do score update here
            ScoreManager.instance.AddPoints();
        }
    }
}
