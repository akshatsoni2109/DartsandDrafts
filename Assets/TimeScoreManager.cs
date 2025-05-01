using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeScoreManager : MonoBehaviour
{
    public TMP_Text scoreboard;
    public TMP_Text message;
    public TMP_Text countdown;
    public int score = 0;
    public int dartsThrown = 0;
    public int maxDarts = 5;
    public int maxDartsThrown = 0;
    private float countdownTimer = 45f;
    private float countdownPrepTimer = 5f;  // 5-second countdown at the start
    private bool gameStarted = false;
    public GameObject EndMenu;
    public Button leaveButton;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.Visuals.XRInteractorLineVisual leftLineVisual;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.Visuals.XRInteractorLineVisual rightLineVisual;

    public GameObject dartPrefab;
    public Transform[] dartSpawnPoints;
    private List<GameObject> spawnedDarts = new List<GameObject>();

    void Start()
    {
        DeactivateInteractorRayVisual();
        EndMenu.SetActive(false);
        leaveButton.onClick.AddListener(LeaveScene);
        message.text = "Get ready..."; // Set the initial message
        StartCoroutine(PrepCountdown());
    }

    void Update()
    {
        if (gameStarted && countdownTimer > 0)
        {
            countdownTimer -= Time.deltaTime;
            countdown.text = Mathf.Ceil(countdownTimer).ToString();
            if (countdownTimer <= 0)
            {
                countdown.text = "";
                endGame();
            }
        }
    }

    private IEnumerator PrepCountdown()
    {
        while (countdownPrepTimer > 0)
        {
            message.text = "Get ready...\n" + Mathf.Ceil(countdownPrepTimer).ToString();
            countdownPrepTimer -= Time.deltaTime;
            yield return null;
        }

        message.text = "Go!";
        yield return new WaitForSeconds(1); // Brief delay before game starts

        
        gameStarted = true; // Game has officially started
        countdownTimer = 45f; // Reset the main timer to 45 seconds
        SpawnDarts(); // Spawn the first set of darts
        scoreboard.text = "Score: 0";
    }

    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreDisplay();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreDisplay();
    }

    public void UpdateMessage(int number)
    {
        if (message != null && number > 0)
        {
            dartsThrown++;
            maxDartsThrown++;
            message.text = "You got " + number + " points!\nDarts Thrown: " + maxDartsThrown;
        }
        else if (message != null && number == 0)
        {
            dartsThrown++;
            maxDartsThrown++;
            message.text = "You missed...\nDarts Thrown: " + maxDartsThrown;
        }

        if (dartsThrown >= maxDarts)
        {
            SpawnDarts(); // Spawn new darts after 5 darts have been thrown
            message.text += "\nNew darts have spawned!";
        }
    }

    private void endGame()
    {
        if (scoreboard != null)
        {
            scoreboard.text = "Final Score: " + score;
        }
        if (message != null)
        {
            message.text = "Time's up, thanks for playing!";
        }
        foreach (GameObject dart in spawnedDarts)
        {
            if (dart != null)
                Destroy(dart);
        }
        spawnedDarts.Clear();
        ActivateInteractorRayVisual();
        EndMenu.SetActive(true);
    }

    private void UpdateScoreDisplay()
    {
        if (scoreboard != null)
        {
            scoreboard.text = "Score: " + score;
        }
    }

    public void RestartGame()
    {
        // Reset all variables
        score = 0;
        dartsThrown = 0;
        maxDartsThrown = 0;
        countdownTimer = 45f;
        countdownPrepTimer = 5f;
        gameStarted = false;

        // UI Reset
        if (EndMenu != null)
        {
            EndMenu.SetActive(false);
        }
        scoreboard.text = "Darts will spawn to your right.";
        countdown.text = "";

        // Clear any remaining darts
        foreach (GameObject dart in spawnedDarts)
        {
            if (dart != null)
                Destroy(dart);
        }
        spawnedDarts.Clear();

        // Reset visuals
        DeactivateInteractorRayVisual();

        // Start prep countdown again
        StartCoroutine(PrepCountdown());
    }

    private void LeaveScene()
    {
        DeactivateInteractorRayVisual();
        EndMenu.SetActive(false);
        scoreboard.text = "";
        message.text = "";
        SceneTransitionManager.singleton.GoToSceneAsync(1); 
    }

    private void ActivateInteractorRayVisual()
    {
        if (leftLineVisual != null && rightLineVisual != null)
        {
            leftLineVisual.enabled = true;
            rightLineVisual.enabled = true;
        }
    }

    private void DeactivateInteractorRayVisual()
    {
        if (leftLineVisual != null && rightLineVisual != null)
        {
            leftLineVisual.enabled = false;
            rightLineVisual.enabled = false;
        }
    }

    private void SpawnDarts()
    {
        // Destroy old darts first
        foreach (GameObject dart in spawnedDarts)
        {
            if (dart != null)
                Destroy(dart);
        }
        spawnedDarts.Clear();

        // Spawn 5 darts at the designated positions
        for (int i = 0; i < dartSpawnPoints.Length; i++)
        {
            GameObject dart = Instantiate(dartPrefab, dartSpawnPoints[i].position, dartSpawnPoints[i].rotation);
            spawnedDarts.Add(dart);
        }

        dartsThrown = 0;
    }
}
