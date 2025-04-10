using UnityEngine;

public class Scythe : MonoBehaviour
{
    public float WaitTime = 1;
    float nextTimeToFire = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextTimeToFire)
        {
            nextTimeToFire = Time.time + WaitTime;
            int RandomVar = Random.Range(0, 2);
            Debug.Log(RandomVar);
            if (RandomVar > 0)
            {
                GetComponent<Animator>().SetTrigger("Swing1");
            }
            else
            {
                GetComponent<Animator>().SetTrigger("Swing2");
            }
        }
    }
}
