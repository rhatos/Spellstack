using UnityEngine;

[CreateAssetMenu(menuName = "Spells/SteamExplosion")]
public class SteamExplosionSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<Enemy>().onHitFlashWhite(0);
        target.GetComponent<Enemy>().onHitKnockBack(direction,20f);

        Destroy(projectile);

    }

    public override void FixedUpdate(){}
}
