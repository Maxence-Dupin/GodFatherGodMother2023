using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Transform holdArea;
    private GameObject heldObject;
    private Rigidbody rb;

    [Header("Physics")]
    [SerializeField] private float armRange = 10.0f;
    [SerializeField] private float armForce = 150.0f;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (heldObject == null) 
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, armRange))
                {
                    PickupObject(hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();
            }
        }
        if (heldObject != null)
        {
            MoveObject();
        }
    }

    void MoveObject() 
    { 
        if (Vector3.Distance(heldObject.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObject.transform.position);
            rb.AddForce(moveDirection * armForce);
        }
    }


    void PickupObject (GameObject pickupObj)
    {
        if (pickupObj.GetComponent<Rigidbody>())
        {
            rb = pickupObj.GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.drag = 10;
            rb.constraints = RigidbodyConstraints.FreezeRotation;

            rb.transform.parent = holdArea;
            heldObject = pickupObj;
        }
    }

    void DropObject()
    {
        rb.useGravity = true;
        rb.drag = 1;
        rb.constraints = RigidbodyConstraints.None;

        heldObject.transform.parent = null;
        heldObject = null;

    }
}
