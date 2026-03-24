using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Spell : MonoBehaviour
{

    public SpellData spellData;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();

        if(spellData != null){
            if(spellData.speed > 0){
                rb.linearVelocity = spellData.direction.normalized * spellData.speed;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void onTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Enemy")){
            spellData.OnHit(other.gameObject, this.gameObject);
        }
    }
}
