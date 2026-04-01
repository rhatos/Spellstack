using UnityEngine;

public class FloatingCard : MonoBehaviour
{

    Vector3 startPosition;
    public float speed = 2.0f;
    public float height = 0.2f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.startPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 newPosition = startPosition; 
       newPosition.y += Mathf.Sin(Time.time * speed) * height;
       transform.position = newPosition;
    }
}
