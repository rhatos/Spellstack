using UnityEngine;

[CreateAssetMenu(menuName = "Spells/SteamExplosion")]
public class SteamExplosionSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<EnemyAI>().knockBack(10f,direction);
        Destroy(projectile);

    }
}
