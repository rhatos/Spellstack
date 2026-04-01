using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Spell : MonoBehaviour
{

    public SpellData spellData;

    private Rigidbody2D rb;
    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.anim = GetComponent<Animator>();

        if(spellData != null){
            spellData.rb = this.rb;
            spellData.anim = this.anim;
            if(spellData.speed > 0){
                rb.linearVelocity = spellData.direction.normalized * spellData.speed;
            }

            float angle = Mathf.Atan2(spellData.direction.y, spellData.direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }

        Destroy(this.transform.gameObject, 5f);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate(){
        if(spellData !=null){
            spellData.FixedUpdate();
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Enemy")){
            spellData.OnHit(other.gameObject, this.gameObject);
            Debug.Log("Hit Enemy");
            //deal damage to enemy, but this changes for each spell
            //override this
        }
    }
}
