using UnityEngine;

public class Ingredient : MonoBehaviour
{
    #region Enum

    public enum IngredientType
    {
        Flour = 0,
        Sugar = 1,
        Fruit1 = 2,
        Fruit2 = 3,
        Fruit3 = 4,
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
