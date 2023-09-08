using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public RecetteFini RecetteFini;
    public void SceneLoadPlay()
    {

        SceneManager.LoadScene("Antoine");
        RecetteFini.FinRecette = false;
    }
}
