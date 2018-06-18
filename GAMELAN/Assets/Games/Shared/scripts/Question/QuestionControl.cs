using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestionControl : SubController {
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
    private bool isQuestionAnswerShow;
    private int current = 0;
    protected override void start()
    {
        base.start();
        string path = basicGameControl.name;
        Debug.Log(path);
        questions = QuestionContainer.loadQuestion(path);
        basicGameControl.addEvent("Reset", reset);
        Console.Add("Success");        
        Parent.SetActive(false);
        reset();

    }

    protected override void instantiate<T>()
    {
        base.instantiate<T>();
        basicGameControl.addSubController("QuestionControl", this);
        question = Parent.transform.GetChild(1).gameObject.GetComponent<Text>();
        answer[0] = Parent.transform.GetChild(2).gameObject.GetComponent<Button>();
        answer[0].onClick.AddListener(delegate() { this.questionAnswered(0); });
        answer[1] = Parent.transform.GetChild(3).gameObject.GetComponent<Button>();
        answer[1].onClick.AddListener(delegate() { this.questionAnswered(1); });
        answer[2] = Parent.transform.GetChild(4).gameObject.GetComponent<Button>();
        answer[2].onClick.AddListener(delegate() { this.questionAnswered(2); });
            
        
        
  
    }

    public void startQuestion() {

        basicGameControl.banUserInput();
        basicGameControl.pauseGame();
        userAnswer = -1;
        isDOne = false;
        isQuestionAnswerShow = false;
        int rand;
        startTime = Time.time;
        do
        {
            rand = Random.Range(0, questions.question.Count);
        } while (uni[rand]);
        current = rand;
        q = questions.question[rand];
        question.text = "";

        for (int i = 0; i < 3; i++) {
            answer[i].transform.GetChild(0).gameObject.GetComponent<Text>().text = q.answers[i];
        }
        supposedAnswer = q.answer;
        foreach (Button b in answer) {
            b.gameObject.SetActive(false);
        }
        Parent.GetComponent<Interpolate>().Enable(() => {
            RunningText.runningText(q.question, question, 0.075F, () => {
                foreach (Button b in answer)
                {
                    b.gameObject.SetActive(true);
                }
                isQuestionAnswerShow = true;
            });
        });


    }

    public void QuestionEvaluate() {
        if(!isDOne){
             if (userAnswer == supposedAnswer)
             {
                 basicGameControl.SubController<StarController>("StarController").increaseStar();
                uni[current] = true;

            }
            else {
             }
             isDOne = true;
            questionStop();

       }
    }

    public void questionStop() {
        basicGameControl.allowUserInput();
        basicGameControl.unpauseGame();
        Parent.GetComponent<Interpolate>().Disable();
    }

    private void questionAvailibilityCheck() {
        foreach (bool check in uni) {
            if (!check) { return; }
            
        }
        Debug.Log("Resetting Question");
        reset();
    }
    void questionAnswered(int num) {
        userAnswer = num;
        QuestionEvaluate();
        questionAvailibilityCheck();
    }

    void reset()
    {
        uni = new bool[questions.question.Count];
    }

    private void Update()
    {
        if (!isQuestionAnswerShow && Time.time >= startTime + deltaTime) {
            
        }   
    }
}
