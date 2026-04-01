using UnityEngine;

[CreateAssetMenu(menuName = "Spells/BogTrap")]
public class BogTrapSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<Enemy>().onHitFlashWhite(0);
        target.GetComponent<Enemy>().rootInPlace(5f);

    }

    public override void FixedUpdate(){}
}
