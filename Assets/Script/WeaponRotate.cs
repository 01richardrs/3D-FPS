using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotate : MonoBehaviour
{
    public float XAngle;
    public float YAngle;
    public float ZAngle;


    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0 , 0+2, 0);
    }
}
