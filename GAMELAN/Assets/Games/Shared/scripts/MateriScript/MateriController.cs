using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class MateriController : MonoBehaviour {
    public float waitTime = 4;
    public static MateriController self;
    public GameObject parent;
    public Image gambar;
    public Text penjelasan;
    public Button next;
    public Button prev;
    public Scrollbar scroll;
    public Text timer;
    private Text next_text;
    private GamesMateri materis;
    public int current = 0;
    public int lastSaw = -1;
    public int last = 0;
    private string materiPath = null;
    private float dt = 0;
    private float time;
    private MiniGameLoaderScript m;
    private Coroutine waiting;
    private UnityEvent scrollOnValueChanged = new UnityEvent();
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

    void Start() {
        //scroll.onValueChanged.AddListener(delegate { scrollOnValueChanged.Invoke(); });
        self = this;
        parent.SetActive(false);
        next.onClick.AddListener(Next);
        prev.onClick.AddListener(Prev);
        next_text = next.transform.GetChild(0).gameObject.GetComponent<Text>();
    }

    public void startMateri() {
        dt = 0;
        start();
    }
    public void startPreGameMateri(MiniGameLoaderScript m) {
        dt = 2;
        this.m = m;
        start();
    }
    public void setMateriPath(string name)
    {
        materiPath = name;
    }
    public void quit()
    {
        this.parent.SetActive(false);
        m = null;
    }
    void start() {
        parent.SetActive(true);
        prev.transform.gameObject.SetActive(false);
        materis = GamesMateri.load(materiPath);
        current = 0;
        lastSaw = -1;
        last = materis.materis.Count;
        time = Time.time;
        next_text.text = "Lanjut";
        next.transform.gameObject.SetActive(false);
        showmateri(current);
    }
    void Next() {
        if (current == last - 2)
        {
            next_text.text = "Main";
        }
        if (current < last-1)
        {
            next.transform.gameObject.SetActive(false);
            prev.transform.gameObject.SetActive(true);
            showmateri(++current);
            time = Time.time;
        }
        else finish();
    }
    void Prev() {
        if (current > 0)
        {
            next_text.text = "Lanjut";
            StopCoroutine(waiting);
            timer.text = "";
            next.transform.gameObject.SetActive(true);
            showmateri(--current);
        }
       
    }

    void showmateri(int i) {
        penjelasan.text = materis.materis[i].Penjelasan;
        scroll.value = 1;
        try
        {
            gambar.sprite = Resources.Load<Sprite>("Materi/Gambar/" + materis.materis[i].imageName);
        }
        catch (NullReferenceException e) {
            Debug.Log("File cannot be found. AT " + System.DateTime.Now);
        }
        if (current <= 0)
        {
            prev.transform.gameObject.SetActive(false);
        }
        Debug.Log("Materi/Gambar/" + materis.materis[i].imageName);
        if (lastSaw <= current)
        {
            waiting = StartCoroutine(wait());
            lastSaw = current;
            //next.transform.gameObject.SetActive(false);
            /*
            if (!scroll.gameObject.activeSelf && scroll.size >=0.9)
            {
                scrollOnValueChanged.RemoveListener(checkForScroll);
            }
            else
            {
                scrollOnValueChanged.AddListener(checkForScroll);
            }*/
        }
        else {
            next.transform.gameObject.SetActive(true);

        }

    } 
    void finish() {
        this.parent.SetActive(false);
        if (m != null)
        {
            m.gotoMiniGames();
        }
        else m = null;
    }
    /*
    public void checkForScroll() {
        if (scroll.value == 0) {
            next.transform.gameObject.SetActive(true);
            timer.text = "";
            StopCoroutine(waiting);
            scrollOnValueChanged.RemoveListener(checkForScroll);
        }
    }*/

    IEnumerator wait() {
        int i = 0;
        while (i <= waitTime) {
            timer.text = "" + ((int)(waitTime - i));
            yield return new WaitForSecondsRealtime(1);
            i++;
        }
        next.transform.gameObject.SetActive(true);
    }
}
