using UnityEngine;

[CreateAssetMenu(menuName = "Spells/LightningStrike")]
public class LightningStrikeSO : SpellData
{

    bool locked = false;
    GameObject lockedTarget;

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<Enemy>().onHitFlashWhite(5);
        locked = true;
        lockedTarget = target;

    }

    public override void FixedUpdate(){

        if(lockedTarget != null){
            Vector3 direction = (lockedTarget.transform.position - rb.transform.position).normalized;
            rb.linearVelocity = direction * 5f;

            float loopProgress = anim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1f;
            if(loopProgress >= 0.45f && loopProgress <= 0.55f){
                lockedTarget.GetComponent<Enemy>().onHitFlashWhite(1);
            }

        }

    }
}
