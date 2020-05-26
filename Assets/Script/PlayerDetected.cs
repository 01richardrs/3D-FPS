using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetected : MonoBehaviour
{
    AudioSource asound;
    public float timeLeft = 5.0f;
    // Start is called before the first frame update
    private void Start()
    {
        asound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            asound.Play();
            StartCoroutine(WaitFor(1));
        }
        
    }

    IEnumerator WaitFor(float num)
    {
        yield return new WaitForSeconds(num);
        SceneManager.LoadScene("GameOver");
    }

}
