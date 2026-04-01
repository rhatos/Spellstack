using UnityEngine;

[CreateAssetMenu(menuName = "Spells/BurningVines")]
public class BurningVinesSO : SpellData
{

    GameObject lockedTarget;

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<Enemy>().onHitFlashWhite(1);
        target.GetComponent<Enemy>().rootInPlace(2f);
        lockedTarget = target;

        Destroy(projectile.transform.gameObject,2f);

    }

    public override void FixedUpdate(){

        if(lockedTarget != null){
            float loopProgress = anim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1f;
            if(loopProgress >= 0.45f && loopProgress <= 0.55f && loopProgress >= 0.7f){
                lockedTarget.GetComponent<Enemy>().onHitFlashWhite(1);
            }

        }

    }
}
