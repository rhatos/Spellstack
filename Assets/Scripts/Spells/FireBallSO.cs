using UnityEngine;

[CreateAssetMenu(menuName = "Spells/FireBall")]
public class FireBallSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<Enemy>().onHitFlashWhite(3);

        // Create aoe

        Destroy(projectile);

    }

    public override void FixedUpdate(){}
}
