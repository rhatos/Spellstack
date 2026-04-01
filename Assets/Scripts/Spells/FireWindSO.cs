using UnityEngine;

[CreateAssetMenu(menuName = "Spells/FireWind")]
public class FireWindSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<Enemy>().onHitFlashWhite(damage);

    }

    public override void FixedUpdate(){}
}
