using UnityEngine;

public class ShowExitMenu : MonoBehaviour
{
    public GameObject menuUI; // Assign your menu GameObject here
    public GameObject indicator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Or use a VR-specific tag/logic
        {
            menuUI.SetActive(true);
            indicator.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            menuUI.SetActive(false);
            indicator.SetActive(true);
        }
    }
}
