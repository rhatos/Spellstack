using UnityEngine;

[CreateAssetMenu(menuName = "Spells/BurningVines")]
public class BurningVinesSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<Enemy>().onHitFlashWhite(1);
        target.GetComponent<Enemy>().rootInPlace(2f);

        Destroy(projectile.transform.gameObject,2f);

    }

    public override void FixedUpdate(){}
}
