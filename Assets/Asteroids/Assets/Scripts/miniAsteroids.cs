using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniAsteroids : MonoBehaviour
{
    int life = 1;
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * 0.25f;
        GetComponent<Rigidbody>().velocity = transform.TransformDirection(Random.insideUnitSphere * 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile"){

            life--;
            GameManager.score += 5;

            if( life <=0 ) {
            gameObject.GetComponent<Collider>().enabled = false;
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);}
        }

    }
}
