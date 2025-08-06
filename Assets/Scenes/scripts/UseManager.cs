using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Camera securityRoom;
    public Collider lightControlLeft;
    public Collider lightControlRight;

    public Collider doorControlLeft;
    public Collider doorControlRight;

    public Light leftLight;
    public Light rightLight;

    public SecurityDoorManager doorLeft;
    public SecurityDoorManager doorRight;

    public float doorHeight = 0.3f;
    public float doorSpeed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = securityRoom.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 20.0f))
            {
                if (hit.collider == lightControlLeft)
                {
                    Debug.Log("Light control Left!");
                    leftLight.enabled = !leftLight.enabled;
                }

                if (hit.collider == lightControlRight)
                {
                    Debug.Log("Light control Right!");
                    rightLight.enabled = !rightLight.enabled;
                }

                if (hit.collider == doorControlLeft)
                {
                    doorLeft.activateDoor();

                }

                if (hit.collider == doorControlRight)
                {
                   doorRight.activateDoor();
                }
            }
        }
    }
}