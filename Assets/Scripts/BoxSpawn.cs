using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawn : MonoBehaviour {

    public GameObject box;

    private GameObject visibleObject;
    public ScrollObstracles scrollBox;
    public float timer;
    private int rund;

    void Start()
    {
        timer = 2;
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= 2)
        {
            scrollBox.StartScroll();
        }
        /*if (visibleObject == null && timer >= 2f)
        {
            transform.position = new Vector3(217f, transform.position.y, transform.position.z);
            visibleObject = Instantiate(Obstacle, transform.position, transform.rotation);
        }      
        if (visiblePlane == null && timer >= 2f)
        {
            transform.position = new Vector3(300f, transform.position.y, transform.position.z);
            visiblePlane = Instantiate(Plane, transform.position, transform.rotation);
        }
        if (visibleMilk == null && timer >= 2f)
        {
            transform.position = new Vector3(104.5f, transform.position.y, transform.position.z);
            visibleMilk = Instantiate(milk, transform.position, transform.rotation);
        }*/
        if (timer >= 2f)
            timer = 0;
    }

    /*void FixedUpdate () {
            timer += Time.deltaTime;
            rund = Random.Range(1, 5);
            transform.position = new Vector3(9.96f, transform.position.y, transform.position.z);
            if (visibleObject == null && timer >= 2f)                        
                visibleObject = Instantiate(box, transform.position, transform.rotation);
                             
        
        if (timer >= 2f)
            timer = 0;
    }*/

    public void StopObstracle()
    {
        scrollBox.StopScroll();
    }
}

