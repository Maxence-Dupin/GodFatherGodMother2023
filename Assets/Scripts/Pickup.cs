using UnityEngine;

public class Pickup : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Transform holdArea;
    [SerializeField] private bool _leftArm;
    
    private GameObject heldObject;
    private Rigidbody rb;

    public Minigame minigame;
    private bool bowl, whisk = false;
    [Header("Physics")]
    [SerializeField] private float armRange = 5.0f;

    private void Update()
    {
        if ((_leftArm && Input.GetKeyDown(InputManager.Instance.LeftJoystickButton1)) 
        || (!_leftArm && Input.GetKeyDown(InputManager.Instance.RightJoystickButton1)))
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
        if (pickupObj.GetComponent<Rigidbody>() && !pickupObj.CompareTag("HandLeft") && !pickupObj.CompareTag("HandRight"))
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

    public void DropObject()
    {
        heldObject.GetComponent<Collider>().enabled = true;
        
        rb.useGravity = true;
        rb.drag = 1;
        rb.constraints = RigidbodyConstraints.None;

        rb.velocity = GetComponent<Rigidbody>().velocity;

        heldObject.transform.parent = null;
        heldObject = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bowl"))
        {
            bowl = true;
            if (whisk) 
            {
                if (_leftArm)
                    minigame.StartMix(true);
                else
                    minigame.StartMix(false);


            }
        }
        if (other.CompareTag("Whisk"))
        {
            whisk = true;
            if (bowl) 
            {
                if (_leftArm)
                    minigame.StartMix(true);
                else
                    minigame.StartMix(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        {
            if (other.CompareTag("Bowl"))
            {
                bowl = false;
            }
            if (other.CompareTag("Whisk"))
            {
                whisk = false;
            }
        }
    }
}
