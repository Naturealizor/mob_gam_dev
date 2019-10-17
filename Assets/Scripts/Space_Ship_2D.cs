using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Space_Ship_2D : MonoBehaviour
{
    // float shotPower = 1;
    // bool timerIsGoing = false;
    // float timer = 0;
    public float speed = 10;
    public float rotSpeed = 10;
    public int health = 100;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    // GUIText scoreText;

    private float turnDirection = 0;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        // GameObject ScoreText 
        pauseMenu.SetActive(false);
        deathScreen.SetActive(false);
        resetButton.SetActive(false);
        saveButton.SetActive(false);
        restartButton.SetActive(false);
        menuButton.SetActive(false);
        winScreen.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    { 
        // if(Input.GetKey(KeyCode.RightArrow)) { 
        //     turnDirection = -1;
        // } else if(Input.GetKey(KeyCode.LeftArrow)) {  
        //     turnDirection = 1;
        // } else {
        //     turnDirection = 0;
        // }

        if(Input.GetKeyDown(KeyCode.Escape)) {
            Pause();
        }       
        if(health == 0) {
            playerIsDead = true;
            youDied();
        }
        if(score >= 500) {
            Win();
        }
        
    }

    void FixedUpdate() 
    {
        rb.AddRelativeForce(Vector2.up * speed);
        rb.AddTorque(turnDirection * rotSpeed, 0);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Asteroid")) {
            health -= 10;
            youDied();
        } 
        else if(other.gameObject.CompareTag("Pickup")){
            score += 50;
            scoreText.text = "Score = " + score;
            Destroy(other.gameObject);
            // Score();
        }
         else if(other.gameObject.CompareTag("Wall")) {
            health -= 100;
            youDied();
        }
    }


    public bool gameIsPaused = false;
    public bool playerIsDead = false;
    public GameObject pauseMenu;        // make sure you assign this or there will be errors!!!
    public GameObject resetButton;
    public GameObject saveButton;
    public GameObject deathScreen;
    public GameObject restartButton;
    public GameObject menuButton;
    public GameObject winScreen;
    



    void Pause() {
        if(gameIsPaused) {
            // unpause the game because it is already paused.
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            Load();
        } else {
            // pause the game because it is not paused.
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            resetButton.SetActive(true);
            saveButton.SetActive(true);
            Save();
        }

        // if paused, make it NOT paused. if NOT paused, make it paused.
        gameIsPaused = !gameIsPaused;
    }

    void youDied() {
            if (playerIsDead) {
                Destroy(this.gameObject);
                deathScreen.SetActive(true);
                restartButton.SetActive(true);
                menuButton.SetActive(true);
        } else {
            deathScreen.SetActive(false);
        }
    }

    void Win() {
        if(score >= 500) {
        winScreen.SetActive(true);
    } else {
        winScreen.SetActive(false);
        }
    }
    // public void Score() {
    //     PlayerPrefs.GetInt("Score", score);
    //     scoreText.text = "Score = " + score;
    // }

    public void Restart() {
        Debug.Log("Did this work?");
        SceneManager.LoadScene("Space_Collector");
        Load();
    }

    public void Menu(int index = 6) {
        SceneManager.LoadScene(index);
    }

    public void Save() {
        PlayerPrefs.SetInt("Health", health);
        PlayerPrefs.SetInt("Score", score);
    }

    public void Load() {
        health = PlayerPrefs.GetInt("Health");
        score = PlayerPrefs.GetInt("Score");
    }

   public void Reset() {
        PlayerPrefs.SetInt("Health", 100);
        PlayerPrefs.SetInt("Score", 0);
        Load();
    }

    public void UpdateTurnDirection(int direction) {
        turnDirection = direction;
    }

    // public void Death() {
        
    // }

}
