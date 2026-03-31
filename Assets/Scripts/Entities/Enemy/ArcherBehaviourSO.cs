using UnityEngine;

[CreateAssetMenu(menuName = "Enemies/ArcherEnemy")]
public class ArcherBehaviourSO : EnemyBehaviourSO
{

    public float moveSpeed = 1f;
    public float attackRange = 10f;
    
    Vector3 moveDirection;

    public override void Update(){

        // Handle animation based on state
        if(state == 0 || state == 1){
            anim.SetBool("isMoving", true);
            anim.SetBool("isShooting", false);
        } else if(state == 2){
            anim.SetBool("isShooting", true);
            anim.SetBool("isMoving", false);
        }

        // direction to player
        Vector3 direction = (player.transform.position - rb.transform.position).normalized;
        moveDirection = direction;

        // Flip the sprite around depending on direction, since this sprite only has left and right
        if(moveDirection.x > 0) sprite.flipX = false;
        if(moveDirection.x < 0) sprite.flipX = true;

    }

    public override void FixedUpdate(){

        if(knockedBack) {
            state = -1;
        }
        // Move state
        if(state == 0){

            rb.linearVelocity = new Vector2(moveDirection.x,moveDirection.y) * moveSpeed;

            // Check if close enough to player
            float distance = (player.transform.position - rb.transform.position).magnitude;
            if(distance < attackRange){
                state = 1;
            }
        }

        // Aiming state, so we need to move in the y direction
        if(state == 1){

            float yDistance = Mathf.Abs(player.transform.position.y - rb.transform.position.y);
            float tolerance = 1.2f;

            if(yDistance > tolerance){
                rb.linearVelocity = new Vector2(0, moveDirection.y) * moveSpeed;
            } else {
                state = 2;
            }
        }

        if(state == 2){

            // Check if player has moved away
            float distance = (player.transform.position - rb.transform.position).magnitude;
            if(distance > attackRange){
                state = 0;
            }

            float yDistance = Mathf.Abs(player.transform.position.y - rb.transform.position.y);
            float tolerance = 1.2f;
            if(yDistance > tolerance) state = 1;



            if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f){
                Debug.Log("Shoot");
                anim.Play("ArcherShoot",-1,0f);
            }

            rb.linearVelocity = new Vector2(0,0);
 
        }

    }

    // No this is not gen ai, I just needed to write my thought process out
    // Archer needs several states
    // -1     Knocked back -> Reset by enemy to 0
    // 0.     Walk up to player
    // 1.2.   Aim at player - on the correct y level
    // 2.     Shoot at player whilst on y level
    //
    // So we need a way to track state
    // 0 = walk up to player
    // 1 = aim at player, i.e: move to correct y level
    // 2 = shooting

}
