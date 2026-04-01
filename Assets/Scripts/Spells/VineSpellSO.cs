using UnityEngine;

[CreateAssetMenu(menuName = "Spells/VineSpell")]
public class VineSpellSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<Enemy>().onHitFlashWhite();
        Destroy(projectile);

    }
}
