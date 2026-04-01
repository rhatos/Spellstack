using UnityEngine;

[CreateAssetMenu(menuName = "Spells/BogTrap")]
public class BogTrapSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

<<<<<<< HEAD
        target.GetComponent<Enemy>().onHitFlashWhite();
        AudioManager.instance.Play("Mob Damage");
        Destroy(projectile);
=======
        target.GetComponent<Enemy>().onHitFlashWhite(0);
        target.GetComponent<Enemy>().rootInPlace(5f);
>>>>>>> conor

    }

    public override void FixedUpdate(){}
}
