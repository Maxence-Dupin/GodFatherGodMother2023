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
            rb.AddForce(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(-Vector3.forward);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Time.deltaTime * -VitesseBrasX, 0 , 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Time.deltaTime * VitesseBrasX, 0, 0);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(0 , 0, Time.deltaTime * VitesseBrasZ);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate( 0, 0, Time.deltaTime * -VitesseBrasZ);
        }
    }
}
