using UnityEngine;
using System.Collections;

public class Asteroids : MonoBehaviour
{

    public GameObject explosionPrefab;
    public GameObject miniAsteroids;
    int worldSize = 20;
    int life = 2;
    [SerializeField]
    private float tumble;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
        GetComponent<Rigidbody>().velocity = transform.TransformDirection(Random.insideUnitSphere * 5);

    }

    void Update () {

        if(gameObject.transform.position.x > worldSize) {
            gameObject.transform.position = new Vector3(-worldSize,gameObject.transform.position.y, gameObject.transform.position.z);
        }

        else if(gameObject.transform.position.x < -worldSize) {
            gameObject.transform.position = new Vector3(worldSize,gameObject.transform.position.y, gameObject.transform.position.z);
        }

        else if(gameObject.transform.position.y > worldSize) {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, -worldSize, gameObject.transform.position.z);
        }

        else if(gameObject.transform.position.y < -worldSize) {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, worldSize, gameObject.transform.position.z);
        }

        else if(gameObject.transform.position.z > worldSize) {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -worldSize);
        }

        else if(gameObject.transform.position.z < -worldSize) {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, worldSize);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Projectile"){

            life--;
            GameManager.score += 20;

            if( life <=0 ) {
                gameObject.GetComponent<Collider>().enabled = false;
                Instantiate(explosionPrefab, transform.position, transform.rotation);

                for (int i = 0; i < 2; i++) {
                    Instantiate(miniAsteroids, transform.position, transform.rotation);
                }

                Destroy(gameObject);
            }
        }

    }
}