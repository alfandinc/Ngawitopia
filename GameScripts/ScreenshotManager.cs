using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScreenshotManager : MonoBehaviour
{
    public Button screenshotButton;
    public Canvas uiCanvas; // Reference to the UI canvas or specific UI elements you want to hide

    private void Start()
    {
        screenshotButton.onClick.AddListener(ScreenshotClicked);
    }

    void ScreenshotClicked()
    {
        
    }

    void TakeScreenshot()
    {
        // Hide the UI
        uiCanvas.enabled = false;

        // Capture the screen
        Texture2D screenshotTexture = ScreenCapture.CaptureScreenshotAsTexture();

        // Save the screenshot to the Pictures directory on Android
        byte[] bytes = screenshotTexture.EncodeToPNG();
        string filename = "screenshot_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
        
        // Define the path to the Pictures directory on Android
        string folderPath = "/storage/emulated/0/Pictures/";
        string filePath = Path.Combine(folderPath, filename);
        
        // Save the screenshot
        File.WriteAllBytes(filePath, bytes);

        Debug.Log("Screenshot saved to: " + filePath);

        // Show the UI again
        uiCanvas.enabled = true;
    }
}
