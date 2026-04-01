using UnityEngine;

public class SpellSelector : MonoBehaviour
{

    public GameObject spellSelectionScreen;
    public GameObject spellSelectorManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       spellSelectionScreen.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate(){

        Debug.Log("Activated");
        spellSelectorManager.GetComponent<SpellMenuManager>().shuffleSpells();
        spellSelectionScreen.SetActive(true);

    }
}
