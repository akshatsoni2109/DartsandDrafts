using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DisableGrabbingHandModel : MonoBehaviour
{
    public GameObject leftHandModel;
    public GameObject rightHandModel;
    public GameObject rightHandPose;
    public GameObject leftHandPose;
    
    void Start()
    {
        UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(HideGrabbingHand);
        grabInteractable.selectExited.AddListener(ShowGrabbingHand);
        rightHandPose.SetActive(false);
        leftHandPose.SetActive(false);
    }

    public void HideGrabbingHand(SelectEnterEventArgs args)
    {
        
        
        if (args.interactorObject.transform.gameObject.CompareTag("Left Hand"))
        {
            
            leftHandModel.SetActive(false);
            leftHandPose.SetActive(true);
        }
        else if (args.interactorObject.transform.gameObject.CompareTag("Right Hand"))
        {
            
            rightHandModel.SetActive(false);
            rightHandPose.SetActive(true);
        }
    }

    public void ShowGrabbingHand(SelectExitEventArgs args)
    {
       
        
        if (args.interactorObject.transform.gameObject.CompareTag("Left Hand"))
        {
        
            leftHandModel.SetActive(true);
            leftHandPose.SetActive(false);
        }
        else if (args.interactorObject.transform.gameObject.CompareTag("Right Hand"))
        {
            
            rightHandModel.SetActive(true);
            rightHandPose.SetActive(false);
        }
    }
}

