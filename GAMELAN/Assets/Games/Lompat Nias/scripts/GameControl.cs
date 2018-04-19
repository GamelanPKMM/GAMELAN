using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameControl : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject finishText;
    public GameObject pauseUI;
    public bool stopBird = false;
    public static GameControl instance;
    public float scrollSpeed = 0.5f;
    public int life = 3;
    public  float timeFinish = 0f;
    public  float maxTime = 20f;
    public float acceleration = 1;
    private bool pause = false;
    

    // Use this for initialization

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        //update Proggress bar
        if (timeFinish <= maxTime && !stopBird)
        {
            timeFinish += Time.deltaTime;
            int result = (int)(timeFinish * 100 / maxTime);            
            if (result % 5 == 0 && result > 4)
            {
                updateSpeed();
            }
        }
        //Finish
        else if (timeFinish > maxTime)
        {
            birdFinish();
        }
    }

    private void Update()
    {
        //Mereload sceane
        if (stopBird == true && Input.GetKeyDown("up"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }
    }
    
    //menmpilkan text gameover
    public void birdDead()
    {
        gameOverText.SetActive(true);
        stopBird = true;
    }

    //pengurangan nyawa
    public void lifeDecrease()
    {
        if (stopBird)
        {
            return;
        }
        //Debug.Log("nyawa kurang 1");
    }

    public void birdFinish()
    {
        finishText.SetActive(true);
        stopBird = true;
    }
    //mengupdate kecepatan scroll background dan obstacle
    void updateSpeed()
    {
        scrollSpeed += acceleration/1000;
        ScrollBackground.updateSpeed(scrollSpeed);
    }

    //untuk Pause game
    public void birdPause()
    {
        if (pause)
        {
            pause = false;
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pause = true;
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        
    }
}
