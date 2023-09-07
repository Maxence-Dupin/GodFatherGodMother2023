using UnityEngine;

public class PanelFin : MonoBehaviour
{
    [SerializeField] private GameObject Canva;
    
    public RecetteFini RecetteFini;
    void Start()
    {
        Canva.SetActive(false);
    }
    
    void Update()
    {
        if (RecetteFini.FinRecette)
        {
            Canva.SetActive(true);
        }
    }
}
