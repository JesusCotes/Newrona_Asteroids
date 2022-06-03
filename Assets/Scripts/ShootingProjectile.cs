using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingProjectile : MonoBehaviour
{

    [SerializeField] private float timeToShoot;
    float charge;
    float lastTime = 0;
    float counter = 0;
    float currentTime;
    private float timeToNextShoot;

    public Rigidbody projectile;
    public GameObject canyon;

    public Image Point;

    private int force = 60;

    void start() {
    }

    void Update() {
    
        float tempTime = Time.time - lastTime;

        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit)){
            if (hit.transform.tag == "Enemy") {

                Point.color= Color.red;

                counter += tempTime;
                if (counter >= 0.5){
                    Rigidbody clone;
                    clone = Instantiate(projectile, canyon.transform.position, transform.rotation);
                    clone.velocity = transform.TransformDirection(Vector3.forward * force);
                    counter =0;
                 }
            }

            else {
                counter = Mathf.MoveTowards(counter, 0, Time.deltaTime);
                Point.color= Color.white;
            }       
        }

        else {
            counter = Mathf.MoveTowards(counter, 0, Time.deltaTime);
            Point.color= Color.white;
        } 
    
        print (counter);
        lastTime=Time.time;
    }
}