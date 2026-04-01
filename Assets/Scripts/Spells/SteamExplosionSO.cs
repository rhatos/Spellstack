using UnityEngine;

[CreateAssetMenu(menuName = "Spells/SteamExplosion")]
public class SteamExplosionSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<Enemy>().onHitFlashWhite();
        Destroy(projectile);

    }
}
