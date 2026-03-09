using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Movement Variables
    public float moveSpeed = 5f;
    public bool canDash = true;
    public int dashCooldown = 1;

    // Components
    public Rigidbody2D rb {get; private set;}
    public Animator animator {get; private set;}

    // Inputs
    // Consumed by the states
    public Vector2 MoveInput {get; private set;} // Literally just +1, 0, -1
    public bool DashPressed {get; private set;} // "space"

    // State Machine & States
    private StateMachine stateMachine;
    public PlayerIdleState idleState {get; private set;}
    public PlayerMoveState moveState {get; private set;}
        // Dash State

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        stateMachine = new StateMachine();
        idleState = new PlayerIdleState(stateMachine,this);
        moveState = new PlayerMoveState(stateMachine,this);

        MoveInput = new Vector2(0,0);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Start in idle state
        stateMachine.ChangeState(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        // This feels criminal or can cause performance issues.
        MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        stateMachine.Update(); 
    }

    void FixedUpdate(){
        stateMachine.FixedUpdate();
    }

    public void SetVelocity(Vector2 velocity){
        rb.linearVelocity = velocity;
    }
}
