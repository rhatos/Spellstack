using UnityEngine;


[CreateAssetMenu(menuName = "Enemies/GoblinEnemy")]
public class GoblinBehaviourSO : EnemyBehaviourSO
{

    public float attackRange = 1f;
    Vector3 moveDirection;
    public float moveSpeed = 10f;

    public GameObject projectilePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        Vector3 direction = (player.transform.position - rb.transform.position).normalized;
        if(Mathf.RoundToInt(direction.x) == 1) anim.SetInteger("direction", 3);
        if(Mathf.RoundToInt(direction.x) == -1) anim.SetInteger("direction", 2);
        if(Mathf.RoundToInt(direction.y) == 1) anim.SetInteger("direction", 1);
        if(Mathf.RoundToInt(direction.y) == -1) anim.SetInteger("direction", 0);
        
        moveDirection = direction;

        
    }

    public override void FixedUpdate(){

        if(knockedBack) state = -1;

        // Walking up to player
        if(state == 0){
            
            float distance = (player.transform.position - rb.transform.position).magnitude;
            rb.linearVelocity = new Vector2(moveDirection.x,moveDirection.y) * moveSpeed;
            anim.SetBool("isRunning", true);
            if(distance < attackRange){
                state = 1;
                anim.SetBool("isRunning", false);
            }
        }

        // Attacking
        if(state == 1){

            float distance = (player.transform.position - rb.transform.position).magnitude;
            rb.linearVelocity = new Vector2(0,0);
            if(distance > attackRange){
                state = 0;
                anim.SetBool("isRunning", true);
            }

            // In the middle of the animation we spawn the "projectile"
            if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f && anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.6f){
                Vector3 positionOfProjectile = rb.transform.position + (moveDirection * 2);
                GameObject projectile = Instantiate(projectilePrefab,positionOfProjectile,Quaternion.identity);
                projectile.GetComponent<GoblinProjectile>().direction = -moveDirection;
            }
        }

        // Vector3 cameraDisplacement = (cursorPosition.position - playerPosition.position) * distance;
        // Vector3 finalCameraPosition = playerPosition.position + cameraDisplacement;
        // finalCameraPosition.z = -10;

    }
}
