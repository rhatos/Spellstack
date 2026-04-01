using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject controlsPanel;
    public GameObject storyPanel;
    
    [Header("Fade Settings")]
    public Image panelBackground;    
    public TextMeshProUGUI storyText; 
    public float fadeSpeed = 2.0f;
    public float waitTime = 3.0f;

    public void StartGame()
    {
        storyPanel.SetActive(true);
        SetTextAlpha(0f); 
        
        StartCoroutine(StorySequence());
    }

    private IEnumerator StorySequence()
    {
        // FADE IN
        float alpha = 0f;
        while (alpha < 1.0f)
        {
            alpha += Time.deltaTime * fadeSpeed;
            SetTextAlpha(alpha);
            yield return null;
        }
        SetTextAlpha(1.0f);

        // WAIT
        yield return new WaitForSeconds(waitTime);

        // FADE OUT
        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            SetTextAlpha(alpha);
            yield return null;
        }
        SetTextAlpha(0f);

        // SWITCH TO GAME
        SceneManager.LoadScene("SampleScene");
    }

    private void SetTextAlpha(float alpha)
    {
        float clampedAlpha = Mathf.Clamp01(alpha);

        if (storyText != null)
        {
            Color tCol = storyText.color;
            tCol.a = clampedAlpha;
            storyText.color = tCol;
        }
    }

    public void QuitGame() => Application.Quit();
    public void ShowControls() => controlsPanel.SetActive(true);
    public void HideControls() => controlsPanel.SetActive(false);
}
