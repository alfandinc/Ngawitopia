using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectionManager : MonoBehaviour
{
        //audio
    public AudioClip buttonClickSFX;

    // Prefab for displaying each captured monster in the list
    public GameObject monsterListItemPrefab;

    // Reference to the Content object of the ScrollRect
    public RectTransform contentTransform;

    void Start()
    {
        PopulateCapturedMonstersList();
    }

    void PopulateCapturedMonstersList()
    {
        // Loop through captured monster IDs and retrieve their data from PlayerPrefs
        for (int i = 1; i <= 12; i++) // Assuming 3 monsters for simplicity
        {
            bool captured = PlayerPrefs.GetInt("MonsterStatus_" + i, 0) == 1; // Check if monster is captured
            if (captured)
            {
                string monsterName = PlayerPrefs.GetString("MonsterName_" + i, "Unknown"); 
                string funfact = PlayerPrefs.GetString("MonsterFunfact_" + i, "Unknown"); 
                string avatar = PlayerPrefs.GetString("MonsterAvatar_" + i, "Unknown"); 
                string element = PlayerPrefs.GetString("MonsterElement_" + i, "Unknown");

                Sprite avatarSprite = Resources.Load<Sprite>(avatar);
                Sprite elementSprite = Resources.Load<Sprite>(element);

                GameObject listItem = Instantiate(monsterListItemPrefab, contentTransform);
                
                TextMeshProUGUI nameTextComponent = listItem.transform.Find("NameText").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI funfactTextComponent = listItem.transform.Find("FunfactText").GetComponent<TextMeshProUGUI>();
                Image avatarComponent = listItem.transform.Find("AvatarImage").GetComponent<Image>();
                Image elementComponent = listItem.transform.Find("ElementImage").GetComponent<Image>();

                nameTextComponent.text = monsterName;
                funfactTextComponent.text = funfact;
                avatarComponent.sprite = avatarSprite;
                elementComponent.sprite = elementSprite;

            }
        }
    }

    //scene
    public void LoadMainMenuScene()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        SceneManager.LoadScene("MainMenu");
    }
}
