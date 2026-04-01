using UnityEngine;

[CreateAssetMenu(menuName = "Spells/WaterStrike")]
public class WaterStrikeSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<Enemy>().onHitFlashWhite(1);
        Destroy(projectile);

    }

    public override void FixedUpdate(){}
}
