using UnityEngine;
using UnityEngine.UI;

public class CheckForSaves : MonoBehaviour
{
    public Button resumeButton;
    public bool Saves = false;

    public void Start()
    {
        resumeButton.interactable = Saves;
    }
}
