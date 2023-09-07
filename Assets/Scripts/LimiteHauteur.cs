using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteHauteur : MonoBehaviour
{
    public GameObject Objet ;
    public GameObject PointTéléportation ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Objet.transform.position.y < 0.5)
        {
            Objet.transform.position= PointTéléportation.transform.position;   
        }
    }
}
