using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    public int health = 100;
    private void Update()
    {
        if (health <= 0)
        {
            GetComponent<SC_FPSController>().PM.Reload();
        }
    }
}
