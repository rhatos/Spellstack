using UnityEngine;

[CreateAssetMenu(menuName = "Spells/WaterStrike")]
public class WaterStrikeSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<Enemy>().onHitFlashWhite();
        Destroy(projectile);

    }
}
