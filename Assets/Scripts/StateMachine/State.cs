using UnityEngine;

public abstract class State
{

    protected StateMachine stateMachine;

    public State(StateMachine stateMachine){

        this.stateMachine = stateMachine;

    }

    // Called once when entering states
    public virtual void Enter(){}

    // Updates every frame when in this state.
    public virtual void Update(){}

    // For unity physics stuff updating
    public virtual void FixedUpdate(){}

    // Called once when exiting this state.
    public virtual void Exit(){}
}
