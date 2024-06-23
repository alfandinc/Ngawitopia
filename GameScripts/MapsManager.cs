
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapsMenu : MonoBehaviour
{
    //audio
    public AudioClip buttonClickSFX;

    //trophy
    public GameObject trophyBenteng;
    public GameObject trophyTawun;
    public GameObject trophyJamus;
    public GameObject trophyTrinil;

    void Start()
{
    int clearBenteng = PlayerPrefs.GetInt("TitleBenteng", 0);
    int clearTawun = PlayerPrefs.GetInt("TitleTawun", 0);
    int clearJamus = PlayerPrefs.GetInt("TitleJamus", 0);
    int clearTrinil = PlayerPrefs.GetInt("TitleTrinil", 0);

    if (clearBenteng == 1)
    {
        trophyBenteng.SetActive(true);
    }
    else
    {
        trophyBenteng.SetActive(false);
    }

    if (clearTawun == 1)
    {
        trophyTawun.SetActive(true);
    }
    else
    {
        trophyTawun.SetActive(false);
    }

    if (clearJamus == 1)
    {
        trophyJamus.SetActive(true);
    }
    else
    {
        trophyJamus.SetActive(false);
    }

    if (clearTrinil == 1)
    {
        trophyTrinil.SetActive(true);
    }
    else
    {
        trophyTrinil.SetActive(false);
    }
}


//scene
    public void LoadMainMenuScene()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameMenuBentengScene()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        SceneManager.LoadScene("GameMenuBenteng");
    }
    public void LoadGameMenuTawunScene()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        SceneManager.LoadScene("GameMenuTawun");
    }
     public void LoadGameMenuTrinilScene()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        SceneManager.LoadScene("GameMenuTrinil");
    }
    public void LoadGameMenuJamusScene()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        SceneManager.LoadScene("GameMenuJamus");
    }

    
    
}
