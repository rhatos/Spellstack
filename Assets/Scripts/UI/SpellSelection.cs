using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SpellMenuManager : MonoBehaviour
{
    public Image[] buttonImages;   // images on your buttons
    public Sprite[] spellSprites;  // all 5 spell images

    void Start()
    {
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
}