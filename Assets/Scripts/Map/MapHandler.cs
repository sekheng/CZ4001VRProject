using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapHandler : MonoBehaviour
{
    [Header("For Debugging")]
    [SerializeField, Tooltip("Grid Range from (0,0,0)")]
    Vector2 m_GridRange = new Vector2(200, 200);
    [Tooltip("Gizmos Grid Size")]
    public Vector2 m_GizmosGridSize = new Vector2(3,3);

    /// <summary>
    /// To draw the rough grid size then 
    /// </summary>
    private void OnDrawGizmos()
    {
        for (float x = m_GridRange.x; x >= -m_GridRange.x; x -= m_GizmosGridSize.x)
        {
            for (float y = m_GridRange.y; y >= -m_GridRange.y; y -= m_GizmosGridSize.y)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireCube(new Vector3(x, 0, y), new Vector3(m_GizmosGridSize.x, 1, m_GizmosGridSize.y));
            }
        }
    }
}
