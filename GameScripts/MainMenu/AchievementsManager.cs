
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class AchievementsManager : MonoBehaviour
{
    public GameObject zeroTrophy;
    public GameObject bronzeTrophy;
    public GameObject goldTrophy;
    public GameObject platinumTrophy;
    public GameObject diamondTrophy;

    public GameObject badgeBenteng;
    public GameObject badgeTawun;
    public GameObject badgeJamus;
    public GameObject badgeTrinil;

    //audio
    public AudioClip buttonClickSFX;
    // Start is called before the first frame update
    void Start()
    {
        int clearBenteng = PlayerPrefs.GetInt("TitleBenteng", 0);
        int clearTawun = PlayerPrefs.GetInt("TitleTawun", 0);
        int clearJamus = PlayerPrefs.GetInt("TitleJamus", 0);
        int clearTrinil = PlayerPrefs.GetInt("TitleTrinil", 0);

        if (clearBenteng == 1)
        {
            badgeBenteng.SetActive(true);
        }
        else
        {
            badgeBenteng.SetActive(false);
        }

        if (clearTawun == 1)
        {
            badgeTawun.SetActive(true);
        }
        else
        {
            badgeTawun.SetActive(false);
        }

        if (clearJamus == 1)
        {
            badgeJamus.SetActive(true);
        }
        else
        {
            badgeJamus.SetActive(false);
        }

        if (clearTrinil == 1)
        {
            badgeTrinil.SetActive(true);
        }
        else
        {
            badgeTrinil.SetActive(false);
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
                zeroTrophy.SetActive(false);
                bronzeTrophy.SetActive(true);
                goldTrophy.SetActive(false);
                platinumTrophy.SetActive(false);
                diamondTrophy.SetActive(false);
                break;
            case 2:
                zeroTrophy.SetActive(false);
                bronzeTrophy.SetActive(false);
                goldTrophy.SetActive(true);
                platinumTrophy.SetActive(false);
                diamondTrophy.SetActive(false);
                break;
            case 3:
                zeroTrophy.SetActive(false);
                bronzeTrophy.SetActive(false);
                goldTrophy.SetActive(false);
                platinumTrophy.SetActive(true);
                diamondTrophy.SetActive(false);
                break;
            case 4:
                zeroTrophy.SetActive(false);
                bronzeTrophy.SetActive(false);
                goldTrophy.SetActive(false);
                platinumTrophy.SetActive(false);
                diamondTrophy.SetActive(true);
                break;
            default:
                // Disable all trophy images if no title is claimed
                zeroTrophy.SetActive(true);
                bronzeTrophy.SetActive(false);
                goldTrophy.SetActive(false);
                platinumTrophy.SetActive(false);
                diamondTrophy.SetActive(false);
                break;
        }
        
    }

    //scene
    public void LoadMainMenuScene()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        SceneManager.LoadScene("MainMenu");
    }
}
