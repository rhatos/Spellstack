using UnityEngine;

[CreateAssetMenu(menuName = "Spells/LightningStrike")]
public class LightningStrikeSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<EnemyAI>().knockBack(10f,direction);
        Destroy(projectile);

    }
}
