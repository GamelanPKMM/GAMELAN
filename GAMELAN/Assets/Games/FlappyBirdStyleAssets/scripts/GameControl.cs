using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameControl : MonoBehaviour
{
    public GameObject gameOverText;
    public bool gameOver = false;
    public static GameControl instance;
    public float scrollSpeed = 0.5f;
    public int life = 50;
    public Text lifeUi;


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

    private void Update()
    {
        if (gameOver == true && Input.GetKeyDown("up"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void birdDead()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }

    public void lifeDecrease()
    {
        Debug.Log("kurang 1");
        if (gameOver)
        {
            return;
        }
        lifeUi.text = "Life : " + life.ToString();
    }
}
