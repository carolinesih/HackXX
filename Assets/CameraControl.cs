using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class CameraControl : MonoBehaviour
{

    public GameObject player;

    public SteamVR_Controller.Device device;
    public SteamVR_TrackedObject controller;

    Vector2 touchpad;

    private float sensitivityX = 1.5F;
    private Vector3 playerPos;


    void Start()
    {
        controller = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        device = SteamVR_Controller.Input((int)controller.index);

        if(device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            touchpad = device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);

        }

        if(device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            // Handle movement via touchpad
            if (touchpad.y > 0.2f || touchpad.y < -0.2f)
            {
                // Move Forward
                player.transform.position -= player.transform.forward * Time.deltaTime * (touchpad.y * 2f);

                // Adjust height to terrain height at player positin
                playerPos = player.transform.position;
                playerPos.y = Terrain.activeTerrain.SampleHeight(player.transform.position);
                player.transform.position = playerPos;
            }

            // handle rotation via touchpad
            if (touchpad.x > 0.3f || touchpad.x < -0.3f)
            {
                player.transform.position -= player.transform.right * Time.deltaTime * (touchpad.x * 2f);

                // Adjust height to terrain height at player positin
                playerPos = player.transform.position;
                playerPos.y = Terrain.activeTerrain.SampleHeight(player.transform.position);
                player.transform.position = playerPos;
            }
        }
      
    }


    /*private SteamVR_TrackedObject trackedObj;
    private GameObject

    public SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

	
    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

	// Update is called once per frame
	void Update () {
        //keyboard input
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Vector3.forward * Time.deltaTime);
        }

        //vive input
        if(Controller.GetAxis() != Vector2.zero)
        {
            Debug.Log(gameObject.name + Controller.GetAxis());
        }

        if (Controller.GetHairTriggerDown())
        {
            Debug.Log(gameObject.name + " Trigger Press");
        }
    }*/
}

