using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteHauteur : MonoBehaviour
{
    public GameObject Objet ;
    public GameObject PointTeleportation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Objet.transform.position.y < 0)
        {
            Objet.transform.position= PointTeleportation.transform.position;   
        }
    }
}
