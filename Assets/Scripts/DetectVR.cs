using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;

public class DetectVR : MonoBehaviour
{
    public GameObject player_VR_Simulated;
    public GameObject player_VR;
    public bool useVR;

    // Start is called before the first frame update
    void Start()
    {
        if (useVR)
        {
            player_VR_Simulated.SetActive(false); 
            player_VR.SetActive(true); 
            /*var xrSettings = XRGeneralSettings.Instance;
            if (xrSettings == null)
            {
                Debug.Log("XRGeneralSettings is null");
                return;
            }

            var xrManager = xrSettings.Manager;
            if (xrSettings == null)
            {
                Debug.Log("XRManagerSettings is null");
                return;
            }

            var xrLoader = xrManager.activeLoader;
            if (xrLoader == null)
            {
                Debug.Log("XRLoader is null");
                xrOrigin.SetActive(false);
                player_Non_VR.SetActive(true);
                return;
            }

            Debug.Log("XRLoader is not null");
            xrOrigin.SetActive(true);
            player_Non_VR.SetActive(false);*/
        }
        else
        {
            player_VR_Simulated.SetActive(true);
            player_VR.SetActive(false); 
        }
    }
}
