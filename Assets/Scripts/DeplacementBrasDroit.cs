using UnityEngine;

public class DeplacementBrasDroit : MonoBehaviour
{
    public GameObject BrasDroit;
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
        if (Input.GetKey(KeyCode.Keypad8))
        {
            rb.AddForce(Vector3.up * VitesseBrasZ);
        }
        if (Input.GetKey(KeyCode.Keypad5))
        {
            rb.AddForce(Vector3.down * VitesseBrasZ);
        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            rb.AddForce(Vector3.left * VitesseBrasX);
        }
        if (Input.GetKey(KeyCode.Keypad6))
        {
            rb.AddForce(Vector3.right * VitesseBrasX);
        }
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            rb.AddForce(Vector3.forward * VitesseBrasY);
        }
        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            rb.AddForce(Vector3.back * VitesseBrasY);
        }
    }
}