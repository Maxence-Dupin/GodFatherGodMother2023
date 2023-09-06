using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementBrasDroit : MonoBehaviour
{
    public GameObject BrasDroit;
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
        if (Input.GetKey(KeyCode.Keypad8))
        {
            transform.Translate(0, Time.deltaTime * VitesseBrasY, 0 );
        }
        if (Input.GetKey(KeyCode.Keypad5))
        {
            transform.Translate(0, Time.deltaTime * -VitesseBrasY, 0);
        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            transform.Translate(Time.deltaTime * -VitesseBrasX, 0 , 0);
        }
        if (Input.GetKey(KeyCode.Keypad6))
        {
            transform.Translate(Time.deltaTime * VitesseBrasX, 0, 0);
        }
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            transform.Translate(0 , 0, Time.deltaTime * VitesseBrasZ);
        }
        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            transform.Translate(0, 0, Time.deltaTime * -VitesseBrasZ);
        }
    }
}