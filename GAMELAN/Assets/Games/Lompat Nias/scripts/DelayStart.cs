using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelayStart : MonoBehaviour {
    //public GameObject countDown;
    public GameObject start;
    public GameObject pause;
    public float reduce = 1.016667f;
    private float count;
    public static DelayStart self;
    public bool DelayLock = false;
    private Animator anim;
    // Use this for initialization

    private void Awake()
    {
        if (self == null)
        {
            self = this;
        }
        else if (self != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //start.SetActive(true);
        pause.SetActive(false);
    }
    //Start Count Down
    public void StartCountDown () {
        //UI Coundown
        //Get element animator pada gameObject
        anim = start.GetComponent<Animator>(); //countDown.GetComponent<Animator>();
        //Mendapat panjang waktu animasi delay
        count = anim.runtimeAnimatorController.animationClips[0].length;
        Debug.Log("Start Delay "+count+" Second");
        DelayLock = true;
        start.SetActive(true);
        StartCoroutine("StartDelay",start);
	}

    //Overlading StartCountDown untuk pause dan soal
    public void PauseCountDown()
    {
        //Get element animator pada gameObject
        anim = pause.GetComponent<Animator>();
        //Mendapat panjang waktu animasi delay
        count = anim.runtimeAnimatorController.animationClips[0].length;
        Debug.Log("Pause Delay " + count + " Second");
        DelayLock = true;
        pause.SetActive(true);
        StartCoroutine("StartDelay",pause);
    }

    //perhitungan
    IEnumerator StartDelay(GameObject param)
    {
        //mengaktifkan image component parrent
        param.transform.parent.gameObject.GetComponent<Image>().enabled = true;
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(count - 1);
        param.transform.parent.gameObject.GetComponent<Image>().enabled = false;
        //menonaktifkan image component parrent
        //Debug.Log("delay finish");
        DelayLock = false;
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(reduce);
        param.SetActive(false);
    }
}   
