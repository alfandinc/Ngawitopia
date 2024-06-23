using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class MainMenuManager : MonoBehaviour
{
    //audio
    public AudioClip buttonClickSFX;
    public AudioClip mainmenuBGM;


    //trophy
    public GameObject bronzeTrophy;
    public GameObject goldTrophy;
    public GameObject platinumTrophy;
    public GameObject diamondTrophy;

    //option
    public Canvas canvasmenu;
    public Canvas canvasoption;
    public GameObject popUpPanel;



    void Start()
    {
        // Check if this is the first time the app is opened
        if (!PlayerPrefs.HasKey("HasSeenStory"))
        {
            PlayerPrefs.SetInt("HasSeenStory", 0);
        }
        

        int[] titles = {
        PlayerPrefs.GetInt("TitleBenteng", 0),
        PlayerPrefs.GetInt("TitleTawun", 0),
        PlayerPrefs.GetInt("TitleJamus", 0),
        PlayerPrefs.GetInt("TitleTrinil", 0)
        };

        

// Count how many titles are equal to 1
        int titleLevel = titles.Count(title => title == 1);

        switch (titleLevel)
        {
            case 1:
                bronzeTrophy.SetActive(true);
                goldTrophy.SetActive(false);
                platinumTrophy.SetActive(false);
                diamondTrophy.SetActive(false);
                break;
            case 2:
                bronzeTrophy.SetActive(false);
                goldTrophy.SetActive(true);
                platinumTrophy.SetActive(false);
                diamondTrophy.SetActive(false);
                break;
            case 3:
                bronzeTrophy.SetActive(false);
                goldTrophy.SetActive(false);
                platinumTrophy.SetActive(true);
                diamondTrophy.SetActive(false);
                break;
            case 4:
                bronzeTrophy.SetActive(false);
                goldTrophy.SetActive(false);
                platinumTrophy.SetActive(false);
                diamondTrophy.SetActive(true);
                break;
            default:
                // Disable all trophy images if no title is claimed
                bronzeTrophy.SetActive(false);
                goldTrophy.SetActive(false);
                platinumTrophy.SetActive(false);
                diamondTrophy.SetActive(false);
                break;
        }

    }

    void Update()
    {
        // Check if the back button is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (popUpPanel.activeSelf)
            {
                // If pop-up is already showing, close it
                popUpPanel.SetActive(false);
            }
            else
            {
                // Show the pop-up
                popUpPanel.SetActive(true);
            }
        }
    }

    public void ClosePopUp()
    {
        // Close the pop-up
        popUpPanel.SetActive(false);
    }

    public void QuitGame()
    {
        // Quit the game
        Application.Quit();
    }



//SceneManager

    public void StartGame()
    {
        // Play button click sound effect
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        
        
        // Load Story Scene immediately
        // Check if the story has been seen
        if (PlayerPrefs.GetInt("HasSeenStory") == 0)
        {
            // Load Story Scene
            AudioManager.Instance.PauseBGM();
            SceneManager.LoadScene("StoryIntro");

            // Set the value to indicate the story has been seen
            PlayerPrefs.SetInt("HasSeenStory", 1);
        }
        else
        {
            // Load MapsMenu Scene
            SceneManager.LoadScene("GameMaps");
        }
    }
    public void LoadOption()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        SceneManager.LoadScene("OptionMenu");
    }
    public void LoadCollectionScene()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        SceneManager.LoadScene("CollectionMenu");
    }
    public void LoadCreditsScene()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        SceneManager.LoadScene("CreditsMenu");
    }
    public void LoadAchievements()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        SceneManager.LoadScene("AchievementsMenu");
    }
    public void LoadStoryScene()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        AudioManager.Instance.PauseBGM();
        SceneManager.LoadScene("StoryIntro");
    }

      public void ShowCanvasmenu()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        canvasmenu.gameObject.SetActive(true);
        canvasoption.gameObject.SetActive(false);
    }

    public void ShowCanvasoption()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        canvasmenu.gameObject.SetActive(false);
        canvasoption.gameObject.SetActive(true);
    }

    public void DeleteData()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        PlayerPrefs.DeleteAll();
    }
}
