using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject player;
    public Rigidbody player_rigidbody;
    public AudioSource score_trigger_sound;

    private void OnCollisionEnter(Collision col)
    {
        //Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Vehicles")
        {
            //Debug.Log(col.gameObject.name);
            // Kill the player
            //player.gameObject.SetActive(false);
            player_rigidbody.isKinematic = false;
            player_rigidbody.useGravity = true;
            player_rigidbody.AddForce(Vector3.down * 10);

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

            score_trigger_sound.Play();

            //Do score update here
            ScoreManager.instance.AddPoints();

            Debug.Log(ScoreManager.instance.GetScore());
        }
    }
}
