using UnityEngine;

[CreateAssetMenu(menuName = "Spells/BurningVines")]
public class BurningVinesSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<Enemy>().onHitFlashWhite();
        Destroy(projectile);

    }
}
