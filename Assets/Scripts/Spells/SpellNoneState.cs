using UnityEngine;
using UnityEngine.InputSystem;

public class SpellNoneState : SpellState {


    // Overridden constructor for states
    public SpellNoneState(StateMachine stateMachine, PlayerController player, SpellController spellController) : base(stateMachine, player, spellController){
        this.player = player;
        this.spellController = spellController;
    }

    public override void Enter(){
        
    }

    public override void Exit(){

    }

    public override void FixedUpdate(){

    }

    public override void Update(){

        if(Keyboard.current[Key.Digit5].wasPressedThisFrame){
            Debug.Log("Spell pressed");
        }
       
    }

}
