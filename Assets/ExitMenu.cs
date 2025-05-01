using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject indicator;
    public Button yesButton;
    public Button noButton;

    void Start()
    {
        //Hook events
        yesButton.onClick.AddListener(LeaveGame);
        noButton.onClick.AddListener(HideAll);
    }

    public void LeaveGame()
    {
        menu.SetActive(false);
        indicator.SetActive(false);
        SceneTransitionManager.singleton.GoToSceneAsync(0);
    }

    public void HideAll()
    {
        menu.SetActive(false);
        indicator.SetActive(true);
    }

    
}
