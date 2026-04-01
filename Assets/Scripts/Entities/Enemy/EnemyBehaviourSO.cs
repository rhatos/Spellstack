using UnityEngine;
using System;

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
    public bool knockedBack = false;
    [NonSerialized] public int state = 0;
    [NonSerialized] public int prevState = 0;

    [NonSerialized] public Animator anim;
    [NonSerialized] public SpriteRenderer sprite;
    [NonSerialized] public Rigidbody2D rb;
    public PlayerController player;
    public float moveSpeed;


    // Update is called once per frame
    public abstract void Update();
    public abstract void FixedUpdate();

    // Declare whatever in the inherited class, then put into update/fixed update.
}
