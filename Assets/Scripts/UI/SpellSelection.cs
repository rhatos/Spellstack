using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class SpellMenuManager : MonoBehaviour
{
    public Image[] buttonImages;   // images on your buttons
    public Sprite[] spellSprites;  // all 5 spell images
    public List<SpellData> spells;

    public PlayerController player;
    public SpellController spellController;

    public Button spellButton1;
    public Button spellButton2;
    public Button spellButton3;

    List<SpellData> spellChoices = new List<SpellData>();

    void Start()
    {

        spellButton1.onClick.AddListener(() => selectSpell(0));
        spellButton2.onClick.AddListener(() => selectSpell(1));
        spellButton3.onClick.AddListener(() => selectSpell(2));

    }

    void selectSpell(int index){


        SpellData s = spellChoices[index];
        Debug.Log("Selected: " + s.id);

        int idx = 0;
        foreach(SpellData datas in spellController.equippedSpells){
            if(datas == null){

                spellController.equippedSpells[idx] = s;
                spellController.initSpellSlots();
                break;

            }
            idx++;
        }

        Debug.Log("Selected: " + index);
        this.transform.parent.transform.parent.gameObject.SetActive(false);

        Time.timeScale = 1f;
    }

    public void shuffleSpells(){

        spellChoices.Clear();
        Dictionary<int,SpellData> spellCatalog = new Dictionary<int, SpellData>();
        Dictionary<int,Sprite> spriteImageToId = new Dictionary<int, Sprite>();

        int idx = 0;
        foreach(SpellData s in spells){
            spellCatalog.Add(s.id,s);
            spriteImageToId.Add(s.id,spellSprites[idx]);
            idx++;
        }

        // Check what spells player has
        foreach(SpellData s in spellController.equippedSpells){
            if(s != null){
                if(spriteImageToId.ContainsKey(s.id)) spriteImageToId.Remove(s.id);
            }
        }

        // Left with a dict with unknown spells
        // Choose 3 at random
        for(int i = 0; i < 3; i++){

            int randomIndex = Random.Range(0,spriteImageToId.Count);
            var randomSpell = spriteImageToId.ElementAt(randomIndex);
            Debug.Log(randomSpell.Key);
            buttonImages[i].sprite = randomSpell.Value;
            spellChoices.Add(spellController.spellCatalogue.getSpellByID(randomSpell.Key));
        }

    }
}
