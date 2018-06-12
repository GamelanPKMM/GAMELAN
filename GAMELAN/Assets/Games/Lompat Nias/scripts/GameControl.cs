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
    public float scrollSpeed = 5f;
    public float percentageUpdateSpeed = 5f;
    public float acceleration = 1f;
    public int life = 3;
    public int star = 0;
    public int result = 0;
    public  float timeFinish = 0f;
    public  float maxTime = 20f;
    private bool pause = false;
    public bool gameOver = false;
    public bool finish = false;
    static public bool tutorialNias = true;
    public bool input = true;
    public string gameName = "LompatNias";
    //variabel lock update speed
    private int tmp = 4;
    

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
        input = true;
        //Delay Start
        DelayStart.self.StartCountDown();
        //Memilih soal pada game
        QuestionControlNias.instance.gameName = gameName;
    }

    private void Update()
    {
        //Seleksi delay start dan Pause
        if (!DelayStart.self.DelayLock)
        {
            //update Proggress bar
            if (timeFinish <= maxTime && !stopBird)
            {
                timeFinish += Time.deltaTime;
                result = (int)(timeFinish * 100 / maxTime);
                
                //update Speed
                if (result % percentageUpdateSpeed == 0 && result > tmp)
                {
                    tmp = result;
                    Debug.Log("Update Speed");
                    updateSpeed();
                }
            }
            //Finish
            else if (timeFinish > maxTime)
            {
                birdFinish();
            }
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
        //Ganti Text Menang atau kalah
        Time.timeScale = 0;
        if (!finish)
        {
            gameOverText.transform.Find("kata").GetComponent<Text>().text = "KALAH !!";
        }
        else
        {
            gameOverText.transform.Find("kata").GetComponent<Text>().text = "MENANG !!";
        }
        gameOverText.SetActive(true);
        enabled = stopBird;
        ParalaxControl.self.StopBackground();
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
        life--;
        lifeControlUI.instance.removeLife();
        //Debug.Log("nyawa kurang 1");
    }

    public void lifeIncrease()
    {
        if (life < 3)
        {
            lifeControlUI.instance.addLife();
            life++;
        }
       
        if (stopBird)
        {
            return;
        }
        //Debug.Log("nyawa kurang 1");
    }

    public void StarIncrease()
    {
        StarControl.instance.addStar();
        star++;
    }

    public void birdFinish()
    {
        finish = true;
        stopBird = true;
        Time.timeScale = 0;
        birdDead();
    }
    //mengupdate kecepatan scroll background dan obstacle
    void updateSpeed()
    {
        scrollSpeed += acceleration;
        ParalaxControl.self.updateSpeed(scrollSpeed);
    }

    //untuk Pause game
    public void birdPause()
    {
        if (pause)
        {
            pause = false;
            pauseUI.SetActive(false);
            //Delay CountDown
            DelayStart.self.PauseCountDown();
            enabled = true;
        }
        else
        {
            pause = true;
            enabled = false;
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        
    }
    public void gotoMap()
    {
        tutorialNias = true;
        //Time.timeScale = 1;
        /*
        //Tambah penghargaan
        if (star >= 5)
        {
            PenghargaanController.self.tambahPenghargaan("Jateng");
        }
        */
        CoreGameInterface.instance.exitGame(star);
        
    }
}
