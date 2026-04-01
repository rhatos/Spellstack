using UnityEngine;

public class BatProjectile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject,15f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){

            other.gameObject.GetComponent<PlayerController>().getHit(1);
            Destroy(this.gameObject);
        }

    }
}
