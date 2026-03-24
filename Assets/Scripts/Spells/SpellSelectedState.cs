using UnityEngine;
using UnityEngine.InputSystem;

public class SpellSelectedState : SpellState {


    // Overridden constructor for states
    public SpellSelectedState(StateMachine stateMachine, PlayerController player, SpellController spellController) : base(stateMachine, player, spellController){
        this.player = player;
        this.spellController = spellController;
    }

    public override void Enter(){}

    public override void Exit(){

    }

    public override void FixedUpdate(){

    }

    public override void Update(){

        if(Keyboard.current[Key.Digit1].wasPressedThisFrame){

            // Then prompt spell controller to create spell object from keybind 1
            spellController.CastSpell(1);

            // Change state back to no spell selected
            stateMachine.ChangeState(spellController.spellNoneState);
        } 

        else if(Keyboard.current[Key.Digit2].wasPressedThisFrame){

            // Then prompt spell controller to create spell object from keybind 1
            spellController.CastSpell(2);

            // Change state back to no spell selected
            stateMachine.ChangeState(spellController.spellNoneState);
        }

        else if(Keyboard.current[Key.Digit3].wasPressedThisFrame){

            // Then prompt spell controller to create spell object from keybind 1
            spellController.CastSpell(3);

            // Change state back to no spell selected
            stateMachine.ChangeState(spellController.spellNoneState);
        }

        else if(Keyboard.current[Key.Digit4].wasPressedThisFrame){

            // Then prompt spell controller to create spell object from keybind 1
            spellController.CastSpell(4);

            // Change state back to no spell selected
            stateMachine.ChangeState(spellController.spellNoneState);
        }       
       
        else if(Keyboard.current[Key.Digit5].wasPressedThisFrame){

            // Then prompt spell controller to create spell object from keybind 1
            spellController.CastSpell(5);

            // Change state back to no spell selected
            stateMachine.ChangeState(spellController.spellNoneState);
        }
    }

}
