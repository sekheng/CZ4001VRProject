using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{

    [SerializeField] private float speed;
    private float distance = 0.0f;
    // Update is called once per frame
    private void Update()
    {
        distance += speed * Time.deltaTime;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if(distance>100){
            Destroy(gameObject);
        }

    }
}
