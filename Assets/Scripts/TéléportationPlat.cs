using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TéléportationPlat : MonoBehaviour
{
    // Start is called before the first frame update
    public RecetteFini RecetteFini;
    void Start()
    {
        
    }
    public void OnTriggerEnter(Collider collider)
    {
        StartCoroutine(EndGame());
        IEnumerator EndGame()
        {
            yield return new WaitForSeconds(5);
            RecetteFini.FinRecette = true;
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
