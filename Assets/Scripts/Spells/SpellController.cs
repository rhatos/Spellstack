using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class SpellController : MonoBehaviour
{
    public TextMeshProUGUI stateText;

    public PlayerController player;
    
    // State Machine
    private StateMachine stateMachine;
    // State 1: Nothing selected
    public SpellNoneState spellNoneState;

    // State 2: Spell selected
    public SpellSelectedState spellSelectedState;
    // State 3: Cast spell or combine spell

    // inputs (probably better way to do this)
    public int spellInput = 0;
    public SpellData currentSpell;

    void Awake(){

        stateMachine = new StateMachine();
        spellNoneState = new SpellNoneState(stateMachine, player, this);
        spellSelectedState = new SpellSelectedState(stateMachine, player, this);
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
       stateText.text = "Spell State: " + stateMachine.CurrentState.ToString() + " | " + spellInput;
       if(currentSpell != null) currentSpell.direction = player.direction;
    }


    public void CastSpell(int combo){
        Debug.Log("CASTING: " + spellInput + " + " + combo);

        // Include logic to determine which spell to cast.

        GameObject spellObject = Instantiate(currentSpell.projectilePrefab, player.transform.position, player.transform.rotation);
        Spell spellProjectile = spellObject.GetComponent<Spell>();
        spellProjectile.spellData = currentSpell;
        Destroy(spellObject, 5f);
    }
}
