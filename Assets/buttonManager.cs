using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class buttonManager : MonoBehaviour
{
    public SteamVR_Action_Boolean sprayButton = null;
    public SteamVR_Behaviour_Pose Pose = null;
    //public SteamVR_Action_Vector3 sprayingTracker = null;
    public SteamVR_Action_Single sprayingTracker;
    public float sprayingTrackerX;
    public float sprayingTrackerY;
    public float sprayingTrackerZ;

    void Start()
    {
        Pose = GetComponent<SteamVR_Behaviour_Pose>();
        //sprayingTracker = GetComponent<SteamVR_Action_Vector3>();
        sprayingTracker = GetComponent<SteamVR_Action_Single>();
    }
    
    void Update()
    {
        if (sprayButton.GetState(Pose.inputSource))
        {
            //Debug.Log("e");
        }
    }
}
