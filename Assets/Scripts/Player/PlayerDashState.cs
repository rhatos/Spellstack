using UnityEngine;

public class PlayerDashState : PlayerState {

    // How long dashing has been occuring
    private float currentTime = 0f;
    private Vector2 currentPlayerDirection;

    // Overridden constructor for states
    public PlayerDashState(StateMachine stateMachine, PlayerController player) : base(stateMachine, player){
        this.player = player;
    }

    public override void Enter(){
        // Change animation
        // ...

        // Ensure the player cannot dash again while in this state.
        player.canDash = false;
        currentPlayerDirection = player.direction;
        currentTime = 0f;
        
    }


    public override void Exit(){

        player.SetVelocity(Vector2.zero);

    }

    public override void FixedUpdate(){

        player.SetVelocity(currentPlayerDirection.normalized * player.dashSpeed);
    }

    public override void Update(){
        currentTime += Time.deltaTime;
        if(currentTime > player.dashTime){
            // Exit state
            // If we're not pressing anything
            // Switch to idle state.
            if(Mathf.Abs(player.MoveInput.x) < 0.01f && Mathf.Abs(player.MoveInput.y) < 0.01f){
                stateMachine.ChangeState(player.idleState);
                return;
            } else {
                stateMachine.ChangeState(player.moveState);
                return;
            }
        }
        
    }

}
