using UnityEngine;

[CreateAssetMenu(menuName = "Spells/VineCyclone")]
public class VineCycloneSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<EnemyAI>().knockBack(10f,direction);
        Destroy(projectile);

    }
}
