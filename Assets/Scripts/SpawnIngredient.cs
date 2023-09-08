using UnityEngine;

public class SpawnIngredient : MonoBehaviour
{
    public GameObject Fruit1;
    public GameObject Fruit2;
    public GameObject Fruit3;
    [SerializeField] Transform SpawnPoint1;
    [SerializeField] Transform SpawnPoint2;
    [SerializeField] Transform SpawnPoint3;
    [SerializeField] AudioClip FoodDispenser;

    void Update()
    {
        if (Input.GetKeyDown(InputManager.Instance.Button1_1))
        {
            Instantiate(Fruit1, SpawnPoint1.position, SpawnPoint1.rotation);
            AudioManager.Instance.ChangerAudio(FoodDispenser);
        }
        if (Input.GetKeyDown(InputManager.Instance.Button1_2))
        {
            Instantiate(Fruit2, SpawnPoint2.position, SpawnPoint2.rotation);
            AudioManager.Instance.ChangerAudio(FoodDispenser);
        }
        if (Input.GetKeyDown(InputManager.Instance.Button1_3))
        {
            Instantiate(Fruit3, SpawnPoint3.position, SpawnPoint3.rotation);
            AudioManager.Instance.ChangerAudio(FoodDispenser);
        }
    }
}
