using UnityEngine;
using TMPro;

public class ClueManager : MonoBehaviour
{
    public static ClueManager Instance;
    //audio
    public AudioClip buttonClickSFX;

    // public GameObject cluePanel;
    public TMP_Text clueText;

    private string[] clues; // Array to store all clues
    private int currentClueIndex; // Index of the currently displayed clue

    // private void Awake()
    // {
    //     Instance = this;
    // }

    private void Start()
    {
        // Initialize clues array with your clues
        clues = new string[]
        {
            "Sejajar dengan putaran waktu",
            "Penjaga portal pertahanan",
            "Menyebrangi dua atap",
           
            // Add more clues as needed
        };

        // Initially, display the first clue
        currentClueIndex = 0;
        ShowCurrentClue();
    }

    public void ShowCurrentClue()
    {
        clueText.text = clues[currentClueIndex];
    }

    public void ShowNextClue()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        currentClueIndex = (currentClueIndex + 1) % clues.Length;
        ShowCurrentClue();
    }

    public void ShowPreviousClue()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        currentClueIndex = (currentClueIndex - 1 + clues.Length) % clues.Length;
        ShowCurrentClue();
    }
}
