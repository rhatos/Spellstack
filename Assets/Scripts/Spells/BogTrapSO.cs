using UnityEngine;

[CreateAssetMenu(menuName = "Spells/BogTrap")]
public class BogTrapSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        AudioManager.instance.Play("Mob Damage");
        target.GetComponent<Enemy>().onHitFlashWhite(0);
        target.GetComponent<Enemy>().rootInPlace(5f);
        Destroy(projectile);

    }

    public override void FixedUpdate(){}
}
