using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionControlNias : MonoBehaviour {
    public static QuestionControlNias instance;
    public GameObject Parent;
    public QuestionContainer questions;
    public Question q;
    public Text question;
    public float deltaTime = 4;
    private float startTime;
    private Button[] answer = new Button[3];
    private int supposedAnswer;
    private int userAnswer;
    private bool isDOne = false;
    private bool[] uni;
    private int current = 0;
    public string gameName = "LompatNias";
    private bool isQuestionAnswerShow;

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
        //string path = gameName;
        Debug.Log(gameName);
        questions = QuestionContainer.loadQuestion(gameName);
        Console.Add("Load Question Container");
        Parent.SetActive(false);
        reset();
        // menginstansisai game Object soal
        question = Parent.transform.GetChild(1).gameObject.GetComponent<Text>();
        answer[0] = Parent.transform.GetChild(2).gameObject.GetComponent<Button>();
        answer[0].onClick.AddListener(delegate () { this.questionAnswered(0); });
        answer[1] = Parent.transform.GetChild(3).gameObject.GetComponent<Button>();
        answer[1].onClick.AddListener(delegate () { this.questionAnswered(1); });
        answer[2] = Parent.transform.GetChild(4).gameObject.GetComponent<Button>();
        answer[2].onClick.AddListener(delegate () { this.questionAnswered(2); });
    }

    //Fungsi untuk  mengeluarkan pertanyaan
    public void startQuestion()
    {
        GameControl.instance.input = false;
        Time.timeScale = 0;        
        userAnswer = -1;
        isDOne = false;
        startTime = Time.unscaledTime;
        int rand;
        do
        {
            rand = Random.Range(0, questions.question.Count);
        } while (uni[rand]);
        current = rand;
        q = questions.question[rand];
        question.text = q.question;
        for (int i = 0; i < 3; i++)
        {
            answer[i].transform.GetChild(0).gameObject.GetComponent<Text>().text = q.answers[i];
        }
        supposedAnswer = q.answer;
        isQuestionAnswerShow = false;
        foreach (Button b in answer)
        {
            b.gameObject.SetActive(false);
        }
        Parent.SetActive(true);


    }

    //Fungsi untuk mengecek jawaban user
    public void QuestionEvaluate()
    {
        if (!isDOne)
        {
            if (userAnswer == supposedAnswer)
            {
                GameControl.instance.StarIncrease();
                //jika jawaban benar maka akan nyawa ditambah 1
                //GameControl.instance.lifeIncrease();
                uni[current] = true;
            }
            else
            {
            }
            isDOne = true;
            questionStop();

        }
    }

    //Exit soal
    public void questionStop()
    {
        Time.timeScale = 1;
        GameControl.instance.input = true;
        Parent.SetActive(false);
        DelayStart.self.PauseCountDown();
    }

    //mengecek soal agar tidak keluar 2 kali
    private void questionAvailibilityCheck()
    {
        foreach (bool check in uni)
        {
            if (!check) { return; }

        }
        Debug.Log("Resetting Question");
        reset();
    }

    //Fungsi untuk mengecek jawaban
    void questionAnswered(int num)
    {
        userAnswer = num;
        QuestionEvaluate();
        questionAvailibilityCheck();
    }

    //fungsi untuk mereset soal
    void reset()
    {
        uni = new bool[questions.question.Count];
    }
    private void Update()
    {
        if (!isQuestionAnswerShow && Time.unscaledTime >= startTime + deltaTime)
        {
            foreach (Button b in answer)
            {
                b.gameObject.SetActive(true);
            }
            isQuestionAnswerShow = true;
        }
    }
}
