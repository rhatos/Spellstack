using UnityEngine;

// Just to differentiate from other states/in case we need to have the player states do something different.
public abstract class PlayerState : State {

    protected PlayerController player;

    public PlayerState(StateMachine stateMachine, PlayerController player) : base(stateMachine) {
        this.player = player;
    }

}
