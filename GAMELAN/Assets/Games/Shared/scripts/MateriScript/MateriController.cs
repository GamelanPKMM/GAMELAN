using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class MateriController : MonoBehaviour {
   // public float waitTime = 4;
    public static MateriController self;
    public GameObject parent;
    public Image gambar;
    public Text penjelasan;
    public Button next;
    public Button prev;
    public ScrollRect scroll;
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
    private UnityAction<Vector2> scrollEvent;
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
         self = this;
        GetComponent<Interpolate>().Disable();
        next.onClick.AddListener(Next);
        prev.onClick.AddListener(Prev);
        scrollEvent = new UnityAction<Vector2>(delegate { scroll.verticalNormalizedPosition = 0; });
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
        GetComponent<Interpolate>().Disable();
        while (RunningText.list.Count > 0) {
            Destroy(RunningText.list[0].gameObject);
            RunningText.list.RemoveAt(0);
        }
        m = null;
    }
    void start() {
        GetComponent<Interpolate>().Enable();
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
            timer.text = "";
            next.transform.gameObject.SetActive(true);
            while (RunningText.list.Count > 0)
            {
                Destroy(RunningText.list[0].gameObject);
                RunningText.list.RemoveAt(0);
            }
            showmateri(--current);
        }
       
    }

    void showmateri(int i) {
        penjelasan.text = "";
        
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
            lastSaw = current;
            scroll.onValueChanged.AddListener(scrollEvent);
            RunningText.runningText(materis.materis[i].Penjelasan, penjelasan, 0.04F, delegate { next.transform.gameObject.SetActive(true); scroll.onValueChanged.RemoveListener(scrollEvent); });
        }
        else {
            penjelasan.text = materis.materis[i].Penjelasan;
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
    IEnumerator wait() {
        int i = 0;
        while (i <= waitTime) {
            timer.text = "" + ((int)(waitTime - i));
            yield return new WaitForSecondsRealtime(1);
            i++;
        }
        next.transform.gameObject.SetActive(true);
    }*/
}
