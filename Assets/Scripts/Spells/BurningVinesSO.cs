using UnityEngine;

[CreateAssetMenu(menuName = "Spells/BurningVines")]
public class BurningVinesSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<EnemyAI>().knockBack(10f,direction);
        Destroy(projectile);

    }
}
