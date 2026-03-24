using UnityEngine;
using UnityEngine.InputSystem;

public class SpellSelectedState : SpellState {


    // Overridden constructor for states
    public SpellSelectedState(StateMachine stateMachine, PlayerController player, SpellController spellController) : base(stateMachine, player, spellController){
        this.player = player;
        this.spellController = spellController;
    }

    public override void Enter(){
       Debug.Log("SPELL SELECTED: " + spellController.spellInput); 
    }

    public override void Exit(){

    }

    public override void FixedUpdate(){

    }

    public override void Update(){

        if(Keyboard.current[Key.Digit1].wasPressedThisFrame){
            Debug.Log("SPELL SELECTED: " + spellController.spellInput + " + Spell 1 pressed");
            // Then prompt spell controller to create spell object
            spellController.CastSpell(1);
            stateMachine.ChangeState(spellController.spellNoneState);
        } 

        if(Keyboard.current[Key.Digit2].wasPressedThisFrame){
            Debug.Log("SPELL SELECTED: " + spellController.spellInput + " + Spell 2 pressed");
        }

        if(Keyboard.current[Key.Digit3].wasPressedThisFrame){
            Debug.Log("SPELL SELECTED: " + spellController.spellInput + " + Spell 3 pressed");
        }

        if(Keyboard.current[Key.Digit4].wasPressedThisFrame){
            Debug.Log("SPELL SELECTED: " + spellController.spellInput + " + Spell 4 pressed");
        }       
       
        if(Keyboard.current[Key.Digit5].wasPressedThisFrame){
            Debug.Log("SPELL SELECTED: " + spellController.spellInput + " + Spell 5 pressed");
        }
    }

}
