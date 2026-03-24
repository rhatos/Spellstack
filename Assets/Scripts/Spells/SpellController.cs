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

    public int spellInput = 0; // Set by states, value from 0 to 4

    public SpellData[] equippedSpells;

    public SpellData currentSpell; // Actual spell cast, can be the combo or normal

    public SpellCatalog spellCatalogue;

    void Awake(){

        stateMachine = new StateMachine();
        spellNoneState = new SpellNoneState(stateMachine, player, this);
        spellSelectedState = new SpellSelectedState(stateMachine, player, this);

        equippedSpells = new SpellData[5];

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stateMachine.ChangeState(spellNoneState);

        equippedSpells[0] = spellCatalogue.getSpellByID(1);
        equippedSpells[1] = spellCatalogue.getSpellByID(2);

    }

    // Update is called once per frame
    void Update()
    {
       stateMachine.Update(); 
       stateText.text = "Spell State: " + stateMachine.CurrentState.ToString() + " | " + spellInput;
       if(currentSpell != null) currentSpell.direction = player.direction;
    }


    public void CastSpell(int combo){

        // Include logic to determine which spell to cast.
        if(spellInput != combo){
            //... handle combo
            // Just hardcoding for now, will implement a better system later
            if(spellInput + combo == 3){
                currentSpell = spellCatalogue.getSpellByID(6);
                GameObject spellObject = Instantiate(currentSpell.projectilePrefab, player.transform.position, player.transform.rotation);
                Spell spellProjectile = spellObject.GetComponent<Spell>();
                spellProjectile.spellData = currentSpell;
                Destroy(spellObject, 5f);
            }
        } else {
            if(equippedSpells[spellInput-1] != null){
                currentSpell = equippedSpells[spellInput-1];
                GameObject spellObject = Instantiate(currentSpell.projectilePrefab, player.transform.position, player.transform.rotation);
                Spell spellProjectile = spellObject.GetComponent<Spell>();
                spellProjectile.spellData = currentSpell;
                Destroy(spellObject, 5f);
            } else {
                Debug.Log("Out of bounds/no spell equipped");
            }
        }

    }
}
