using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

 public class SteamVRLaserWrapper : MonoBehaviour
 {
    public SteamVR_LaserPointer laserPointer;
    public Button button;
    public GameSequence gameSeq;

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Start Game")
        {
            Debug.Log("Start Game was clicked");
            gameSeq.Start_Game();

        } else if (e.target.name == "Quit Button")
        {
            Debug.Log("Quit Button was clicked");
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Start Game")
        {
            Debug.Log("Start Game was entered");
        }
        else if (e.target.name == "Quit Button")
        {
            Debug.Log("Quit Button was entered");
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Start Game")
        {
            Debug.Log("Start Game was exited");
        }
        else if (e.target.name == "Quit Button")
        {
            Debug.Log("Quit Button was exited");
        }
    }
}