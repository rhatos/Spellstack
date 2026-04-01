using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ArcherProjectile : MonoBehaviour
{

    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    public Vector2 direction;

    public float projectileSpeed = 20f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       this.sprite = this.GetComponent<SpriteRenderer>(); 
       this.rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(direction != null){

            rb.linearVelocity = direction.normalized * projectileSpeed; 

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);



        }
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            Debug.Log("Hit");
            Destroy(this.gameObject);
        }

    }
}
