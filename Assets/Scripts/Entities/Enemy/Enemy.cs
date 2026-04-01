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

    public Rigidbody2D rb;
    private Animator anim;

    bool rooted = false;

    void Awake(){
        behaviour = Instantiate(behaviour);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        this.sprite = this.GetComponent<SpriteRenderer>();
        this.rb = this.GetComponent<Rigidbody2D>();
        this.anim = this.GetComponent<Animator>();
        behaviour.rb = this.rb;
        behaviour.sprite = this.sprite;
        behaviour.anim = this.anim;
        behaviour.player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       behaviour.Update(); 

       if(behaviour.health <= 0){
           Destroy(this.transform.gameObject);
       }
    }

    void FixedUpdate(){
        behaviour.FixedUpdate();

        if(rooted) rb.linearVelocity = new Vector2(0,0);
    }


    // Common on-hit stuff
    public void onHitFlashWhite(int damage){
        StartCoroutine(FlashWhite());
        behaviour.health -= damage;
    }

    public void onHitKnockBack(Vector2 direction, float amount){
        StartCoroutine(KnockedBack(direction, amount));
    }

    public void slowBriefly(float duration, float amount){
        StartCoroutine(Slow(duration,amount));
    }

    public void rootInPlace(float duration){
        StartCoroutine(Root(duration));
    }

    IEnumerator KnockedBack(Vector2 direction, float amount){

        behaviour.knockedBack = true;
        rb.linearVelocity = direction.normalized * amount;
        yield return new WaitForSeconds(0.2f);
        rb.linearVelocity = Vector2.zero;
        behaviour.knockedBack = false;
        behaviour.state = 0;

    }

    IEnumerator Slow(float duration, float amount){

        anim.speed = 0.5f;
        float oldMoveSpeed = behaviour.moveSpeed;
        behaviour.moveSpeed = behaviour.moveSpeed - amount;
        yield return new WaitForSeconds(duration);
        behaviour.moveSpeed = oldMoveSpeed;
        anim.speed = 1;

    }

    IEnumerator Root(float duration){

        anim.speed = 0.1f;
        float oldMoveSpeed = behaviour.moveSpeed;
        rooted = true;
        rb.linearVelocity = new Vector2(0,0);
        yield return new WaitForSeconds(duration);
        rooted = false;
        anim.speed = 1;

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
