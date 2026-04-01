using UnityEngine;

[CreateAssetMenu(menuName = "Spells/RockBall")]
public class RockBallSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<Enemy>().onHitFlashWhite(this.damage);
        target.GetComponent<Enemy>().slowBriefly(1f,4f);
        Destroy(projectile);

    }

    public override void FixedUpdate(){}
}
