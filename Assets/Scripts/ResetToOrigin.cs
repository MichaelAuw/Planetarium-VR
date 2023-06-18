using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ResetToOrigin : MonoBehaviour
{
    [SerializeField] XRBaseInteractable grabbedObject;
    private Pose _originPoint;
    private Vector3 originalScale;
    private Rigidbody rb;
    public Transform newParent;

    // show Information
    public GameObject menu;
    public float spawnDistance = 2;
    public Transform head;
 

    private void OnEnable()
    {
        grabbedObject.selectExited.AddListener(ObjectReleased);
        grabbedObject.selectEntered.AddListener(ObjectGrabbed);
    }

    private void OnDISABLE()
    {
        grabbedObject.selectExited.RemoveListener(ObjectReleased);
        grabbedObject.selectEntered.RemoveListener(ObjectGrabbed);
    }

    private void Awake()
    {
        _originPoint.position = this.transform.position;
        _originPoint.rotation = this.transform.rotation;
        originalScale = newParent.localScale;
     
        rb = GetComponent<Rigidbody>();
    }

    private void ObjectReleased(SelectExitEventArgs arg0)
    {   
        //turn off the rigidBody
        rb.Sleep();

        // turn off collider
        GetComponent<Collider>().enabled = false;

        // return object to origin
        this.transform.position = _originPoint.position;
        this.transform.rotation = _originPoint.rotation;
        newParent.localScale = originalScale;

        // turn everything back on
        rb.WakeUp();

        // turn on collider
        GetComponent<Collider>().enabled = true;

        if(menu.activeSelf == true){
             menu.SetActive(false);
        }
    }

    private void ObjectGrabbed(SelectEnterEventArgs arg0)
    {   
        Debug.Log("object Grabbed");
        transform.parent = newParent;

        Debug.Log(originalScale);

        // Calculate the new scale (e.g., 50% smaller)
        Vector3 newScale = originalScale * 0.008f;

        Debug.Log(newScale);

        // Apply the new scale
        newParent.localScale = newScale;
        
        if(menu.activeSelf == false)
        {
            menu.SetActive(true);

            menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
        }
        
    }

    void Update(){
        menu.transform.LookAt(new Vector3 (head.position.x, menu.transform.position.y,head.position.z));
        menu.transform.forward *= -1;
    }
    
}
