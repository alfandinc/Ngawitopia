using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerTrinil : MonoBehaviour
{
    //audio
    public AudioClip buttonClickSFX;
    public AudioClip foundSFX;
    public AudioClip bossSFX;


    //quizmath
    public TextMeshProUGUI questionText; // TextMeshPro Text for the question
    public TMP_InputField answerInput; // TextMeshPro Input Field for the player's answer
    public Button submitButton; // Button to submit the answer
    public TextMeshProUGUI feedbackText; // TextMeshPro Text for feedback
    public GameObject quizPanel;

    private int num1;
    private int num2;
    private int correctAnswer;


    public TextMeshProUGUI totalCapturedText;

    public GameObject titleClaimPanel;

    public GameObject infoPanel;
    public GameObject cluePanel;
    public GameObject gameplayPanel;
    public GameObject cameraPanel;
    public TextMeshProUGUI monsterIDText;
    public TextMeshProUGUI monsterNameText;
    public TextMeshProUGUI monsterHabitatText;
    public TextMeshProUGUI monsterFunfactText;
    public Image monsterAvatarImage;
    public Image monsterElementImage;
    public GameObject black;

    public MonsterManagerTrinil monstermanager;

    void Start()
    {
        UpdateTotalCapturedText(); // Initialize the total captured count when the game scene loads
    }

    // Function to update the total captured monster count displayed in the UI
    public void UpdateTotalCapturedText()
    {
        int totalCaptured = PlayerPrefs.GetInt("TotalCapturedTrinil", 0); // Get the current total captured count
        totalCapturedText.text = "= " + totalCaptured;
    }

//Quizmath

    public void GenerateQuestion()
    {
        num1 = Random.Range(1, 99); // Random number between 1 and 10
        num2 = Random.Range(1, 99); // Random number between 1 and 10
        correctAnswer = num1 + num2;
        questionText.text = $" {num1} + {num2} = ?";
        feedbackText.text = "Solve to Capture!"; // Clear previous feedback
        answerInput.text = ""; // Clear the input field
        answerInput.interactable = true; // Enable the input field
        submitButton.interactable = true; // Enable the submit button
    }

    public void CheckAnswer()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        if (int.TryParse(answerInput.text, out int playerAnswer))
        {
            if (playerAnswer == correctAnswer)
            {
                // feedbackText.text = "Correct! Well done!";
                quizPanel.SetActive(false);
                infoPanel.SetActive(true);
                AudioManager.Instance.PlaySFX(foundSFX);

                answerInput.interactable = false;
                submitButton.interactable = false;
            }
            else
            {
                // feedbackText.text = $"Incorrect. The correct answer was {correctAnswer}. Try a new question.";
                GenerateQuestion(); // Generate a new question
            }
        }
        else
        {
            feedbackText.text = "Please enter a valid number.";
        }
    }


    public void ShowMonsterInfo(MonsterManagerTrinil monster)
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        quizPanel.SetActive(true);
        GenerateQuestion();
        // infoPanel.SetActive(true);
        black.SetActive(true);
        // gameplayPanel.SetActive(false);

        monsterIDText.text = "00" + monster.monsterID;
        monsterNameText.text = monster.monsterName;
        monsterHabitatText.text = monster.monsterHabitat;
        monsterFunfactText.text = monster.monsterFunfact;

        Sprite avatarsprite = Resources.Load<Sprite>(monster.monsterAvatar);
        monsterAvatarImage.sprite = avatarsprite;

        Sprite elementsprite = Resources.Load<Sprite>(monster.monsterElement);
        monsterElementImage.sprite = elementsprite;


    }

    public void HideInfoPanel()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        infoPanel.SetActive(false);
        black.SetActive(false);
    }

    public void ShowTitleClaimPanel()
    {
        AudioManager.Instance.PlaySFX(bossSFX);
        titleClaimPanel.SetActive(true); // Activate the title claim button
        black.SetActive(true);
        gameplayPanel.SetActive(false); // Activate the title claim button
    }

    public void ShowCameraPanel()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        cameraPanel.SetActive(true);
        gameplayPanel.SetActive(false);

    } 
    public void HideCameraPanel()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        cameraPanel.SetActive(false);
        gameplayPanel.SetActive(true);

    } 
//scene
    public void LoadGameMenuTrinilScene()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        SceneManager.LoadScene("GameMenuTrinil");
    }

    public void LoadBossTrinilScene()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        AudioManager.Instance.ResumeBGM();
        SceneManager.LoadScene("BossTrinilDialogue");
    }


}
