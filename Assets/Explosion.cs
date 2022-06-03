using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy"){
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            gameObject.GetComponent<Collider>().enabled = false;
            Destroy(gameObject);
        }

    }
}
