using UnityEngine;

public class Bowl : MonoBehaviour
{
    #region Fields

    private int _step = 0;

    private bool _ingredientsInGoodOrder = true;

    #endregion

    #region Properties

    public bool IngredientsInGoodOrder => _ingredientsInGoodOrder;

    public float TimingFour { get; set; } = 0f;

    #endregion
    
    #region Unity Event Functions

    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<Ingredient>()) return;
        var ingredient = other.GetComponent<Ingredient>();

        if (ingredient.DestroyOnUse)
        {
            Destroy(other.transform.parent.gameObject);   
        }

        if ((int)ingredient.Type == _step)
        {
            _step++;
        }
        else
        {
            _ingredientsInGoodOrder = false;
        }
    }

    #endregion
}
