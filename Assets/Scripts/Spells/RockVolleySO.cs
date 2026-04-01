using UnityEngine;

[CreateAssetMenu(menuName = "Spells/RockVolley")]
public class RockVolleySO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<Enemy>().onHitFlashWhite(damage);
        Destroy(projectile);

    }

    public override void FixedUpdate(){}
}
