using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TéléportationPlat : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canva;
    void Start()
    {
        canva.SetActive(false);
    }
    public void OnTriggerEnter(Collider collider)
    {
        StartCoroutine(EndGame());
        IEnumerator EndGame()
        {
            yield return new WaitForSeconds(5);
            canva.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
