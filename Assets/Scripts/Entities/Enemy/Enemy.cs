using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour, Entity
{

    // Flash white when hit
    public Material defaultMat;
    public Material hitMat;
    private SpriteRenderer sprite;

    // Behaviour
    public EnemyBehaviourSO behaviour;

    private Rigidbody2D rb;
    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        this.sprite = this.GetComponent<SpriteRenderer>();
        this.rb = this.GetComponent<Rigidbody2D>();
        this.anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       behaviour.Update(); 
    }

    void FixedUpdate(){
        behaviour.FixedUpdate();
    }


    // Common on-hit stuff
    public void onHitFlashWhite(){
        StartCoroutine(FlashWhite());
    }

    public void onHitKnockBack(Vector2 direction){
        StartCoroutine(KnockedBack(direction));
    }

    IEnumerator KnockedBack(Vector2 direction){

        rb.linearVelocity = direction.normalized * 10;
        yield return new WaitForSeconds(0.2f);
        rb.linearVelocity = Vector2.zero;

    }

    IEnumerator FlashWhite(){

        this.sprite.material = hitMat;
        anim.speed = 0;

        yield return new WaitForSeconds(0.2f);

        this.sprite.material = defaultMat;
        anim.speed = 1;

    }

    // For room methods
    public GameObject getObject(){
        return this.gameObject;
    }
}
