using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionManager : MonoBehaviour
{

    //audio
    public AudioClip buttonClickSFX;

    public void DeleteData()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        PlayerPrefs.DeleteAll();
    }

    public void LoadMainMenuScene()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        SceneManager.LoadScene("MainMenu");
    }
}
