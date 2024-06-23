
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTawun : MonoBehaviour
{

//audio
    public AudioClip buttonClickSFX;

    public GameObject infoPanel;
    public GameObject menuPanel;

//scene
    public void LoadGameplayTawunScene()
    {
        
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        AudioManager.Instance.PauseBGM();
        SceneManager.LoadScene("GameplayTawun");
    }

    public void LoadMapsMenuScene()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        SceneManager.LoadScene("GameMaps");
    }

    public void OpenRouteTawun()
     {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        Application.OpenURL("https://maps.app.goo.gl/6GKxGNkwzfqYY9UC8");
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
