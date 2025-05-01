using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using TMPro;

public class StartMenu : MonoBehaviour
{
    [Header("Panels")]
    public GameObject startMenu;
    public GameObject gamemodePanel;
    public GameObject rulesPanel;
    public GameObject indicator;

    [Header("Buttons")]
    public Button startButton;
    public Button leaveButton;
    public Button timeButton;
    public Button pointsButton;
    public Button backToStartButton;
    public Button playButton;
    public Button backToModesButton;

    [Header("UI Text")]
    public TMP_Text rulesText;

    private string selectedGamemode;

    void Start()
    {
        startButton.onClick.AddListener(OpenGamemodeMenu);
        leaveButton.onClick.AddListener(CloseMenu);
        timeButton.onClick.AddListener(() => SelectGamemode("Time"));
        pointsButton.onClick.AddListener(() => SelectGamemode("Points"));
        backToStartButton.onClick.AddListener(BackToStart);
        playButton.onClick.AddListener(PlayGame);
        backToModesButton.onClick.AddListener(BackToGamemodes);

        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        startMenu.SetActive(true);
        gamemodePanel.SetActive(false);
        rulesPanel.SetActive(false);
        indicator.SetActive(false);
    }

    public void CloseMenu()
    {
        startMenu.SetActive(false);
        indicator.SetActive(true);
    }

    public void OpenGamemodeMenu()
    {
        startMenu.SetActive(false);
        gamemodePanel.SetActive(true);
    }

    public void SelectGamemode(string mode)
    {
        selectedGamemode = mode;
        gamemodePanel.SetActive(false);
        rulesPanel.SetActive(true);

        if (mode == "Time")
        {
            rulesText.text = "Time Mode:\nScore as many points as possible in the 45 second time limit.";
        }
        else if (mode == "Points")
        {
            rulesText.text = "Points Mode:\nScore as many points as possible using only 5 darts.";
        }
    }

    public void BackToGamemodes()
    {
        rulesPanel.SetActive(false);
        gamemodePanel.SetActive(true);
    }

    public void BackToStart()
    {
        gamemodePanel.SetActive(false);
        startMenu.SetActive(true);
    }
    

    public void PlayGame()
    {
        if (selectedGamemode == "Time")
        {
            // Replace with your actual logic to start the time mode
            Debug.Log("Starting Time Mode...");
            FindAnyObjectByType<TimeScoreManager>().RestartGame();
            SceneTransitionManager.singleton.GoToSceneAsync(3);
        }
        else if (selectedGamemode == "Points")
        {
            Debug.Log("Starting Points Mode...");
            FindAnyObjectByType<PointsScoreManager>().RestartGame();
            SceneTransitionManager.singleton.GoToSceneAsync(2);
        }

        rulesPanel.SetActive(false);
        indicator.SetActive(true); 
    }
}
