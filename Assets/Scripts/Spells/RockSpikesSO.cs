using UnityEngine;

[CreateAssetMenu(menuName = "Spells/RockSpikes")]
public class RockSpikesSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<EnemyAI>().knockBack(10f,direction);
        Destroy(projectile);

    }
}
