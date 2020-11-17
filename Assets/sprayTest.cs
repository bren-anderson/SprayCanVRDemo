using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class sprayTest : MonoBehaviour
{
    public Vector3 direction = Vector3.forward;
    public RaycastHit hit;
    public int MaxDistance;
    private ParticleSystem particleSpray;
    private GameObject particleSprayObject;

    private Interactable interactable;

    public SteamVR_Action_Boolean sprayButton = null;
    public SteamVR_Behaviour_Pose Pose = null;

    public SteamVR_Action_Single positionTracker = SteamVR_Input.GetAction<SteamVR_Action_Single>("");

    void Start()
    {
        particleSpray = gameObject.GetComponentInChildren<ParticleSystem>();
        particleSprayObject = gameObject.transform.GetChild(0).gameObject;
        interactable = GetComponent<Interactable>();
    }
    
    void Update()
    {
        Pose = GetComponentInParent<SteamVR_Behaviour_Pose>();
        float tracker = 0;
        if (interactable.attachedToHand)
        {
            SteamVR_Input_Sources hand = interactable.attachedToHand.handType;
            tracker = positionTracker.GetAxis(hand);
            if (sprayButton.GetState(Pose.inputSource))
            {
                Debug.Log("a");
                //MaxDistance = 5;
                particleSpray.Play();
                particleSprayObject.SetActive(true);
                if (Physics.Raycast(transform.position, direction, out hit, MaxDistance))
                {
                    print(hit.transform.name);
                }
                var scale = particleSpray.shape;
                scale.scale = new Vector3(MaxDistance / 12.5f, MaxDistance / 12.5f, MaxDistance / 33.33f);
                var speed = particleSpray.main;
                speed.startSpeed = 30 / MaxDistance;
            }
            if (Input.GetKeyUp("p"))
            {
                particleSpray.Stop();
            }
        }
        
        /*if (Input.GetKeyDown("1"))
        {
            MaxDistance = 1;
            var scale = particleSpray.shape;
            scale.scale = new Vector3(MaxDistance / 12.5f, MaxDistance / 12.5f, MaxDistance / 33.33f);
            var speed = particleSpray.main;
            speed.startSpeed = 30f / 12.5f;
        }
        if (Input.GetKeyDown("5"))
        {
            MaxDistance = 5;
            var scale = particleSpray.shape;
            scale.scale = new Vector3(MaxDistance / 12.5f, MaxDistance / 12.5f, MaxDistance / 33.33f);
            var speed = particleSpray.main;
            speed.startSpeed = 15f;
        }
        if (Input.GetKeyDown("0"))
        {
            MaxDistance = 10;
            var scale = particleSpray.shape;
            scale.scale = new Vector3(MaxDistance / 12.5f, MaxDistance / 12.5f, MaxDistance / 33.33f);
            var speed = particleSpray.main;
            speed.startSpeed = 30f;
        }*/
    }
}
