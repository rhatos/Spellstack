using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public PlayerController player;

    private SpriteRenderer sprite;
    private Animator anim;
    private Rigidbody2D rb;

    private float moveSpeed = 5f;
    private float toMove = 10f;
    private bool canShoot = false;
    private bool canMove = true;

    private float timeStopped = 0f;

    public float health = 25f;

    private bool knockedBack = false;
    private float knockBackStart = 0f;

    public Material defaultMat;
    public Material damageMat;

    void Start()
    {
        this.sprite = GetComponent<SpriteRenderer>();
        this.rb = GetComponent<Rigidbody2D>();
        this.anim = GetComponent<Animator>();
        
    }

    void FixedUpdate()
    {
        if(knockedBack){
            if(Time.time - knockBackStart > 0.2){
                rb.linearVelocity = new Vector2(0,0);
                knockedBack = false;
                anim.speed = 1;
                this.sprite.material = defaultMat;
            }
        }
        
        if(canMove && !knockedBack){

            Behaviour();
            anim.SetBool("isMoving", true);

        } else if(canShoot && !knockedBack){

            anim.SetBool("isMoving", false);
            anim.SetBool("isShooting", true);
            
            if(Time.time - timeStopped > 0.5){

                Shoot();
            }

        }
        
    }

    public void knockBack(float strength, Vector2 direction){
        knockedBack = true;
        knockBackStart = Time.time;
        rb.linearVelocity = direction.normalized * strength;
        anim.speed = 0;
        this.sprite.material = damageMat;
    }

    // Shoot on the y
    void Shoot(){
        
        canMove = true;
        canShoot = false;
        anim.SetBool("isShooting", false);

    }

    void Behaviour(){

        // Move and shoot
        // Need to get to players y level

        Vector2 currentPos = this.transform.position;
        Vector2 playerPos = player.transform.position;

        Debug.DrawLine(currentPos, playerPos,Color.red);

        float distance = Vector2.Distance(currentPos, playerPos);

        // Flip sprite depending on where player is
        if(playerPos.x > currentPos.x){
            sprite.flipX = false;
        } else {
            sprite.flipX = true;
        }


        if(distance > toMove){
            Vector2 direction = (playerPos - currentPos).normalized;

            transform.position = Vector2.MoveTowards(currentPos, playerPos, moveSpeed * Time.deltaTime);
        } else {

            // Now in range
            // Compare y
            float accpetDiff = 1f;

            float diff = Mathf.Abs(currentPos.y - playerPos.y);

            if(diff > accpetDiff){
                if(currentPos.y > playerPos.y){
                    rb.linearVelocity = new Vector2(0,-moveSpeed);
                } else {
                    rb.linearVelocity = new Vector2(0,moveSpeed);
                }
            } else {
                canShoot = true;
                canMove = false;
                timeStopped = Time.time;
                rb.linearVelocity = Vector2.zero;
            }

        }
        //
        // if(this.transform.position.y != player.transform.position.y){
        //     if(this.transform.position.y > player.transform.position.y){
        //         rb.linearVelocity = new Vector2(0,-moveSpeed);
        //     } else {
        //         rb.linearVelocity = new Vector2(0, moveSpeed);
        //     }
        // } else {
        //     rb.linearVelocity = Vector2.zero;
        // }


    }
}
