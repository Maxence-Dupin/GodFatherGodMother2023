using UnityEngine;

public class Ingredient : MonoBehaviour
{
    #region Enum

    public enum IngredientType
    {
        Flour = 0,
        Sugar = 1,
        Fruit1 = 3,
        Fruit2 = 4,
        Fruit3 = 5,
    }

    #endregion

    #region Fields

    [SerializeField] private IngredientType _type;
    [SerializeField] private bool _destroyOnUse;

    #endregion

    #region Properties

    public IngredientType Type => _type;
    
    public bool DestroyOnUse => _destroyOnUse;

    #endregion
}
