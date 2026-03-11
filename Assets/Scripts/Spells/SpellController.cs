using UnityEngine;
using UnityEngine.InputSystem;

public class SpellController : MonoBehaviour
{

    public PlayerController player;
    
    // State Machine
    private StateMachine stateMachine;
    // State 1: Nothing selected
    public SpellNoneState spellNoneState;

    // State 2: Spell selected
    // State 3: Cast spell or combine spell

    // inputs (probably better way to do this)
    public int spellInput = 0;

    void Awake(){

        stateMachine = new StateMachine();
        spellNoneState = new SpellNoneState(stateMachine, player, this);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stateMachine.ChangeState(spellNoneState);
    }

    // Update is called once per frame
    void Update()
    {
       stateMachine.Update(); 
    }

    void UpdateSpellInput(){

        // Programming SIN
        // Definitely a better way to do this.
        if(Keyboard.current[Key.Digit1].wasPressedThisFrame){
            spellInput = 1;
        } else if(Keyboard.current[Key.Digit2].wasPressedThisFrame){
            spellInput = 2;
        } else if(Keyboard.current[Key.Digit3].wasPressedThisFrame){
            spellInput = 3;
        } else if(Keyboard.current[Key.Digit4].wasPressedThisFrame){
            spellInput = 4;
        } else if(Keyboard.current[Key.Digit5].wasPressedThisFrame){
            spellInput = 5;
        }
        
    }
}
