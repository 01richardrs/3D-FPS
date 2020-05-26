using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.VFX;

public class enemyAI : MonoBehaviour
{
    public GameObject bullet;
    NavMeshAgent navAgent;
    [SerializeField]
    GameObject target;
    private Animator anim;
    public GameObject SpawnPoint;
    public GameObject SpawnPoint1;
    public GameObject SpawnPoint2;
    public GameObject SpawnPoint3;
    public GameObject SpawnPoint4;
    public GameObject SpawnPoint5;
    public GameObject SpawnPoint6;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        navAgent.SetDestination(target.transform.position);
        if (navAgent.velocity != Vector3.zero)
        {
            anim.SetFloat("Speed", 10);
        }
        else {
            anim.SetFloat("Speed", 0);
        }

    }

    public void Respawn() 
    {
        var randnum = Random.Range(0, 6);
        switch (randnum) 
        {
            case 0:
                transform.position = SpawnPoint.transform.position;
                break;
            case 1:
                transform.position = SpawnPoint1.transform.position;
                break;
            case 2:
                transform.position = SpawnPoint2.transform.position;
                break;
            case 3:
                transform.position = SpawnPoint3.transform.position;
                break;
            case 4:
                transform.position = SpawnPoint4.transform.position;
                break;
            case 5:
                transform.position = SpawnPoint5.transform.position;
                break;
            case 6:
                transform.position = SpawnPoint6.transform.position;
                break;
        }
        

    }

    public void AddEnemy()
    {
        var randnum = Random.Range(0, 6);
        switch (randnum)
        {
            case 0:
                GameObject instEnemy = Instantiate(bullet, SpawnPoint.transform.position, Quaternion.identity) as GameObject;
                break;
            case 1:
                GameObject instEnemy1 = Instantiate(bullet, SpawnPoint1.transform.position, Quaternion.identity) as GameObject;
                break;
            case 2:
                GameObject instEnemy2 = Instantiate(bullet, SpawnPoint2.transform.position, Quaternion.identity) as GameObject;
                break;
            case 3:
                GameObject instEnemy3 = Instantiate(bullet, SpawnPoint3.transform.position, Quaternion.identity) as GameObject;
                break;
            case 4:
                GameObject instEnemy4 = Instantiate(bullet, SpawnPoint4.transform.position, Quaternion.identity) as GameObject;
                break;
            case 5:
                GameObject instEnemy5 = Instantiate(bullet, SpawnPoint5.transform.position, Quaternion.identity) as GameObject;
                break;
            case 6:
                GameObject instEnemy6 = Instantiate(bullet, SpawnPoint6.transform.position, Quaternion.identity) as GameObject;
                break;
        }
        
    }

    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }


}
