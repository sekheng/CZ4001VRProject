using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>
/// Helps to generate the road automatically for me 
/// </summary>
public class RoadWithBackGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("Number of roads to generate")]
    int m_NumOfRoads = 10;
    [SerializeField, Tooltip("The Road Prefab")]
    GameObject m_Prefab;
    [SerializeField, Tooltip("X localScale Offset")]
    int m_OffsetScale = 4;

    public void BuildRoad()
    {
        for (int num = 0; num < m_NumOfRoads; num++)
        {
            Instantiate(m_Prefab, new Vector3(num * m_Prefab.transform.localScale.x * m_OffsetScale, 0, 0), new Quaternion(0, 0.7071068f, 0, 0.7071068f), transform);
        }
        // and then helps me to save the scene
        EditorSceneManager.SaveOpenScenes();
    }
}
