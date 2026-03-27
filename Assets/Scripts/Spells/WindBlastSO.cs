using UnityEngine;

[CreateAssetMenu(menuName = "Spells/WindBlast")]
public class WindBlastSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<EnemyAI>().knockBack(10f,direction);
        Destroy(projectile);

    }
}
