using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera cameraSecurityRoom;
    public Camera camera1A;
    public Camera camera1B;
    public Camera camera1C;
    public Camera camera2A;
    public Camera camera2B;
    public Camera camera3;
    public Camera camera4A;
    public Camera camera4B;
    public Camera camera5;
    public Camera camera6;
    public Camera camera7;   

    protected Camera[] cameras;

    [SerializeField]
    protected int currentCamera;

    void Awake()
    {
        cameras = new Camera[12];
        cameras[0] = cameraSecurityRoom;
        cameras[1] = camera1A;
        cameras[2] = camera1B;
        cameras[3] = camera1C;
        cameras[4] = camera2A;
        cameras[5] = camera2B;
        cameras[6] = camera3;
        cameras[7] = camera4A;
        cameras[8] = camera4B;
        cameras[9] = camera5;
        cameras[10] = camera6;
        cameras[11] = camera7;

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void incCamera()
    {
        // Increment camera logic here

        cameras[currentCamera].GetComponent<AudioListener>().enabled = false; // Disable audio listener on the current camera
        cameras[currentCamera].enabled = false; // Disable the current camera
        currentCamera++;
        if (currentCamera >= cameras.Length)
        {
            currentCamera = 0; // Loop back to the first camera
        }

        cameras[currentCamera].enabled = true;
        cameras[currentCamera].GetComponent<AudioListener>().enabled = true; // Enable audio listener on the new camera
    }

    void decCamera()
    {
        // Decrement camera logic here
        
        cameras[currentCamera].GetComponent<AudioListener>().enabled = false; // Disable audio listener on the current camera
        cameras[currentCamera].enabled = false; // Disable the current camera
        currentCamera--;
        if (currentCamera < 0)
        {
            currentCamera = cameras.Length - 1; // Loop back to the last camera
        } 

        cameras[currentCamera].enabled = true;
        cameras[currentCamera].GetComponent<AudioListener>().enabled = true; // Enable audio listener on the new camera
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            incCamera();
            

        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            decCamera();

        }

    }
}
