
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuJamus : MonoBehaviour
{

//audio
    public AudioClip buttonClickSFX;

    public GameObject infoPanel;
    public GameObject menuPanel;

//scene
    public void LoadGameplayJamusScene()
    {
        
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        AudioManager.Instance.PauseBGM();
        SceneManager.LoadScene("GameplayJamus");
    }

    public void LoadMapsMenuScene()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        SceneManager.LoadScene("GameMaps");
    }

    public void OpenRouteJamus()
     {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        Application.OpenURL("https://maps.app.goo.gl/eSMY589oVuC1rzdd8");
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
