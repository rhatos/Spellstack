using UnityEngine;

[RequireComponent(typeof(Collider2D))]
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

            float angle = Mathf.Atan2(spellData.direction.y, spellData.direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Enemy")){
            spellData.OnHit(other.gameObject, this.gameObject);
            Debug.Log("Hit Enemy");
        }
    }
}
