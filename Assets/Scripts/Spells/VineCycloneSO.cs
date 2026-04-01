using UnityEngine;

[CreateAssetMenu(menuName = "Spells/VineCyclone")]
public class VineCycloneSO : SpellData
{

    public override void OnHit(GameObject target, GameObject projectile){

        target.GetComponent<Enemy>().onHitFlashWhite(3);

    }

    public override void FixedUpdate(){
        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f) Destroy(this.rb.transform.gameObject);
    }
}
