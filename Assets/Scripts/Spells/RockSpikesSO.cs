using UnityEngine;

[CreateAssetMenu(menuName = "Spells/RockSpikes")]
public class RockSpikesSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<Enemy>().onHitFlashWhite(damage);
        target.GetComponent<Enemy>().slowBriefly(3f,4f);

        Destroy(projectile.transform.gameObject,3f);

    }

    public override void FixedUpdate(){}
}
