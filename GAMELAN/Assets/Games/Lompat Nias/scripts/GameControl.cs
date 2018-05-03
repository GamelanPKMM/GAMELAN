using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameControl : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject pauseUI;
    public bool stopBird = false;
    public static GameControl instance;
    public float scrollSpeed = 0.5f;
    public int life = 3;
    public int star = 0;
    public  float timeFinish = 0f;
    public  float maxTime = 20f;
    public float acceleration = 1;
    private bool pause = false;
    public int result = 0;
    public bool gameOver = false;
    

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
            result = (int)(timeFinish * 100 / maxTime);            
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
    
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
    }
    //menmpilkan text gameover
    public void birdDead()
    {
        gameOverText.SetActive(true);
        stopBird = true;
        gameOver = true;
    }

    //pengurangan nyawa
    public void lifeDecrease()
    {
        if (stopBird)
        {
            return;
        }
        life -= 1;
        //Debug.Log("nyawa kurang 1");
    }

    public void lifeIncrease()
    {
        if (life < 3)
        {
            life += 1;
        }
       
        if (stopBird)
        {
            return;
        }
        if (life < 3)
        {
            
        }
        
        //Debug.Log("nyawa kurang 1");
    }

    public void birdFinish()
    {
        stopBird = true;
        birdDead();
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
    public void gotoMap()
    {
        SceneManager.LoadScene("MAP");
        Time.timeScale = 1;
    }
}
