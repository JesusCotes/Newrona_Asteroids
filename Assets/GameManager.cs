using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public static int score = 0;
    public static int lifes = 3;
    public Image[] hearts;
    int level = 0;
    public GameObject asteroidsPrefab;


    // Start is called before the first frame update
    void Start()
    {
        nextLevel();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text= score.ToString();

        if(score >= 150 * level){
            nextLevel();
        }

        if (lifes==3){
            hearts[0].color = Color.white;
            hearts[1].color = Color.white;
            hearts[2].color = Color.white;
        }

        else if (lifes==2){
            hearts[0].color = Color.white;
            hearts[1].color = Color.white;
            hearts[2].color = Color.black;
        }

        if (lifes==1){
            hearts[0].color = Color.white;
            hearts[1].color = Color.black;
            hearts[2].color = Color.black;
        }

        if (lifes==0){
            hearts[0].color = Color.black;
            hearts[1].color = Color.black;
            hearts[2].color = Color.black;
        }

        if(lifes <= 0) {
            
            score =0;
            lifes = 3;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }

    void nextLevel() {

        for (int i = 0; i < 4 + level; i++) {
            Instantiate(asteroidsPrefab, new Vector3 (Random.Range(-15, 15),Random.Range(-15, 15), Random.Range(-15, 15)), transform.rotation);
        }
        level++;
    }
}
