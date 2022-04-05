using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priz : MonoBehaviour
{

    public float speed;
    private float timer;

    void Start()
    {
        if (PlayerPrefs.GetInt("PrizMoto") % 3 != 0)
        {
            gameObject.SetActive(false);
            if(PlayerPrefs.GetInt("PrizMoto") == 3)
                PlayerPrefs.SetInt("PrizMoto", 0);
        }
        PlayerPrefs.SetInt("PrizMoto", PlayerPrefs.GetInt("PrizMoto") + 1);
        if (PlayerPrefs.GetInt("BuySave110") == 1)
            gameObject.SetActive(false);
    }

    void Update()
    {
        if (transform.position.y != 3.5f)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 0.3f, transform.position.z), speed * 0.02f);
        
    }
    public void YesClick()
    {
        if (PlayerPrefs.GetString("Music") != "no")
            GameObject.Find("Click audio").GetComponent<AudioSource>().Play();
        gameObject.SetActive(false);
    }
}