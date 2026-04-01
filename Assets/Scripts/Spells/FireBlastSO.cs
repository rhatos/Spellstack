using UnityEngine;

[CreateAssetMenu(menuName = "Spells/FireBlast")]
public class FireBlastSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<Enemy>().onHitFlashWhite(damage);
        Destroy(projectile);

    }

    public override void FixedUpdate(){}
}
