using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizJamus : MonoBehaviour
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

        //health
    public Slider healthSlider;
    public Image fillImage;
    public float maxHealth = 100f;
    private float currentHealth;

    // Quiz data
    private string[] questions = {
        "Jenis teh apa yang terkenal dari Kebun Teh Jamus?",
        "Dikaki gunung apa lokasi Kebun Teh Jamus?",
        "Apa nama kolam renang yang terdapat pada Kebun Teh Jamus?",
        // Add more questions as needed
    };

    private string[][] options = {
        new string[] {"Teh Kuning", "Teh Pucuk", "Teh Kopi", "Teh Teko"},
        new string[] {"Gunung Lawu", "Gunung Semeru", "Gunung Arjuno", "Gunung Ijen"},
        new string[] {"Grojokan Sewu", "Sumber Lanang", "Kolam Teh", "Banyu Wadon"},
        // Add more options arrays corresponding to each question
    };

    private int[] correctAnswers = {2, 0, 1}; // Index of correct answers for each question

    private int currentQuestionIndex = 0;
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        ShowQuestion(currentQuestionIndex);

        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHealthBar();
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthSlider.value = currentHealth / maxHealth;
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
            TakeDamage(30);
            Debug.Log("Congratulations! Correct answer!");
        }
        else
        {
            AudioManager.Instance.PlaySFX(buttonClickSFX);
            AudioManager.Instance.PlaySFX(loseSFX);
            Debug.Log("Sorry, you lose. Wrong answer!");
            Heal(100);
            ShowGameoverPanel();
            gameOver = true; // Set game over flag
        }

        // Check for quiz completion
        if (currentQuestionIndex == questions.Length - 1 && !gameOver)
        {
            PlayerPrefs.SetInt("TitleJamus", 1); // Set title claim status
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
