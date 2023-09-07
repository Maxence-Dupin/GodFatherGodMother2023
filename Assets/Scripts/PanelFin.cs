using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelFin : MonoBehaviour
{
    [SerializeField] private GameObject Canva;
    public RecetteFini RecetteFini;
    // Start is called before the first frame update
    void Start()
    {
        Canva.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (RecetteFini.FinRecette==true)
        {
            Canva.SetActive(true);
        }
    }
}
