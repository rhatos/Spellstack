using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class GoblinProjectile : MonoBehaviour
{

    public Vector2 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){

            other.gameObject.GetComponent<PlayerController>().getHit(1);
            Destroy(this.gameObject);
        }

    }
}
