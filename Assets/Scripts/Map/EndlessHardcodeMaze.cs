using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// basically recycle the previous paths to ensure that user can endlessly run on it
/// </summary>
public class EndlessHardcodeMaze : MonoBehaviour
{
    [SerializeField, Tooltip("Player's transform")]
    Transform playerTransform;
    [SerializeField, Tooltip("Distance to start")]
    int totalGrids = 50;
    [SerializeField, Tooltip("To get the handler for the grid")]
    MapHandler mapHandler;
    [SerializeField, Tooltip("the offset to get it spawn")]
    int spawnOffsetGrid = 4;

    [Header("Debugging Purpose")]
    [SerializeField, Tooltip("Player's starting position!")]
    Vector3 playerPos;
    [SerializeField]
    /// <summary>
    /// get half of the grid 
    /// </summary>
    int halfOfGrid;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = playerTransform.position;
        halfOfGrid = totalGrids / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //usually i wont use update if i dont have to, but there is no time
        // get the vector direction
        Vector3 dir = playerPos - playerTransform.position;
        var firstChild = transform.GetChild(0);
        var firstPathSize = firstChild.GetComponent<PathSize>();
        if (dir.magnitude > (halfOfGrid+ firstPathSize.gridSize - spawnOffsetGrid) * mapHandler.m_GizmosGridSize.x)
        {
            // then get the current index then move it to the
            firstChild.position += new Vector3(0, 0, totalGrids * mapHandler.m_GizmosGridSize.y);
            // then reassign it to the last
            firstChild.SetAsLastSibling();
            halfOfGrid += firstPathSize.gridSize;
        }
    }
}
