using UnityEngine;

[CreateAssetMenu(menuName = "Spells/VineCyclone")]
public class VineCycloneSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<Enemy>().onHitFlashWhite();
        Destroy(projectile);

    }
}
