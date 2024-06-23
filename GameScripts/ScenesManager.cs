using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadMapsMenuScene()
    {
        SceneManager.LoadScene("GameMaps");
    }

//Benteng
    
    
    public void LoadQuizBentengScene()
    {
        SceneManager.LoadScene("GameQuizBenteng");
    }
    
//Tawun
    public void LoadGameplayTawunScene()
    {
        SceneManager.LoadScene("GameplayTawun");
    }
    
    public void LoadQuizTawunScene()
    {
        SceneManager.LoadScene("GameQuizTawun");
    }

//Trinil
    public void LoadGameplayTrinilScene()
    {
        SceneManager.LoadScene("GameplayTrinil");
    }
   
    public void LoadQuizTrinilScene()
    {
        SceneManager.LoadScene("GameQuizTrinil");
    }

//Jamus
    public void LoadGameplayJamusScene()
    {
        SceneManager.LoadScene("GameplayJamus");
    }
    
    public void LoadQuizJamusScene()
    {
        SceneManager.LoadScene("GameQuizJamus");
    }

//Scene & Routes
    

    

    
    public void OpenRouteTawun()
     {
         Application.OpenURL("https://maps.app.goo.gl/6GKxGNkwzfqYY9UC8");
     }
    public void OpenRouteTrinil()
     {
         Application.OpenURL("https://maps.app.goo.gl/oPp6N7ixY6Xspr3Q9");
     }
    public void OpenRouteJamus()
     {
         Application.OpenURL("https://maps.app.goo.gl/eSMY589oVuC1rzdd8");
     }
}
