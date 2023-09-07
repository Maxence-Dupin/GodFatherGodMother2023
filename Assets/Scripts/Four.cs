using UnityEngine;

public class Four : MonoBehaviour
{
    #region Fields

    [SerializeField] private Bowl _bowl;
    [SerializeField] private Rigidbody _bowlRb;
    [SerializeField] private BoxCollider _bowlTrigger;
    [SerializeField] private Transform _bowlInTransform;
    [SerializeField] private Transform _bowlOutTransform;

    private bool open;
    
    [SerializeField] private int _timeBeforeFire = 20;

    [SerializeField] private GameObject _fire;

    private bool _leftHandInTrigger;
    private bool _rightHandInTrigger;
    private bool _bowlIn;
    private bool _closed;
    private bool _onFire;

    private float _timer;

    #endregion

    #region Unity Function Events

    private void Update()
    {
        if (Input.GetKeyDown(InputManager.Instance.RedButton))
        {
            _closed = !_closed;
        }
        
        if (_bowlIn && _closed)
        {
            _bowl.TimingFour += Time.deltaTime;
            _timer += Time.deltaTime;
        }

        if (_bowlIn && !_closed && 
            ( (_leftHandInTrigger && Input.GetKeyDown(InputManager.Instance.LeftJoystickButton1)) || 
              (_rightHandInTrigger && Input.GetKeyDown(InputManager.Instance.RightJoystickButton1) )))
        {
            _bowlRb.transform.position = _bowlOutTransform.position;
            _bowlRb.isKinematic = false;
            _bowlTrigger.enabled = true;
            
            _bowlIn = false;
        }

        if (_timer > _timeBeforeFire && !_onFire)
        {
            _onFire = true;
            _fire.SetActive(true);
        }

        if (Input.GetKeyDown(InputManager.Instance.BlueButton) && _onFire)
        {
            _fire.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Bowl>() && !_closed)
        { 
            if (_bowlRb.transform.parent.parent != null)
            {
                _bowlRb.transform.parent.parent.GetComponent<Pickup>().DropObject();
                
                _bowlRb.isKinematic = true;
                _bowlTrigger.enabled = false;
                
                _bowlIn = true;
                _bowlRb.gameObject.transform.position = _bowlInTransform.position;
            }
        }

        if (other.CompareTag("HandLeft"))
        {
            _leftHandInTrigger = true;
        }
        
        if (other.CompareTag("HandRight"))
        {
            _rightHandInTrigger = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {        
        if (other.CompareTag("HandLeft"))
        {
            _leftHandInTrigger = false;
        }
        
        if (other.CompareTag("HandRight"))
        {
            _rightHandInTrigger = false;
        }
    }

    #endregion
}
