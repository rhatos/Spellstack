using UnityEngine;

public class SpellSelector : MonoBehaviour
{

    public GameObject spellSelectionScreen;

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
        spellSelectionScreen.SetActive(true);

    }
}
