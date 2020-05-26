using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ALIVE());
    }

    // Update is called once per frame
    IEnumerator ALIVE()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
