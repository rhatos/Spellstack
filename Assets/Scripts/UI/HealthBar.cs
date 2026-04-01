using UnityEngine;
using System.Collections.Generic;

public class HealthBar : MonoBehaviour
{

    public PlayerController player;
    public List<Heart> hearts = new List<Heart>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            int filled = player.health - i * 4;
            int quarters = Mathf.Clamp(filled, 0, 4);
            hearts[i].setHeart(4 - quarters);
        }
    }
}
