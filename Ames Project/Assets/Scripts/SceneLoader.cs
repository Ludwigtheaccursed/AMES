using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    string sceneToLoad;
    [SerializeField]
    string sceneToLoad2;




    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);

    }
    public void LoadScene2()
    {
        SceneManager.LoadScene(sceneToLoad2);

    }
    public void Quit()
    {
        Application.Quit();
    }
}

