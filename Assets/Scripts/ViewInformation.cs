using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ViewInformation : MonoBehaviour
{
    public GameObject menu;
    public float spawnDistance = 2;
    public Transform head;
    public InputActionProperty showButton;
    
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(viewInformations);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void viewInformations(ActivateEventArgs arg)
    {
        Debug.Log("ButtonPressed");
        if(showButton.action.WasPressedThisFrame())
        {
            menu.SetActive(!menu.activeSelf);

            menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
        }
        

        menu.transform.LookAt(new Vector3 (head.position.x, menu.transform.position.y,head.position.z));
        menu.transform.forward *= -1;
    }
}
