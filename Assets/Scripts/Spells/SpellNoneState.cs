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
       Debug.Log("NONE SELECTED");
    }

    public override void Exit(){

    }

    public override void FixedUpdate(){

    }

    public override void Update(){

        if(Keyboard.current[Key.Digit1].wasPressedThisFrame){
            Debug.Log("NONE: Spell 1 pressed");
            spellController.spellInput = 1;
            stateMachine.ChangeState(spellController.spellSelectedState);
        } 

        if(Keyboard.current[Key.Digit2].wasPressedThisFrame){
            Debug.Log("NONE: Spell 2 pressed");
            spellController.spellInput = 2;
        }

        if(Keyboard.current[Key.Digit3].wasPressedThisFrame){
            Debug.Log("NONE: Spell 3 pressed");
            spellController.spellInput = 3;
        }

        if(Keyboard.current[Key.Digit4].wasPressedThisFrame){
            Debug.Log("NONE: Spell 4 pressed");
            spellController.spellInput = 4;
        }       
       
        if(Keyboard.current[Key.Digit5].wasPressedThisFrame){
            Debug.Log("NONE: Spell 5 pressed");
            spellController.spellInput = 5;
        }
    }

}
