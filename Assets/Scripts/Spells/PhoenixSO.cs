using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Pheonix")]
public class PhoenixSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<EnemyAI>().knockBack(10f,direction);
        Destroy(projectile);

    }
}
