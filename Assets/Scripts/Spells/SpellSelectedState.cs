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

            // Then prompt spell controller to create spell object from keybind 1
            spellController.CastSpell(1);

            // Change state back to no spell selected
            stateMachine.ChangeState(spellController.spellNoneState);
        } 

        if(Keyboard.current[Key.Digit2].wasPressedThisFrame){
            Debug.Log("SPELL SELECTED: " + spellController.spellInput + " + Spell 2 pressed");

            // Then prompt spell controller to create spell object from keybind 1
            spellController.CastSpell(2);

            // Change state back to no spell selected
            stateMachine.ChangeState(spellController.spellNoneState);
        }

        if(Keyboard.current[Key.Digit3].wasPressedThisFrame){
            Debug.Log("SPELL SELECTED: " + spellController.spellInput + " + Spell 3 pressed");

            // Then prompt spell controller to create spell object from keybind 1
            spellController.CastSpell(3);

            // Change state back to no spell selected
            stateMachine.ChangeState(spellController.spellNoneState);
        }

        if(Keyboard.current[Key.Digit4].wasPressedThisFrame){
            Debug.Log("SPELL SELECTED: " + spellController.spellInput + " + Spell 4 pressed");

            // Then prompt spell controller to create spell object from keybind 1
            spellController.CastSpell(4);

            // Change state back to no spell selected
            stateMachine.ChangeState(spellController.spellNoneState);
        }       
       
        if(Keyboard.current[Key.Digit5].wasPressedThisFrame){
            Debug.Log("SPELL SELECTED: " + spellController.spellInput + " + Spell 5 pressed");

            // Then prompt spell controller to create spell object from keybind 1
            spellController.CastSpell(5);

            // Change state back to no spell selected
            stateMachine.ChangeState(spellController.spellNoneState);
        }
    }

}
