using System.Collections;
using UnityEngine;

public class SecurityDoorManager : MonoBehaviour
{
    public float doorHeight = 2.12f;
    public float doorSpeed = 1.0f;

    protected bool doorInUse = false;
    protected bool doorOpen = false;
    private Vector3 initialPosition;

    void Start()
    {
        // Store the initial position when the game starts
        initialPosition = transform.position;
    }

    IEnumerator OpenDoor()
    {
        Vector3 startPos = transform.position;
        Vector3 targetPos = initialPosition + Vector3.up * doorHeight;

        float duration = doorHeight / doorSpeed;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos; // Ensure we reach exactly the target position
        doorInUse = false;
        doorOpen = true;
        Debug.Log("Door opened");
    }

    IEnumerator CloseDoor()
    {
        Vector3 startPos = transform.position;
        Vector3 targetPos = initialPosition;

        float duration = doorHeight / doorSpeed;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos; // Ensure we reach exactly the target position
        doorInUse = false;
        doorOpen = false;
        Debug.Log("Door closed");
    }

    public void activateDoor()
    {
        if (!doorInUse)
        {
            doorInUse = true;
            if (doorOpen)
                StartCoroutine(CloseDoor());
            else
                StartCoroutine(OpenDoor());
        }
    }
}