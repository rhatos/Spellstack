using UnityEngine;

public class CameraFollowAim : MonoBehaviour
{

    public Transform playerPosition;
    public Transform cursorPosition;

    public float distance = 0.15f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 cameraDisplacement = (cursorPosition.position - playerPosition.position) * distance;
        Vector3 finalCameraPosition = playerPosition.position + cameraDisplacement;
        finalCameraPosition.z = -10;
        transform.position = finalCameraPosition;
        
    }
}
