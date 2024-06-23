
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTrinil : MonoBehaviour
{

//audio
    public AudioClip buttonClickSFX;

    public GameObject infoPanel;
    public GameObject menuPanel;

//scene
    public void LoadGameplayTrinilScene()
    {
        
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        AudioManager.Instance.PauseBGM();
        SceneManager.LoadScene("GameplayTrinil");
    }

    public void LoadMapsMenuScene()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        SceneManager.LoadScene("GameMaps");
    }

    public void OpenRouteTrinil()
     {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        Application.OpenURL("https://maps.app.goo.gl/oPp6N7ixY6Xspr3Q9");
     }
    
    public void ShowInfo()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        infoPanel.SetActive(true);
        menuPanel.SetActive(false);

    } 

    public void HideInfo()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        infoPanel.SetActive(false);
        menuPanel.SetActive(true);

    }
    
}
