using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShootScript : MonoBehaviour
{
    //public Text Score;
    public GameObject bullet;
    public float speed = 10000f;
    AudioSource asound;

    public Text scoreTXT;
    int en01score = 0;
    int score = 0;

    private void Start()
    {
        asound = GetComponent<AudioSource>();
        //GameObject scoreText = GameObject.Find("Score");
        //Score = scoreText.GetComponent<Text>();
        //en01score = PlayerPrefs.GetInt("Enemy02score");
        en01score = 2;
        //print("Enemy Score:" + en01score);
        //scoreTXT.text = scoreTXT.ToString();
    }
    void Update()
    {
        Debug.DrawLine(transform.position, transform.forward * 1000, Color.yellow);       
    }

    public void Shoot(Camera cam,float range)
    {
       
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.x = 0;
        rotationVector.y = 180;
        rotationVector.z = 90;


        RaycastHit hit;
        Ray myRay;
        myRay = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(myRay, out hit, range))
        {
            GameObject instBullet = Instantiate(bullet, hit.point, Quaternion.Euler(rotationVector)) as GameObject;
            Rigidbody instBulletRigidBody = instBullet.GetComponent<Rigidbody>();
            instBulletRigidBody.AddForce(Vector3.forward * speed);
            if (hit.transform.gameObject.tag == "Enemy")
            {
                asound.Play();
                //hit.transform.gameObject.GetComponent<enemyAI>().DestroyEnemy();
                hit.transform.gameObject.GetComponent<enemyAI>().Respawn();
                hit.transform.gameObject.GetComponent<enemyAI>().AddEnemy();

                score += en01score;
                print("Score:" + score);
                PlayerPrefs.SetInt("Score", score);
                scoreTXT.text = score.ToString();

                //int iscore = int.Parse(Score.text) + 1;
                //Score.text = iscore.ToString();
            }
        }
        //if (Physics.Raycast(transform.position, transform.forward, out hit, range) && hit.transform.gameObject.tag == "Enemy")
       // {
        //    print("enemy hit");
        //}
    }



}
