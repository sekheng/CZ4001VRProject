using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject player;
    public Rigidbody player_rigidbody;
    public AudioSource score_trigger_sound;
    public AudioSource car_collision_sound;
    bool is_hit = false;

    private void OnCollisionEnter(Collision col)
    {
        //Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Vehicles" && is_hit == false)
        {
            //Debug.Log(col.gameObject.name);
            // Kill the player
            is_hit = true;
            player_rigidbody.isKinematic = false;
            player_rigidbody.useGravity = true;
            player_rigidbody.AddForce(Vector3.down * 10);
            StartCoroutine(play_accident_sound()); //Start Coroutine
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

    IEnumerator play_accident_sound()
    {
        car_collision_sound.Play();
        //Wait Until Sound has finished playing
        yield return new WaitUntil(() => car_collision_sound.isPlaying == false);
        //Do death update here
        player.gameObject.SetActive(false);
        ScoreManager.instance.AddDeaths(); //Add to death counter

    }
}
