using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space_Ship_2D : MonoBehaviour
{
    public float speed = 10;
    public float rotSpeed = 10;
    public int health = 100;
    public int score = 0;
    

    private float turnDirection = 0;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        pauseMenu.SetActive(false);
        resetButton.SetActive(false);
        saveButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)) {
            turnDirection = -1;
        } else if(Input.GetKey(KeyCode.LeftArrow)) {
            turnDirection = 1;
        } else {
            turnDirection = 0;
        }

        if(Input.GetKeyDown(KeyCode.Escape)) {
            Pause();
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
            if(health <= 0) {
                print("You Died");
                //Destroy(this.gameObject);
            }
        } else if(other.gameObject.CompareTag("Pickup")) {
            score += 50;
            Destroy(other.gameObject);
        }
    }

    public bool gameIsPaused = false;
    public GameObject pauseMenu;        // make sure you assign this or there will be errors!!!
    public GameObject resetButton;
    public GameObject saveButton;

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
        
        //pauseMenu.SetActive(!gameIsPaused);

        // if paused, make it NOT paused. if NOT paused, make it paused.
        gameIsPaused = !gameIsPaused;
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
}
