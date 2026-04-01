using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Mudslide")]
public class MudslideSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<Enemy>().onHitFlashWhite();
        Destroy(projectile);

    }
}
