using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void SceneLoadPlay()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
