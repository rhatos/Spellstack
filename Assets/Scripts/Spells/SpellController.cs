using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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

    private Dictionary<(int, int), int> comboDictionary;
    private static readonly HashSet<int> groundSpawnIDs = new HashSet<int> { 4, 9, 10, 13, 14, 15, 11 };
    // Vine(4), Rock Spikes(9), Mudslide(10), Burning Vines (11), Vine Cyclone(13), Bog Trap(15)


    void Awake(){

        stateMachine = new StateMachine();
        spellNoneState = new SpellNoneState(stateMachine, player, this);
        spellSelectedState = new SpellSelectedState(stateMachine, player, this);

        equippedSpells = new SpellData[5];

        comboDictionary = new Dictionary<(int, int), int>() {
        { (1, 2), 6 },  // FIREBALL
        { (1, 3), 7 },  // ROCK VOLLEY
        { (2, 3), 8 },  // PHOENIX
        { (1, 4), 9 },  // ROCK SPIKES
        { (1, 5), 10 }, // MUDSLIDE
        { (2, 4), 11 }, // BURNING VINES
        { (2, 5), 12 }, // STEAM EXPLOSION
        { (3, 4), 13 }, // VINE CYCLONE
        { (3, 5), 14 }, // LIGHTNING STRIKE
        { (4, 5), 15 }, // BOG TRAP
    };

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stateMachine.ChangeState(spellNoneState);

        equippedSpells[0] = spellCatalogue.getSpellByID(1); //change to id of spell combo for testing
        // equippedSpells[1] = spellCatalogue.getSpellByID(2);
        // equippedSpells[2] = spellCatalogue.getSpellByID(3);
        // equippedSpells[3] = spellCatalogue.getSpellByID(4);
        // equippedSpells[4] = spellCatalogue.getSpellByID(5);
        //add other slots to 5
        initSpellSlots();
        //ID 1: ROCK SPELL
        //ID 2: FIREBLAST
        //ID 3: WIND GUST
        //ID 4: VINE SPELL
        //ID 5: WATER STRIKE


    }

    // Update is called once per frame
    void Update()
    {
       stateMachine.Update(); 
       float angle = Mathf.Atan2(player.direction.y, player.direction.x) * Mathf.Rad2Deg;
       stateText.text = "Spell State: " + angle + " | " + spellInput;
        if (currentSpell != null)
        {
            if (currentSpell.changeDirection == true)
            {
                currentSpell.direction = player.direction; //this is probably making cursor spells skew
            }
            else 
            {
                currentSpell.direction = new Vector2(0,0);            
            }
        }
           
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

    private void InstantiateSpell(SpellData spell)
    {
        Vector3 spawnPos = groundSpawnIDs.Contains(spell.id)
            ? cursor.transform.position
            : player.transform.position;

        GameObject spellObject = Instantiate(spell.projectilePrefab, spawnPos, player.transform.rotation);
        spellObject.GetComponent<Spell>().spellData = spell;

        if (groundSpawnIDs.Contains(spell.id))
        {
            Rigidbody2D rb = spellObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.bodyType = RigidbodyType2D.Kinematic; // prevents any physics from moving it
            }
        }
    }

    //combo is the most recent hot bar number
    public void CastSpell(int combo)
    {

        if (spellInput != combo)
        {
            var key = (Mathf.Min(spellInput, combo), Mathf.Max(spellInput, combo));
            //check mapping to dictionary
            if (comboDictionary.TryGetValue(key, out int comboSpellID))
            {
                currentSpell = spellCatalogue.getSpellByID(comboSpellID);
                if (player.currentMana > currentSpell.manaCost)
                {
                    InstantiateSpell(currentSpell);
                    player.currentMana -= currentSpell.manaCost;
                }
                //else { } play sound
                
            }
            else
            {
                Debug.Log($"No combo found for spells {spellInput} and {combo}");
            }
        }
        else
        {
            if (equippedSpells[spellInput - 1] != null)
            {
                currentSpell = equippedSpells[spellInput - 1];
                if (player.currentMana > currentSpell.manaCost) 
                {
                    InstantiateSpell(currentSpell);
                    player.currentMana -= currentSpell.manaCost;
                }
                //else { } play sound

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

        if(equippedSpells[0] != null){
            spellSlot1.GetComponent<Animator>().enabled = false;
            spellSlot1.sprite = equippedSpells[0].icon;
        }

        if(equippedSpells[1] != null){
            spellSlot2.GetComponent<Animator>().enabled = false;
            spellSlot2.sprite = equippedSpells[1].icon;
        }

        if(equippedSpells[2] != null){
            spellSlot3.GetComponent<Animator>().enabled = false;
            spellSlot3.sprite = equippedSpells[2].icon;
        }
        //
        if(equippedSpells[3] != null){
            spellSlot4.GetComponent<Animator>().enabled = false;
            spellSlot4.sprite = equippedSpells[3].icon;
        }
        //
        if(equippedSpells[4] != null){
            spellSlot5.GetComponent<Animator>().enabled = false;
            spellSlot5.sprite = equippedSpells[4].icon;
        }
    }
}
