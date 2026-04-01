using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Enemies/BatEnemy")]
public class BatBehaviourSO : EnemyBehaviourSO
{

    public float moveSpeed = 5f;
    public float distanceToPlayer = 8f;

    Vector3 moveDirection;

    float startTime;

    public GameObject projectilePrefab;

    // Update is called once per frame
    public override void Update(){
        // Handle animation based on state
        if(state == 0 || state == 1 || state == 3){
            anim.SetBool("isRunning", true);
            anim.SetBool("isAttacking", false);
        } else if(state == 2){
            anim.SetBool("isAttacking", true);
            anim.SetBool("isRunning", false);
        }

        Vector3 direction = (player.transform.position - rb.transform.position).normalized;
        moveDirection = direction;

        if(moveDirection.x > 0) sprite.flipX = true;
        if(moveDirection.x < 0) sprite.flipX = false;

    }

    // reminder to exclude bat from all collisions except itself
    public override void FixedUpdate(){

        // Three behaviours
        // 1. get close to player (0)
        // 2. hover around player (1)
        // 3. swoop into player (2)

        float distance = (player.transform.position - rb.transform.position).magnitude;

        if(knockedBack){
            state = -1;
        }
        
        // Get close to player
        if(state == 0){
            if(distance > distanceToPlayer){
                rb.linearVelocity = new Vector2(moveDirection.x,moveDirection.y) * moveSpeed;
            } else {
                state = 1;
                startTime = Time.time;
            }
        }

        // Hover around player for some time
        if(state == 1){
            rb.linearVelocity = new Vector2(0,0);
            if(Time.time - startTime > 1.2f){
                // Fly into player
                state = 2;
            }
        }

        if(state == 2){

            rb.linearVelocity = new Vector2(moveDirection.x,moveDirection.y) * 15f;
            float loopProgress = anim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1f;

            GameObject projectile = null;
            if(loopProgress >= 0.49f && loopProgress <= 0.51f){
                Vector3 positionOfProjectile = rb.transform.position;
                projectile = Instantiate(projectilePrefab,positionOfProjectile,Quaternion.identity);
            } else if(projectile != null){
                Destroy(projectile);
            }

            if(loopProgress >= 0.90f){
                state = 3;
                startTime = Time.time;
            }

            // if(distanceToPlayer < 5f){
                // state = 3;
                // startTime = Time.time;
            // }
        }

        if(state == 3){
            rb.linearVelocity = new Vector2(0,0);
            if(Time.time - startTime > 1.2f){
                state = 0;
            }
        }

    }
 
}
