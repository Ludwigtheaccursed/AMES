using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    float stalkDis = 30;
    [SerializeField]
    float dashDis = 5;
    [SerializeField]
    float dashSpeed = 50;
    [SerializeField]
    float stalkSpeed = 10;
    Vector3 home;
    GameObject player;
    NavMeshAgent enemyAge;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        home = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        enemyAge = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = player.transform.position - transform.position;
        if (dir.magnitude <= stalkDis)
        {
            enemyAge.destination = player.transform.position;
            if (dir.magnitude <= dashDis)
            {
                enemyAge.velocity = enemyAge.velocity * dashSpeed;
            }
        }
    }
}
