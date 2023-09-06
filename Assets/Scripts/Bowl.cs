using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    #region Fields

    private int _step = 0;

    private bool _isSuccess;

    #endregion

    #region Properties

    private bool IsSuccess => _isSuccess;

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
            _isSuccess = false;
        }
    }

    #endregion
}
