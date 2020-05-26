using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    bool dangerous;
    AudioSource asound;
    public Camera fcam;
    private void OnTriggerEnter(Collider other)
    {
        if( other.tag == "Weapon1") 
        {
            dangerous = true;
            Destroy(other.GetComponent<WeaponRotate>());
            Destroy(other.GetComponent<BoxCollider>());
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.x = 0f;
            rotationVector.y = -170;
            rotationVector.z = 0f;
            other.transform.parent = this.transform;
            other.transform.rotation = Quaternion.Euler(rotationVector);
            other.transform.localPosition = new Vector3(0.18f, 1f, 0.8f);
            other.GetComponent<AudioSource>().Play();
        }
    }

    private void Start()
    {
        dangerous = false;
        asound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Debug.DrawRay(fcam.transform.position, transform.forward * 1000, Color.white);
        if (dangerous == true && Input.GetButtonDown("Fire1"))
        {
            asound.Play();
            fcam.GetComponent<ShootScript>().Shoot(fcam,10000f);
        }
    }


}
