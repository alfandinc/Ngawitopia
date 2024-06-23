using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    // UI elements
    public TextMeshProUGUI questionText;
    // public TextMeshProUGUI titleText;
    public GameObject titleClaimPanel;
    public GameObject gameoverPanel;
    public GameObject QnAPanel;
    public Button[] answerButtons;

    //audio
    public AudioClip buttonClickSFX;
    public AudioClip mainmenuBGM;
    public AudioClip correctSFX;
    public AudioClip winSFX;
    public AudioClip loseSFX;

    // Quiz data
    private string[] questions = {
        "Apa nama lain Benteng van den Bosch?",
        "Berapa luas area Benteng van den Bosch?",
        "Pada Perang apa Benteng van den Bosch dijadikan pusat pertahanan?",
        // Add more questions as needed
    };

    private string[][] options = {
        new string[] {"Benteng Pendem", "Benteng Tinggi", "Benteng Ngawi", "Benteng Londo"},
        new string[] {"15 Ha", "16 Ha", "17 Ha", "18 Ha"},
        new string[] {"Diponegoro", "Sampit", "Badar", "Dunia ke-2"},
        // Add more options arrays corresponding to each question
    };

    private int[] correctAnswers = {0, 0, 0}; // Index of correct answers for each question

    private int currentQuestionIndex = 0;
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        ShowQuestion(currentQuestionIndex);
    }

    // Function to show a question and its answer options
    void ShowQuestion(int index)
    {
        if (gameOver)
            return;

        questionText.text = questions[index];
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = options[index][i];
            int optionIndex = i; // Capturing the loop variable
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => SelectAnswer(optionIndex));
        }
    }

    // Function to handle selecting an answer
    // Function to handle selecting an answer
    void SelectAnswer(int optionIndex)
    {
        if (optionIndex == correctAnswers[currentQuestionIndex])
        {
            AudioManager.Instance.PlaySFX(buttonClickSFX);
            // AudioManager.Instance.PlaySFX(correctSFX);
            Debug.Log("Congratulations! Correct answer!");
        }
        else
        {
            AudioManager.Instance.PlaySFX(buttonClickSFX);
            AudioManager.Instance.PlaySFX(loseSFX);
            Debug.Log("Sorry, you lose. Wrong answer!");
            ShowGameoverPanel();
            gameOver = true; // Set game over flag
        }

        // Check for quiz completion
        if (currentQuestionIndex == questions.Length - 1 && !gameOver)
        {
            PlayerPrefs.SetInt("TitleClaimed", 1); // Set title claim status
            PlayerPrefs.Save(); // Save PlayerPrefs
            ShowTitleClaimPanel();

            Debug.Log("Congratulations! You have claimed the title!");
            // Add logic here to handle title claimed (e.g., show success message)
        }

        // Move to the next question if the game is not over
        if (!gameOver)
        {
            currentQuestionIndex++;
            if (currentQuestionIndex < questions.Length)
            {
                ShowQuestion(currentQuestionIndex);
            }
            else
            {
                AudioManager.Instance.PlaySFX(winSFX);
                Debug.Log("Quiz completed!");
                // Add logic here to handle quiz completion (e.g., show result screen)
            }
        }
    }

    public void ShowTitleClaimPanel()
    {
        AudioManager.Instance.PauseBGM();
        AudioManager.Instance.PlaySFX(winSFX);

        titleClaimPanel.SetActive(true); // Activate the title claim button
        QnAPanel.SetActive(false);
    }
    public void ShowGameoverPanel()
    {
        AudioManager.Instance.PauseBGM();
        gameoverPanel.SetActive(true); // Activate the title claim button
        QnAPanel.SetActive(false);
    }

    public void TryAgain()
    {
        // Reset game state and start the quiz again
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        AudioManager.Instance.ResumeBGM();
        QnAPanel.SetActive(true);
        currentQuestionIndex = 0;
        gameOver = false;
        gameoverPanel.SetActive(false);
        ShowQuestion(currentQuestionIndex);
    }

    public void LoadMainMenuScene()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        AudioManager.Instance.ResumeBGM();
        AudioManager.Instance.ChangeBGM(mainmenuBGM);
        SceneManager.LoadScene("MainMenu");
    }

}
