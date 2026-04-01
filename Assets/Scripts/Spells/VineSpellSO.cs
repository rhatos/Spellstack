using UnityEngine;

[CreateAssetMenu(menuName = "Spells/VineSpell")]
public class VineSpellSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<Enemy>().onHitFlashWhite(0);

        // root in place
        target.GetComponent<Enemy>().rootInPlace(1f);

        Destroy(projectile,1.1f);

    }

    public override void FixedUpdate(){}
}
