using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class SpellController : MonoBehaviour
{

    // DEBUG
    public TextMeshProUGUI stateText;
    //

    // Spell Slots in the UI:
    public Image spellSlot1;
    public Image spellSlot2;
    public Image spellSlot3;
    public Image spellSlot4;
    public Image spellSlot5;
    //

    public PlayerController player;
    public GameObject cursor;
    
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

        equippedSpells[0] = spellCatalogue.getSpellByID(12); //change to id of spell combo for testing
        equippedSpells[1] = spellCatalogue.getSpellByID(2);
        equippedSpells[2] = spellCatalogue.getSpellByID(3);
        equippedSpells[3] = spellCatalogue.getSpellByID(4);
        equippedSpells[4] = spellCatalogue.getSpellByID(5);
        //add other slots to 5
        initSpellSlots();

    }

    // Update is called once per frame
    void Update()
    {
       stateMachine.Update(); 
       float angle = Mathf.Atan2(player.direction.y, player.direction.x) * Mathf.Rad2Deg;
       stateText.text = "Spell State: " + angle + " | " + spellInput;
       if(currentSpell != null) currentSpell.direction = player.direction;
       if(spellInput != 0){
           cursor.transform.Rotate(Vector3.forward * 150f * Time.deltaTime);
       } else {
           cursor.transform.rotation = player.transform.rotation;
       }

       updateSpellSlots();
    }

    /*
     * 120 - 60 = up
     * 120 to -150 = left 
     * 60 to -30 = right
     * -150 to -30 = down
     */
    
    //combo is the most recent hot bar number
    public void CastSpell(int combo){

        // Include logic to determine which spell to cast.
        if(spellInput != combo){
            //... handle combo
            // Just hardcoding for now, will implement a better system later
            //spellInput and combo are spells 1 and 2
            if(spellInput + combo == 3){
                //change the getSpellByID(n) to the spell id
                currentSpell = spellCatalogue.getSpellByID(6);
                GameObject spellObject = Instantiate(currentSpell.projectilePrefab, player.transform.position, player.transform.rotation);
                Spell spellProjectile = spellObject.GetComponent<Spell>();
                spellProjectile.spellData = currentSpell;
            }

            if(spellInput + combo == 4){
                currentSpell = spellCatalogue.getSpellByID(7);
                GameObject spellObject = Instantiate(currentSpell.projectilePrefab, player.transform.position, player.transform.rotation);
                Spell spellProjectile = spellObject.GetComponent<Spell>();
                spellProjectile.spellData = currentSpell;
            }

            if(spellInput + combo == 5){
                currentSpell = spellCatalogue.getSpellByID(8);
                GameObject spellObject = Instantiate(currentSpell.projectilePrefab, player.transform.position, player.transform.rotation);
                Spell spellProjectile = spellObject.GetComponent<Spell>();
                spellProjectile.spellData = currentSpell;
            }

        } else {
            if(equippedSpells[spellInput-1] != null){
                currentSpell = equippedSpells[spellInput-1];
                GameObject spellObject = Instantiate(currentSpell.projectilePrefab, player.transform.position, player.transform.rotation);
                Spell spellProjectile = spellObject.GetComponent<Spell>();
                spellProjectile.spellData = currentSpell;
            } else {
                Debug.Log("Out of bounds/no spell equipped");
            }
        }

        spellInput = 0;

    }

    public void updateSpellSlots(){

        // Check where each spell is
        if(spellInput == 1){
            spellSlot1.GetComponent<Animator>().enabled = true;
            spellSlot1.GetComponent<Animator>().SetBool("isSelected", true);
            spellSlot1.GetComponent<Animator>().SetInteger("spellChoice", 1);
        }

        if(spellInput == 2){
            spellSlot2.GetComponent<Animator>().enabled = true;
            spellSlot2.GetComponent<Animator>().SetBool("isSelected", true);
            spellSlot2.GetComponent<Animator>().SetInteger("spellChoice", 2);
        } 

        if(spellInput == 3){
            spellSlot3.GetComponent<Animator>().enabled = true;
            spellSlot3.GetComponent<Animator>().SetBool("isSelected", true);
            spellSlot3.GetComponent<Animator>().SetInteger("spellChoice", 3);
        }

        if(spellInput == 0) {
            spellSlot2.GetComponent<Animator>().SetBool("isSelected", false);
            spellSlot1.GetComponent<Animator>().SetBool("isSelected", false);
            initSpellSlots();
        }


    }

    public void initSpellSlots(){

        // Set to false to change sprite initially.
        // Really hacky fix but unity sucks.
        //
        spellSlot1.GetComponent<Animator>().enabled = false;
        spellSlot1.sprite = equippedSpells[0].icon;

        spellSlot2.GetComponent<Animator>().enabled = false;
        spellSlot2.sprite = equippedSpells[1].icon;

        //
        spellSlot3.GetComponent<Animator>().enabled = false;
        spellSlot3.sprite = equippedSpells[2].icon;
        //
         spellSlot4.GetComponent<Animator>().enabled = false;
        spellSlot4.sprite = equippedSpells[3].icon;
        //
        spellSlot5.GetComponent<Animator>().enabled = false;
        spellSlot5.sprite = equippedSpells[4].icon;
    }
}
