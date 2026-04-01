using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SpellMenuManager : MonoBehaviour
{
    public Image[] buttonImages;   // images on your buttons
    public Sprite[] spellSprites;  // all 5 spell images

    public PlayerController player;
    public SpellController spellController;

    public Button spellButton1;
    public Button spellButton2;
    public Button spellButton3;

    void Start()
    {

        spellButton1.onClick.AddListener(() => selectSpell(0));
        spellButton2.onClick.AddListener(() => selectSpell(1));
        spellButton3.onClick.AddListener(() => selectSpell(2));

        List<Sprite> shuffled = new List<Sprite>(spellSprites);

        // Shuffle the list
        for (int i = 0; i < shuffled.Count; i++)
        {
            Sprite temp = shuffled[i];
            int randomIndex = Random.Range(i, shuffled.Count);
            shuffled[i] = shuffled[randomIndex];
            shuffled[randomIndex] = temp;
        }

        // Assign unique images to buttons
        for (int i = 0; i < buttonImages.Length; i++)
        {
            buttonImages[i].sprite = shuffled[i];
        }
    }

    void selectSpell(int index){

        Debug.Log("Selected: " + index);
        this.transform.parent.transform.parent.gameObject.SetActive(false);

        Time.timeScale = 1f;
    }
}
