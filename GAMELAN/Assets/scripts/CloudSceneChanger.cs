using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloudSceneChanger : MonoBehaviour {
    public GameObject left;
    public GameObject right;
    public Transform inImage;
    public Transform outImage;
    public Transform inImageR;
    public Transform outImageR;
    public string scene;
    private Rigidbody2D rbLeft;
    private Rigidbody2D rbright;
    public float speed = 2;
    private bool toogle = true;
    private Vector2 velo = Vector2.one;
    private float startTime;
    private float journeyLength;
    // Use this for initialization

    private void Start()
    {
        rbLeft = left.GetComponent<Rigidbody2D>();
        rbright = right.GetComponent<Rigidbody2D>();
    }

    public void moveIn()
    {
        startTime = Time.time;
        if (rbLeft == null || rbright == null) {
            rbLeft = left.GetComponent<Rigidbody2D>();
            rbright = right.GetComponent<Rigidbody2D>();
        }
        rbLeft.transform.position = outImage.transform.position;
        rbright.transform.position = outImageR.transform.position;
        toogle = true;
        //enabled = true;
        journeyLength = Vector2.Distance(inImage.position,outImage.position);
        StartCoroutine("move");
    }

    public void moveOut()
    {
        startTime = Time.time;
        if (rbLeft == null || rbright == null)
        {
            rbLeft = left.GetComponent<Rigidbody2D>();
            rbright = right.GetComponent<Rigidbody2D>();
        }
        rbLeft.transform.position = inImage.transform.position;
        rbright.transform.position = inImageR.transform.position;
        toogle = false;
        //enabled = true;
        journeyLength = Vector2.Distance(inImage.position, outImage.position);
        StartCoroutine("move");
    }

    public void MoveCloud()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        if (toogle)
        {  
            rbLeft.transform.position = Vector2.Lerp(rbLeft.position, inImage.position, fracJourney);
            rbright.transform.position = Vector2.Lerp(rbright.position, inImageR.position, fracJourney);
        }
        else
        {
            rbLeft.transform.position = Vector2.Lerp(rbLeft.position, outImage.position, fracJourney);
            rbright.transform.position = Vector2.Lerp(rbright.position, outImageR.position, fracJourney);
        }
       
    }

    private IEnumerator move()
    {
        bool cek = true;
        while (cek)
        {
            if (toogle && Mathf.Ceil(rbLeft.transform.position.x) >= inImage.transform.position.x)
            {
                rbLeft.velocity = Vector2.zero;
                rbright.velocity = Vector2.zero;
                Debug.Log("stopin");
                cek = false;
            }
            //move out
            else if (!toogle && Mathf.Floor(rbLeft.transform.position.x) <= outImage.transform.position.x)
            {
                rbLeft.velocity = Vector2.zero;
                rbright.velocity = Vector2.zero;
                Debug.Log("stopout");
                cek = false;
            }
            else
            {
                MoveCloud();
            }
            yield return cek;
        }
        if (toogle)
        {
            SceneManager.LoadScene(scene);
        }
    }
    public static void moveTo(string sceneName) {
        CloudSceneChanger c = getSceneChanger();
        c.scene = sceneName;
        c.moveIn();
    }
    private static CloudSceneChanger getSceneChanger() {
        GameObject g = Instantiate<GameObject>(Resources.Load("Prefabs/Scene Changer") as GameObject);
        CloudSceneChanger c = g.GetComponent<CloudSceneChanger>();
        return c;
    }

}
