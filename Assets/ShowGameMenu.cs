using UnityEngine;

public class ShowGameMenu : MonoBehaviour
{
    public GameObject startMenu; 
    public GameObject gamemodePanel;
    public GameObject rulesPanel;
    public GameObject indicator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            startMenu.SetActive(true);
            indicator.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            startMenu.SetActive(false);
            gamemodePanel.SetActive(false);
            rulesPanel.SetActive(false);
            indicator.SetActive(true);
        }
    }
}
