using UnityEngine;

[CreateAssetMenu(menuName = "Enemies/BossEnemy")]
public class BossBehaviour : EnemyBehaviourSO
{
    public float attackRange = 10f;
    
    Vector3 moveDirection;

    public GameObject projectilePrefab;

    private float prevMoveSpeed = 0f;
    public float tolerance = 2f;

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
        if(anim.GetBool("isMoving")){
        // Flip the sprite around depending on direction, since this sprite only has left and right
            if(moveDirection.x > 0) sprite.flipX = true;
            if(moveDirection.x < 0) sprite.flipX = false;
        } else {

            if(moveDirection.x > 0) sprite.flipX = false;
            if(moveDirection.x < 0) sprite.flipX = true;
        }

    }

    public override void FixedUpdate(){

        if(knockedBack) {
            state = -1;
        }
        // Move state
        if(state == 0){

            if(prevMoveSpeed != 0) moveSpeed = prevMoveSpeed;

            rb.linearVelocity = new Vector2(moveDirection.x,moveDirection.y) * moveSpeed;

            // Check if close enough to player
            float distance = (player.transform.position - rb.transform.position).magnitude;
            if(distance < attackRange){
                state = 1;
                prevMoveSpeed = moveSpeed;
            }
        }

        // Aiming state, so we need to move in the y direction
        if(state == 1){

            float yDistance = Mathf.Abs(player.transform.position.y - rb.transform.position.y);

            if(yDistance > tolerance){
                rb.linearVelocity = new Vector2(0, moveDirection.y) * moveSpeed;
            } else {
                state = 2;
            }
        }

        // Shooting state
        if(state == 2){

            // Check if player has moved away
            float distance = (player.transform.position - rb.transform.position).magnitude;
            if(distance > attackRange){
                state = 0;
            }

            // Check if player has moved away in the y
            float yDistance = Mathf.Abs(player.transform.position.y - rb.transform.position.y);
            if(yDistance > tolerance) state = 1;



            // End of archer shooting animation
            // Also when it shoots the projectile
            if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f){
                GameObject projectile = Instantiate(projectilePrefab,rb.transform.position,Quaternion.identity);
                GameObject projectile1 = Instantiate(projectilePrefab,rb.transform.position + new Vector3(0,Random.Range(0,0.5f),0),Quaternion.identity);
                GameObject projectile2 = Instantiate(projectilePrefab,rb.transform.position + new Vector3(0,Random.Range(-0.5f,0),0),Quaternion.identity);

                // Added some random number to direction for a nicer feeling.
                projectile.GetComponent<BossProjectile>().direction = new Vector2(Mathf.RoundToInt(moveDirection.x),moveDirection.y + Random.Range(0,0));
                projectile1.GetComponent<BossProjectile>().direction = new Vector2(Mathf.RoundToInt(moveDirection.x),moveDirection.y + Random.Range(-0.1f,0));
                projectile2.GetComponent<BossProjectile>().direction = new Vector2(Mathf.RoundToInt(moveDirection.x),moveDirection.y + Random.Range(0,0.1f));
                anim.Play("BossShoot",-1,0f);
            }

            rb.linearVelocity = new Vector2(0,0);
 
        }

    }


}
