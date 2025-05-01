using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class PointsScoreManager : MonoBehaviour
{
    
    public TMP_Text scoreboard;
    public TMP_Text message;
    public int score = 0;
    public int dartsThrown = 0;
    public int maxDarts = 5;
    private bool countdownStarted = false;
    private float countdownTimer = 2f;
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
        SpawnDarts();
    }

    void Update()
    {
        if (dartsThrown == maxDarts && !countdownStarted)
        {
            countdownStarted = true;
        }

        if (countdownStarted && countdownTimer > 0)
        {
            countdownTimer -= Time.deltaTime;

            if (countdownTimer <= 0)
            {
                endGame();
                countdownStarted = false;
            }
        }
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
            message.text = "You got " + number + " points!\nDarts Thrown: " + dartsThrown + "/5";
        }
        else if (message != null && number == 0)
        {
            dartsThrown++;
            message.text = "You missed...\nDarts Thrown: " + dartsThrown + "/5";
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
            message.text = "All darts have been thrown, thanks for playing!";
        }
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
        score = 0;
        dartsThrown = 0;
        countdownStarted = false;
        countdownTimer = 2f;
        if (EndMenu != null)
        {
            EndMenu.SetActive(false);
        }
        DeactivateInteractorRayVisual();
        SpawnDarts();
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
            leftLineVisual.enabled = true;  // Enable the ray visual line
            rightLineVisual.enabled = true;
        }
    }

    private void DeactivateInteractorRayVisual()
    {
        
        if (leftLineVisual != null && rightLineVisual != null)
        {
            leftLineVisual.enabled = false;  // Disable the ray visual line
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
    }

    
}
