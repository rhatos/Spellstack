using UnityEngine;
using UnityEngine.InputSystem;

public class SpellNoneState : SpellState {


    // Overridden constructor for states
    public SpellNoneState(StateMachine stateMachine, PlayerController player, SpellController spellController) : base(stateMachine, player, spellController){
        this.player = player;
        this.spellController = spellController;
    }

    public override void Enter(){
       spellController.spellInput = 0; 
    }

    public override void Exit(){

    }

    public override void FixedUpdate(){

    }

    public override void Update(){

        if(Keyboard.current[Key.Digit1].wasPressedThisFrame){
            spellController.spellInput = 1;
            stateMachine.ChangeState(spellController.spellSelectedState);
        } 

        if(Keyboard.current[Key.Digit2].wasPressedThisFrame){
            spellController.spellInput = 2;
            stateMachine.ChangeState(spellController.spellSelectedState);
        }

        if(Keyboard.current[Key.Digit3].wasPressedThisFrame){
            spellController.spellInput = 3;
            stateMachine.ChangeState(spellController.spellSelectedState);
        }

        if(Keyboard.current[Key.Digit4].wasPressedThisFrame){
            spellController.spellInput = 4;
            stateMachine.ChangeState(spellController.spellSelectedState);
        }       
       
        if(Keyboard.current[Key.Digit5].wasPressedThisFrame){
            spellController.spellInput = 5;
            stateMachine.ChangeState(spellController.spellSelectedState);
        }
    }

}
