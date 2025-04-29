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
    NavMeshAgent enemyAgent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        home = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        enemyAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 dir = player.transform.position - transform.position;
        if (dir.magnitude <= stalkDis)
        {
            enemyAge.destination = player.transform.position;
            if (dir.magnitude <= dashDis)
            {
                enemyAge.velocity = enemyAge.velocity * dashSpeed;
            }
        }*/
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= stalkDis)
        {
            enemyAgent.destination = player.transform.position;
        }
        if (distance <= dashDis)
        {
            enemyAgent.velocity = enemyAgent.velocity * dashSpeed;
        }
    }
}
