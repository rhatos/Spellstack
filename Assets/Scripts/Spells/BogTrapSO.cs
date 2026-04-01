using UnityEngine;

[CreateAssetMenu(menuName = "Spells/BogTrap")]
public class BogTrapSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<EnemyAI>().knockBack(10f,direction);
        Destroy(projectile);

    }
}
