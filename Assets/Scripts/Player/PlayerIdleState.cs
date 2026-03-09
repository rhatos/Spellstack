using UnityEngine;

public class PlayerIdleState : PlayerState {

    // Overridden constructor for states
    public PlayerIdleState(StateMachine stateMachine, PlayerController player) : base(stateMachine, player){
        this.player = player;
    }

    public override void Enter(){
        // Stop moving 
        player.SetVelocity(new Vector2(0,0)); 
    }

    public override void Update(){
        if(player.DashPressed && player.canDash){
            // Transition to dash state
            return;
        }

        // If movement input is pressed
        // Absolute it for the -1 case
        if(Mathf.Abs(player.MoveInput.x) > 0.01f || Mathf.Abs(player.MoveInput.y) > 0.01f){
            // Transition to move state
            stateMachine.ChangeState(player.moveState);
            return;

        }
    }

}
