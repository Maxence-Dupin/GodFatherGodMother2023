using UnityEngine;

public class DeplacementBrasGauche : MonoBehaviour
{
    public GameObject BrasGauche;
    public Rigidbody rb;
    public float VitesseBrasY=1;
    public float VitesseBrasZ=1;
    public float VitesseBrasX=1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(InputManager.Instance.LeftJoystickUp))
        {
            rb.AddForce(Vector3.up* VitesseBrasZ);
        }
        if (Input.GetKey(InputManager.Instance.LeftJoystickBottom))
        {
            rb.AddForce(Vector3.down* VitesseBrasZ);
        }
        if (Input.GetKey(InputManager.Instance.LeftJoystickLeft))
        {
            rb.AddForce(Vector3.left* VitesseBrasX);
        }
        if (Input.GetKey(InputManager.Instance.LeftJoystickRight))
        {
            rb.AddForce(Vector3.right* VitesseBrasX);
        }
        if (Input.GetKey(InputManager.Instance.LeftJoystickProfondeurUp))
        {
            rb.AddForce(Vector3.forward * VitesseBrasY);
        }
        if (Input.GetKey(InputManager.Instance.LeftJoystickProfondeurBottom))
        {
            rb.AddForce(Vector3.back * VitesseBrasY);
        }
    }
}
