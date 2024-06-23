using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueBossJamus : MonoBehaviour
{
    [System.Serializable]
    public class Dialogue
    {
        public string characterName;
        public string dialogueText;
        public Sprite characterSprite;
    }

    public TMP_Text characterNameText;
    public TMP_Text dialogueText;
    public Image characterSpriteImage;
    public Button continueButton;

    //audio
    public AudioClip buttonClickSFX;
    public AudioClip bossSFX;
    public AudioClip bossBGM;
 

    public Dialogue[] dialogues; // Array to hold the dialogue data
    private int currentDialogueIndex = 0;
    private bool isTyping = false;

    void Start()
    {
        AudioManager.Instance.ChangeBGM(bossBGM);
        AudioManager.Instance.PlaySFX(bossSFX);

        continueButton.onClick.AddListener(DisplayNextDialogue);
        DisplayDialogue();
    }

    void DisplayDialogue()
    {
        
        if (currentDialogueIndex < dialogues.Length)
        {
            Dialogue currentDialogue = dialogues[currentDialogueIndex];
            characterNameText.text = currentDialogue.characterName;

            // Start typing effect coroutine
            StartCoroutine(TypeDialogue(currentDialogue.dialogueText));
            
            characterSpriteImage.sprite = currentDialogue.characterSprite;
        }
        else
        {
            // SceneManager.LoadScene("MainMenu"); 
        }
    }

    IEnumerator TypeDialogue(string dialogue)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in dialogue)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f); // Adjust the speed of typing here
        }

        isTyping = false;
    }

    void DisplayNextDialogue()
    {
        // Check if typing is in progress, if so, skip to end
        AudioManager.Instance.PlaySFX(buttonClickSFX);
        if (isTyping)
        {
            StopAllCoroutines(); // Stop typing coroutine
            dialogueText.text = dialogues[currentDialogueIndex].dialogueText; // Show full text
            isTyping = false;
            return;
        }

        currentDialogueIndex++;
        if (currentDialogueIndex < dialogues.Length)
        {
            DisplayDialogue();
        }
        else
        {
            // Optionally, disable the continue button or end the dialogue sequence
            // continueButton.gameObject.SetActive(false);
            SceneManager.LoadScene("GameQuizJamus"); 
        }
    }
}
