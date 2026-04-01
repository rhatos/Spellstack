using UnityEngine;

[CreateAssetMenu(menuName = "Spells/WindBlast")]
public class WindBlastSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<Enemy>().onHitFlashWhite();
        target.GetComponent<Enemy>().onHitKnockBack(this.direction);
        Destroy(projectile);

    }
}
