using UnityEngine;

public abstract class SpellData : ScriptableObject
{
    [Header("General")]
    public string spellName;
    public GameObject projectilePrefab;
    public int manaCost;
    public Sprite icon;
    public float speed;
    public int id;
    public Vector2 direction;

    public abstract void OnHit(GameObject target, GameObject projectile);

}
