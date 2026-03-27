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

        // Normalize to prevent going faster in diagonals
        player.SetVelocity(player.MoveInput.normalized * player.moveSpeed);
    }

    public override void Update(){
        if(player.DashPressed && player.canDash){
            // Transition to dash state
            player.SetVelocity(Vector2.zero);
            stateMachine.ChangeState(player.dashState);
            return;
        }

        // Update direction
        if(player.MoveInput.x == 1) player.animator.SetInteger("inDirection", 2);
        if(player.MoveInput.x == -1) player.animator.SetInteger("inDirection", 1);
        if(player.MoveInput.y == 1) player.animator.SetInteger("inDirection", 0);
        if(player.MoveInput.y == -1) player.animator.SetInteger("inDirection", 3);

        // up = 0,1 down = 0,-1, right = 1,0, left = -1,0

        Debug.Log(player.MoveInput);

        // If we're not pressing anything
        // Switch to idle state.
        if(Mathf.Abs(player.MoveInput.x) < 0.01f && Mathf.Abs(player.MoveInput.y) < 0.01f){
            stateMachine.ChangeState(player.idleState);
            return;
        }
    }

}
