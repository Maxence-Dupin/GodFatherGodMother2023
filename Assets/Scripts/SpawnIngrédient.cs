using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnIngrédient : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Fruit1;
    public GameObject Fruit2;
    public GameObject Fruit3;
    [SerializeField] Transform SpawnPoint1;
    [SerializeField] Transform SpawnPoint2;
    [SerializeField] Transform SpawnPoint3;
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(InputManager.Instance.Button1_1))
        {
            Instantiate(Fruit1, SpawnPoint1.position, SpawnPoint1.rotation);
        }
        if (Input.GetKeyDown(InputManager.Instance.Button1_2))
        {
            Instantiate(Fruit2, SpawnPoint2.position, SpawnPoint2.rotation);
        }
        if (Input.GetKeyDown(InputManager.Instance.Button1_3))
        {
            Instantiate(Fruit3, SpawnPoint3.position, SpawnPoint3.rotation);
        }
    }
}
