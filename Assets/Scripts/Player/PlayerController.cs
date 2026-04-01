using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Debug Text
    public TextMeshProUGUI stateText;

    // Movement Variables
    public float moveSpeed = 5f;
    public bool canDash = true;
    public float dashSpeed = 10f; // Should rework this such that the distance you can dash is capped.
    public float dashTime = 0.25f; // 0.25 seconds - how long you are dashing for
    public float dashCooldown = 1f; // 1 second cooldown
    public float dashCooldownCurrent = 0f;

    // Aiming Variables
    public Vector2 direction;
    public GameObject cursor;


    // Components
    public Rigidbody2D rb {get; private set;}
    public Animator animator {get; private set;}
    private SpriteRenderer sprite;

    // Inputs
    // Consumed by the states
    public Vector2 MoveInput {get; private set;} // Literally just +1, 0, -1
    public bool DashPressed {get; private set;} // "space"

    // State Machine & States
    private StateMachine stateMachine;
    public PlayerIdleState idleState {get; private set;}
    public PlayerMoveState moveState {get; private set;}
    public PlayerDashState dashState {get; private set;}

    // Each heart holds a quarter
    // There are 6 hearts, so 6x4 = 24
    public int health = 24;
    
    // Mana Bar
    public float maxMana = 200f;
    public float currentMana = 200f;
    public float regenRate = 5f;

    // Hit material
    public Material defaultMat;
    public Material hitMat;


    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        stateMachine = new StateMachine();
        idleState = new PlayerIdleState(stateMachine,this);
        moveState = new PlayerMoveState(stateMachine,this);
        dashState = new PlayerDashState(stateMachine, this);
        MoveInput = new Vector2(0,0);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Start in idle state
        stateMachine.ChangeState(idleState);
        this.sprite = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // This feels criminal or can cause performance issues. But maybe I just don't understand unity. :)
        MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        DashPressed = Input.GetButton("Jump");
        stateMachine.Update(); 

        // Update mouse position and direction
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // This can cause lag but only in the editor
        cursor.GetComponent<Transform>().position = new Vector2(mousePos.x, mousePos.y);
        direction = mousePos - transform.position;

        // Dash Cooldown
        if(!canDash){
           dashCooldownCurrent += Time.deltaTime; 
           if(dashCooldownCurrent > dashCooldown){
               canDash = true;
               dashCooldownCurrent = 0f;
           }
        }

        // Debug related
        stateText.text = "State: " + stateMachine.CurrentState.ToString();
        Debug.DrawRay(transform.position,direction,Color.red);

        if(currentMana < maxMana){
            currentMana += regenRate * Time.deltaTime;
        }

    }

    void FixedUpdate(){
        stateMachine.FixedUpdate();
    }

    public void SetVelocity(Vector2 velocity){
        rb.linearVelocity = velocity;
    }

    public void getHit(int damage){
        health -= damage;
        StartCoroutine(FlashWhite());
    }

    IEnumerator FlashWhite(){

        this.sprite.material = hitMat;

        yield return new WaitForSeconds(0.2f);

        this.sprite.material = defaultMat;

    }


}
