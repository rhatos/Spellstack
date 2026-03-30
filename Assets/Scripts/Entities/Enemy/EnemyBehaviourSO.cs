using UnityEngine;

/*
 * enemy ai scriptable object
 * i.e: enemy attacks etc
 * But also attributes related to an enemy
 *
 */
public abstract class EnemyBehaviourSO : ScriptableObject
{

    public string enemyName;
    public float health;
    public float damage;
    public GameObject enemyPrefab;

    // Update is called once per frame
    public abstract void Update();
    public abstract void FixedUpdate();

    // Declare whatever in the inherited class, then put into update/fixed update.
}
