using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DartThrowForPoints : MonoBehaviour
{
    List<Vector3> trackingPos = new List<Vector3>(); 
    public float velocity = 30f;
    bool pickedUp = false;
    GameObject parentHand;
    Rigidbody rb;
    private bool hasHit = false;
    private bool hasMissed = false;
    public AudioClip dartHit;
    public AudioClip dartMiss;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Ensure Rigidbody is assigned
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (pickedUp)
        {
            // Maintain a tracking history of last 15 positions
            if (trackingPos.Count > 5)
            {
                trackingPos.RemoveAt(0);
            }
            trackingPos.Add(transform.position);

            float triggerRight = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);

            if (triggerRight < 0.1f) 
            {
                pickedUp = false;
                rb.isKinematic = false;
                rb.useGravity = true;
                GetComponent<Collider>().isTrigger = false; // Ensure collider is solid
                

                // Calculate direction from oldest position to the latest one
                if (trackingPos.Count > 1)
                {
                    Vector3 direction = (trackingPos[trackingPos.Count - 1] - trackingPos[0]).normalized;
                    rb.AddForce(direction * velocity);
                    rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                }
            }
            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        float triggerRight = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);
        if (other.gameObject.CompareTag("Right Hand") && triggerRight > 0.9f)
        {
            pickedUp = true;
            parentHand = other.gameObject;
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Dartboard"))
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            if (!hasHit)
            {
                hasHit = true;

                string hitName = collision.gameObject.name;
                int hitNumber = int.Parse(hitName);
                FindAnyObjectByType<PointsScoreManager>().AddPoints(hitNumber);
                FindAnyObjectByType<PointsScoreManager>().UpdateMessage(hitNumber);
                
                audioSource.PlayOneShot(dartHit);
                
            }
        }
        else if (collision.gameObject.CompareTag("Dart"))
        {
            return;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
            
            if (!hasMissed && !hasHit)
            {
                hasMissed = true;
                FindAnyObjectByType<PointsScoreManager>().UpdateMessage(0);

                audioSource.PlayOneShot(dartMiss, 2f);
            }
            
        }
        
    }

    
}