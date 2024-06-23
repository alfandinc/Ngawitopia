using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Reference to the TextMeshProUGUI for displaying total captured monster count
    public TextMeshProUGUI totalCapturedText;

    public GameObject titleClaimPanel;

    public GameObject infoPanel;
    public GameObject cluePanel;
    public GameObject gameplayPanel;
    public TextMeshProUGUI monsterIDText;
    public TextMeshProUGUI monsterNameText;
    public TextMeshProUGUI monsterHabitatText;
    public TextMeshProUGUI monsterFunfactText;
    public Image monsterAvatarImage;
    public GameObject black;

    public MonsterManager monstermanager;

    void Start()
    {
        UpdateTotalCapturedText(); // Initialize the total captured count when the game scene loads
    }

    // Function to update the total captured monster count displayed in the UI
    public void UpdateTotalCapturedText()
    {
        int totalCaptured = PlayerPrefs.GetInt("TotalCaptured", 0); // Get the current total captured count
        totalCapturedText.text = "Total Captured: " + totalCaptured;
    }

    public void ShowMonsterInfo(MonsterManager monster)
    {
        infoPanel.SetActive(true);
        black.SetActive(true);
        // gameplayPanel.SetActive(false);

        monsterIDText.text = "00" + monster.monsterID;
        monsterNameText.text = monster.monsterName;
        monsterHabitatText.text = monster.monsterHabitat;
        monsterFunfactText.text = monster.monsterFunfact;

        Sprite avatarsprite = Resources.Load<Sprite>(monster.monsterAvatar);
        monsterAvatarImage.sprite = avatarsprite;


    }

    public void DeletePlayerData()
    {
        PlayerPrefs.DeleteAll(); // Delete all player preferences
        totalCapturedText.text = "Total Captured: 0 ";
        Debug.Log("Player data deleted."); // Log a message indicating successful deletion
    }

   

    public void ShowTitleClaimPanel()
    {
        titleClaimPanel.SetActive(true); // Activate the title claim button
        black.SetActive(true);
        gameplayPanel.SetActive(false); // Activate the title claim button
    }
}
