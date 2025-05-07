using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadWin : MonoBehaviour
{
    [SerializeField]
    string WinScene = "";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(WinScene);


        }
    }
}
