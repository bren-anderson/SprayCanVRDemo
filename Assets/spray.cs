using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class spray : MonoBehaviour
{
    //Sets forward direction, Raycast, Raycast's distance
    public Vector3 direction = Vector3.forward;
    public RaycastHit hit;
    public float MaxDistance;

    //Sets the particle system, and the systems object
    private ParticleSystem particleSpray;
    private GameObject particleSprayObject;

    //Sets the object to be interactible
    private Interactable interactable;


    //Sets the various controls
    public SteamVR_Action_Boolean sprayButton = null;
    public SteamVR_Action_Boolean sprayButton2 = null;
    public SteamVR_Behaviour_Pose Pose = null;

    //For tweaking the Particle System's scale
    private ParticleSystemRenderer particleScale;

    //For setting the skeleton's pose
    private SteamVR_Skeleton_Poser poser;

    //Sets the above variables as soon as the game starts
    void Start()
    {
        particleSpray = gameObject.GetComponentInChildren<ParticleSystem>();
        particleSprayObject = gameObject.transform.GetChild(0).gameObject;
        interactable = GetComponent<Interactable>();
        poser = GetComponent<SteamVR_Skeleton_Poser>();
    }

    void Update()
    {
        //Gets the hand pose so buttons will work
        Pose = GetComponentInParent<SteamVR_Behaviour_Pose>();

        //Checks if the object is being held. If so, attaches to the hand and allowes the buttons to be used
        if (interactable.attachedToHand)
        {
            SteamVR_Input_Sources hand = interactable.attachedToHand.handType;

            //Changes variables and starts the particle system when you hold the trigger
            if (sprayButton.GetState(Pose.inputSource))
            {
                MaxDistance = 10;
                particleSpray.Play();
                particleSprayObject.SetActive(true);
                //Raycast collison detector that prints the collided objects name
                if (Physics.Raycast(transform.position, direction, out hit, MaxDistance))
                {
                    print(hit.transform.name);
                }
                var scale = particleSpray.shape;
                scale.scale = new Vector3(0.8f, 0.8f, 0.3f);
                var speed = particleSpray.main;
                speed.startSpeed = 30;
                var emission = particleSpray.emission;
                emission.rateOverTime = 250f;
                particleScale = particleSpray.GetComponent<ParticleSystemRenderer>();
                particleScale.maxParticleSize = 0.1f;

                //Changes the Skeleton pose
                poser.SetBlendingBehaviourValue("blend", 0.5f);
            }
            //Changes variables and starts the particle system when you click the button when you touch the trigger
            else if (sprayButton2.GetState(Pose.inputSource))
            {
                MaxDistance = 1;
                particleSpray.Play();
                particleSprayObject.SetActive(true);
                if (Physics.Raycast(transform.position, direction, out hit, MaxDistance))
                {
                    print(hit.transform.name);
                }
                var scale = particleSpray.shape;
                scale.scale = new Vector3(0.06f, 0.06f, 0.04f);
                var speed = particleSpray.main;
                speed.startSpeed = 10;
                var emission = particleSpray.emission;
                emission.rateOverTime = 125f;
                particleScale = particleSpray.GetComponent<ParticleSystemRenderer>();
                particleScale.maxParticleSize = 0.05f;

                //Changes the Skeleton pose
                poser.SetBlendingBehaviourValue("blend", 0.5f);
            }
        }
    }
}
