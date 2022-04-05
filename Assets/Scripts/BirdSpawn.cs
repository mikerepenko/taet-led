using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawn : MonoBehaviour {

    private GameObject visiblebird;
    public float timer = 0;
    //public GameObject bird;
    public ScrollBird scrollBird;

    void Start()
    {
        timer = 2;
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= 2)
        {
            scrollBird.StartScroll();
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

    /* void FixedUpdate()
     {
         timer += Time.deltaTime;
         //Спавн птицы
         if (visiblebird == null && timer >= 2)
         {
             transform.position = new Vector3(50f, 0.43f, transform.position.z);
             visiblebird = Instantiate(bird, transform.position, transform.rotation);
         }
         if (timer >= 2)
             timer = 0;
     }*/
}
