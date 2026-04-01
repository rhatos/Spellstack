using UnityEngine;

[CreateAssetMenu(menuName = "Spells/BogTrap")]
public class BogTrapSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<Enemy>().onHitFlashWhite();
        AudioManager.instance.Play("Mob Damage");
        Destroy(projectile);

    }
}
