using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawn : MonoBehaviour
{
    [SerializeField] private GameObject vehicle;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;
    [SerializeField] private bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());        
    }

    private IEnumerator Spawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            // GameObject start = Instantiate(vehicle, spawnPos.position, Quaternion.identity);
            GameObject start = Instantiate(vehicle, spawnPos.position, Quaternion.Euler (0, 90, 0));
            if(isRight)
                start.transform.Rotate(new Vector3(0,180,0));
        }
    }
}
