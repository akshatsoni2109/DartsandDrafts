using UnityEngine;


public class Teleport : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor rayInteractor; // Assign in Inspector
    public UnityEngine.XR.Interaction.Toolkit.Interactors.Visuals.XRInteractorLineVisual lineVisual; // Assign this from the XRRayInteractor GameObject

    private bool isButtonPressed = false; // Track button press state

    void Start()
    {
        DeactivateTeleportRayVisual();
    }

    void Update()
    {
        // Check if the B button (Two) on the right controller is being held
        bool buttonHeld = OVRInput.Get(OVRInput.Button.Two, OVRInput.Controller.RTouch);

        // Show or hide the teleport ray visuals based on button state
        if (buttonHeld && !isButtonPressed)
        {
            ActivateTeleportRayVisual();
        }
        if (!buttonHeld && isButtonPressed)
        {
            DeactivateTeleportRayVisual();
        }

        // Update button state
        isButtonPressed = buttonHeld;
    }

    private void ActivateTeleportRayVisual()
    {
        if (rayInteractor != null)
        {
            rayInteractor.enabled = true; // Keep teleport interaction enabled
        }
        if (lineVisual != null)
        {
            lineVisual.enabled = true; // Enable the XR Line Visual
        }
    }

    private void DeactivateTeleportRayVisual()
    {
        if (rayInteractor != null)
        {
            
            rayInteractor.enabled = true; // Keep teleportation working
        }
        if (lineVisual != null)
        {
            lineVisual.enabled = false; // Hide the teleport ray
        }
    }
}
