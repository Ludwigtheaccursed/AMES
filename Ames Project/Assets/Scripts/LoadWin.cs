using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadWin : MonoBehaviour
{
    [SerializeField]
    string WinScene = "";
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "GameController")
        {
            Debug.Log("hi");
            SceneManager.LoadScene(WinScene);


        }
        else if (collision.gameObject.tag == "mask")
        {
          
        }
    }
}
