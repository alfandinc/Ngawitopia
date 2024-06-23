using UnityEngine;

public class MonsterManagerJamus : MonoBehaviour
{
    public int monsterID; // Unique ID for each monster
    public string monsterName;
    public string monsterHabitat;
    public string monsterFunfact;
    public string monsterAvatar;
    public string monsterElement;

    public bool captured = false; // Initial status is not captured

    

    // Reference to the UIManager
    public UIManagerJamus uiManager;

    public int totalMonstersInHabitat = 3;

    // Called when the monster is clicked
    void OnMouseDown()
    {
        if (!captured)
        {
            CaptureMonster();
            uiManager.ShowMonsterInfo(this);
        }
        else
        {
            Debug.Log("Monster already captured!");
        }
    }

    // Function to capture the monster
    void CaptureMonster()
    {
        int totalCaptured = PlayerPrefs.GetInt("TotalCapturedJamus", 0); // Get the current total captured count
        if (totalCaptured == totalMonstersInHabitat)
        {
            Debug.Log("All monsters in the habitat are already captured!");
            return; // Exit the function if all monsters are already captured
        }
        captured = true; // Change the status to captured
        UpdateCapturedMonsterCount(); // Update captured monster count
        uiManager.UpdateTotalCapturedText(); // Update total captured text using UIManager
        SaveMonsterData(); // Save status using PlayerPrefs
        SaveProgress(); // Save progress using PlayerPrefs
        
    }

    // Function to update the captured monster count
    void UpdateCapturedMonsterCount()
    {
        int totalCaptured = PlayerPrefs.GetInt("TotalCapturedJamus", 0); // Get the current total captured count
        totalCaptured++; // Increment the count
        if (totalCaptured == totalMonstersInHabitat)
        {
            uiManager.ShowTitleClaimPanel(); // Show the button to claim the title
        }
        PlayerPrefs.SetInt("TotalCapturedJamus", totalCaptured); // Save the updated count
        
    }
    void SaveMonsterData()
    {
        PlayerPrefs.SetInt("MonsterStatus_" + monsterID, captured ? 1 : 0); // Save captured status
        PlayerPrefs.SetString("MonsterName_" + monsterID, monsterName); // Save monster name
        PlayerPrefs.SetString("MonsterHabitat_" + monsterID, monsterHabitat); // Save monster habitat
        PlayerPrefs.SetString("MonsterFunfact_" + monsterID, monsterFunfact); // Save monster habitat
        PlayerPrefs.SetString("MonsterAvatar_" + monsterID, monsterAvatar);
        PlayerPrefs.SetString("MonsterElement_" + monsterID, monsterElement);
        PlayerPrefs.Save(); // Save PlayerPrefs
    }

    // Function to save progress using PlayerPrefs
    void SaveProgress()
    {
        PlayerPrefs.Save(); // Save PlayerPrefs
    }
}
