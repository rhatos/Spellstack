using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{

    // 0 = full heart
    // 1 = quarter missing
    // 2 = half
    // 3 = quarter remaining
    // 4 = empty
    public List<Sprite> heartStates = new List<Sprite>();
    public int state = 0;


    private Image sprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       this.sprite = this.GetComponent<Image>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setHeart(int heart){
        sprite.sprite = heartStates[heart];
        state = heart;
    }
}
