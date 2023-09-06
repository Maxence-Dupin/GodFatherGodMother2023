using UnityEngine;

public class PickupRight : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Transform holdArea;
    private GameObject heldObject;
    private Rigidbody rb;
    [Header("Physics")]
    [SerializeField] private float armRange = 5.0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (heldObject == null) 
            {
                RaycastHit hit;
                if (Physics.Raycast(new Ray(holdArea.position, Vector3.forward), out hit, armRange))
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
        heldObject.transform.position = holdArea.position;
    }


    void PickupObject (GameObject pickupObj)
    {
        if (pickupObj.GetComponent<Rigidbody>())
        {
            rb = pickupObj.GetComponent<Rigidbody>();
            pickupObj.GetComponent<Collider>().enabled = false;
            
            rb.useGravity = false;
            rb.drag = 10;
            rb.constraints = RigidbodyConstraints.FreezeRotation;

            rb.transform.parent = holdArea;
            heldObject = pickupObj;
        }
    }

    void DropObject()
    {
        heldObject.GetComponent<Collider>().enabled = true;
        
        rb.useGravity = true;
        rb.drag = 1;
        rb.constraints = RigidbodyConstraints.None;

        rb.velocity = GetComponent<Rigidbody>().velocity;

        heldObject.transform.parent = null;
        heldObject = null;
    }
}
