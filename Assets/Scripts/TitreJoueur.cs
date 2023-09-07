using UnityEngine;
using TMPro;

public class TitreJoueur : MonoBehaviour
{
    public TextMeshProUGUI texteMeshPro;

    public void NomJoueur(string titre)
    {
        
        texteMeshPro.text = titre;
    }
}
