using UnityEngine;

[CreateAssetMenu(menuName = "Spells/WindBlast")]
public class WindBlastSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<Enemy>().onHitFlashWhite(0);
        target.GetComponent<Enemy>().onHitKnockBack(this.direction,10f);
        Destroy(projectile);

    }

    public override void FixedUpdate(){}
}
