using System.Collections;
using System.Collections.Generic;
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
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.up* VitesseBrasZ);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector3.down* VitesseBrasZ);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.left* VitesseBrasX);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.right* VitesseBrasX);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            rb.AddForce(Vector3.forward * VitesseBrasY);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * VitesseBrasY);
        }
    }
}
