using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManaBar : MonoBehaviour
{

    public RectTransform fullBar;
    public PlayerController player;
    public TMP_Text manaText;

    public float barWidth = 220;
    public float barHeight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       barHeight = fullBar.sizeDelta.y; 
    }

    // Update is called once per frame
    void Update()
    {
       float width = (player.currentMana / player.maxMana) * barWidth;
       fullBar.sizeDelta = new Vector2(width, barHeight);
       manaText.text = Mathf.RoundToInt(player.currentMana) + " / " + player.maxMana;
    }
}
