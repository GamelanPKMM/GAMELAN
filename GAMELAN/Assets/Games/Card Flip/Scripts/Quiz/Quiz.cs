using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour {
	public static Quiz control;
	public GameObject holder;
	public Text questionText;
	public Text[] optionText;
	public float penalty;

	private Card card;
	private int answer;

	void Start ()
	{
		if (control == null)
		{
			control = this;
		}
		else
		{
			Destroy (this.gameObject);
		}
	}

    //
    // Display question box of given card's question
    //
    public void ShowQuestion(Card card)
    {
        CardFlipManager.control.stop = true;
        if (holder != null)
        {
            Time.timeScale = 0;
            this.card = card;
            holder.SetActive(true);
            questionText.text = card.Question.question;

            for (int i = 0; i < optionText.Length; i++)
            {
                optionText[i].text = card.Question.options[i];
            }

            answer = card.Question.answer;
        }
        else
        {
            Debug.Log("Quiz Error");
        }
    }

	//
	// Hide question box and delete question from given card
	//
	public void HideQuestion ()
	{
		Time.timeScale = 1;
		this.card.Question = null;
		holder.SetActive (false);
        CardFlipManager.control.stop = false;
	}

	//
	// Match given option index with correct answer index
	//
	public void Answer (int option)
	{
		if (option == answer)
		{
			StarScore.control.AddStar ();
			Life.control.IncreaseLife ();
		}
		else
		{
			Life.control.DecreaseLife ();
			TimeBar.control.AddTime (penalty);
		}

		HideQuestion ();
	}
}
