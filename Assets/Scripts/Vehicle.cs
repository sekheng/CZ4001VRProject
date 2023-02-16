using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{

    [SerializeField] private float speed;
    private float final_speed;
    private float distance = 0.0f;
    public Wheel[] wheels;

    // Fixed Update is called once fixed up date cycle (~50hz)
    private void Update()
    {
        final_speed = speed + (float)ScoreManager.instance.GetScore();
        distance += final_speed * Time.deltaTime;
        transform.Translate(Vector3.forward * final_speed * Time.deltaTime);
        if(distance>100 || transform.position.y < 0.0)
        {
            Destroy(gameObject);
        }
        foreach (Wheel w in wheels)
        {
            //w.Steer(horInput);
            //w.Accelerate(verInput * power);
            w.UpdatePosition(final_speed * Time.deltaTime);
        }
    }
}
