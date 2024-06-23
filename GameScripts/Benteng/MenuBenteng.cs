
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBenteng : MonoBehaviour
{

//audio
    public AudioClip buttonClickSFX;

    public GameObject infoPanel;
    public GameObject menuPanel;

//scene
    public void LoadGameplayBentengScene()
    {
        
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        AudioManager.Instance.PauseBGM();
        SceneManager.LoadScene("GameplayBenteng");
    }

    public void LoadMapsMenuScene()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        SceneManager.LoadScene("GameMaps");
    }

    public void OpenRouteBenteng()
     {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        Application.OpenURL("https://maps.app.goo.gl/rQjxNZxiNqbaui6b6");
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
