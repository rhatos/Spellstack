using UnityEngine;

public class PlayerMoveState : PlayerState {

    // Overridden constructor for states
    public PlayerMoveState(StateMachine stateMachine, PlayerController player) : base(stateMachine, player){
        this.player = player;
    }

    public override void Enter(){
        // Change animation
        // ...
    }

    public override void FixedUpdate(){
        player.SetVelocity(player.MoveInput * player.moveSpeed);
    }

    public override void Update(){
        if(player.DashPressed && player.canDash){
            // Transition to dash state
            return;
        }

        // If we're not pressing anything
        // Switch to idle state.
        if(Mathf.Abs(player.MoveInput.x) < 0.01f && Mathf.Abs(player.MoveInput.y) < 0.01f){
            stateMachine.ChangeState(player.idleState);
            return;
        }
    }

}
