using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string PauseButt;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //IF the enter/return key is pressed
        if (Input.GetKeyDown(PauseButt) && Time.timeScale == 1)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
            canvas.enabled = true;
        }
        else if (Input.GetKeyDown(PauseButt) && Time.timeScale == 0)
        {
            Resume();
        }
        else if (Input.GetKeyDown("l"))
        {
            Reload();
        }

    }
    public void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        canvas.enabled = false;
    }
    public void Reload()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
