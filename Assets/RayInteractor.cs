using UnityEngine;

public class RayInteractor : MonoBehaviour
{
    //public UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor rayInteractor; 
    public UnityEngine.XR.Interaction.Toolkit.Interactors.Visuals.XRInteractorLineVisual leftLineVisual;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.Visuals.XRInteractorLineVisual rightLineVisual;

    void Start()
    {
        // Ensure the interactor and line visual are deactivated at the start
        DeactivateInteractorRayVisual();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Area")) 
        {
            ActivateInteractorRayVisual();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Area"))
        {
            DeactivateInteractorRayVisual();
        }
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
}
