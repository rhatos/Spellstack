using UnityEngine;

[CreateAssetMenu(menuName = "Spells/VineSpell")]
public class VineSpellSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<EnemyAI>().knockBack(10f,direction);
        Destroy(projectile);

    }
}
