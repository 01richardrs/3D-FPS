using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hiScore : MonoBehaviour
{
    public Text Hi_Score;
    // Start is called before the first frame update


    private void Awake()
    {
       // if (!PlayerPrefs.HasKey("HiScore"))
       // {
            //PlayerPrefs.SetInt("HiScore", 0);
       // }
    }

    void Start()
    {
        //PlayerPrefs.SetInt("Score", 0);
        //PlayerPrefs.SetInt("Enemy02score", 2);
        Hi_Score.text = PlayerPrefs.GetInt("Score").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
