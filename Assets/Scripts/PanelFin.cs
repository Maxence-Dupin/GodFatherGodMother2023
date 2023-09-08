using UnityEngine;

public class PanelFin : MonoBehaviour
{
    [SerializeField] Bowl Bowl;
    [SerializeField] TitreJoueur TitreJoueur;
    public RecetteFini RecetteFini;
    public string titreJoueur;
    void Start()
    {

    }
    private void OnEnable()
    {
        if (Bowl.IngredientsInGoodOrder == true)
        {
            titreJoueur += "Cuisinier /";
        }
        if (Bowl.IngredientsInGoodOrder == false)
        {
            titreJoueur += "Cuisinier Improvisé /";
        }
        if (Bowl.MelangeageReussi == true)
        {
            titreJoueur += "Cuisinier étoilé /";
        }
        if (Bowl.MelangeageReussi == false)
        {
            titreJoueur += "Cuisinier amateur /";
        }
        if (Bowl.CuissonReussi == true)
        {
            titreJoueur += "Cuisinier parfait";
        }
        if (Bowl.CuissonReussi == false)
        {
            titreJoueur += "Pyromane";
        }
        TitreJoueur.NomJoueur(titreJoueur);
    } 
}
