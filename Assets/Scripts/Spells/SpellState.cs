using UnityEngine;

// Just to differentiate from other states/in case we need to have the spell states do something different.
public abstract class SpellState : State {

    protected SpellController spellController;
    protected PlayerController player;

    public SpellState(StateMachine stateMachine, PlayerController player, SpellController spellController) : base(stateMachine) {
        this.spellController = spellController;
        this.player = player;

    }

}
