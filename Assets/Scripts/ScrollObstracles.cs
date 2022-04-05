using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObstracles : MonoBehaviour {

    public float speedObstracles;
    public bool isScroll;
    private int numShit;

    public void StartScroll()
    {
        isScroll = true;
    }
    public void StopScroll()
    {
        isScroll = false;
        transform.position = new Vector3(9.96f, transform.position.y, transform.position.z);
    }
    
  
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Car")
        {
                //При столкновении
                transform.position = new Vector3(9.96f, transform.position.y, transform.position.z);
                isScroll = false;
        }
        if (other.gameObject.name == "Plane")
        {
            //При столкновении
            transform.position = new Vector3(9.96f, transform.position.y, transform.position.z);
            isScroll = false;
        }
    }
    void Update()
    {
        if (isScroll)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-9.96f, transform.position.y, transform.position.z), speedObstracles * Time.deltaTime);
            if (gameObject.transform.position.x < -9.90f)
            {
                    transform.position = new Vector3(9.96f, transform.position.y, transform.position.z);
                    isScroll = false;
            }
        }
    }

    /* void Update() {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-9.96f, transform.position.y, transform.position.z), speedObstracles * Time.deltaTime);
        if (gameObject.transform.position.x < -9.90f)
            Destroy(gameObject);
    } */
}
