using UnityEngine;

public class Pickup : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Transform holdArea;
    [SerializeField] private bool _leftArm;

    private GameObject heldObject;
    private Rigidbody rb;

    public Pickup otherArm;
    public Minigame minigame;
    private bool bowl, whisk = false;
    [Header("Physics")]
    [SerializeField] private float armRange = 5.0f;
    [SerializeField] AudioClip PickUp;

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

    void PickupObject(GameObject pickupObj)
    {
        if (pickupObj.GetComponent<Rigidbody>() && !pickupObj.CompareTag("HandLeft") && !pickupObj.CompareTag("HandRight"))
        {
            AudioManager.Instance.ChangerAudio(PickUp);
            rb = pickupObj.GetComponent<Rigidbody>();
            pickupObj.GetComponent<Collider>().enabled = false;

            rb.useGravity = false;
            rb.drag = 10;

            if (pickupObj.CompareTag("Whisk"))
                whisk = true;
            if (pickupObj.CompareTag("Bowl"))
                bowl = true;



            rb.transform.parent = holdArea;
            heldObject = pickupObj;
        }
    }

    public void DropObject()
    {
        heldObject.GetComponent<Collider>().enabled = true;

        rb.useGravity = true;
        rb.drag = 1;

        rb.velocity = GetComponent<Rigidbody>().velocity;

        if (heldObject.CompareTag("Whisk"))
            whisk = false;
        if (heldObject.CompareTag("Bowl"))
            bowl = false;

        heldObject.transform.parent = null;
        heldObject = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HandRight") || other.CompareTag("HandLeft"))
        {
            Debug.Log("Arm");
            if (whisk && otherArm.bowl || bowl && otherArm.whisk)
            {
                if (_leftArm)
                    minigame.StartMix(true);
                else
                    minigame.StartMix(false);
            }
        }
    }
}