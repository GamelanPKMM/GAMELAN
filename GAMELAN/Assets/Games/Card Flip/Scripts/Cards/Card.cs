using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
	private int id;
	private bool isFaceUp;
	private Sprite front;
	private Sprite back;
	private QuestionHolder question;
    public bool isDone;
    public float speed = 1;
    public bool isFlipping;

	void OnMouseDown () 
	{
        if (!CardFlipManager.control.stop && !CardFlipManager.control.init && !isDone && CardFlipManager.control.openedCards.Count<2)
        {
            if (this.isFaceUp)
                CloseCard();
            else
                OpenCard();
        }
	}

	public void checkQuiz ()
	{
		if(this.question != null)
		{
            //StartCoroutine(ShowQuestion ());
            ShowQuestion();
		}
	}

	//
	// Preview card in given seconds
	//
	public IEnumerator Preview (float seconds) {
        if (!CardFlipManager.control.stop)
        {
            new WaitUntil(() => !CardFlipManager.control.isQuestionShowing);
            CardFlipManager.control.init = true;
            // Flip open
            this.isFaceUp = true;
    
            StartCoroutine(Flip());

            // Wait for given seconds
            yield return new WaitForSeconds(seconds);

            // Flip close
            this.isFaceUp = false;
            StartCoroutine(Flip());
            CardFlipManager.control.init = false;

            // Add collider
            this.gameObject.AddComponent<BoxCollider2D>();
        }
       
	}

	//
	// Flip card to its front face
	//
	public void OpenCard() 
	{ 
		this.isFaceUp = true;

		CardFlipManager.control.OpenCard (this.gameObject);

		StartCoroutine (Flip()); 
	}

	//
	// Flip card to its back face
	//
	public void CloseCard() 
	{
		this.isFaceUp = false;

		CardFlipManager.control.CloseCard (this.gameObject);

		StartCoroutine (Flip ());
	}

	//
	// Coroutine for card Flipping
	//
	private IEnumerator Flip () 
	{
		int rotation = 0;
        isFlipping = true;
        if (CardFlipManager.control.openedCards.Count > 1)
        {
            StartCoroutine(CardFlipManager.control.CardMatching());
        }
        while (rotation != 180) 
		{
			// Change sprite on half flipping
			if(rotation == 90)
			{
				Sprite face = (this.isFaceUp) ? this.front : this.back;
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = face;
			}

			this.transform.Rotate (new Vector3(0, 10, 0));
			rotation += 10;
			yield return new WaitForSeconds (0.01f / this.speed);
		}
		ResetCollider ();
        isFlipping = false;
        
    }

    //
    // Show question box of this card's question
    //
    private void ShowQuestion ()
	{
        if (!CardFlipManager.control.gameOver)
        {
         //   yield return new WaitWhile(() => CardFlipManager.control.openedCards[0].GetComponent<Card>().isFlipping && CardFlipManager.control.openedCards[1].GetComponent<Card>().isFlipping);
            Debug.Log("Show QUiz");
            Quiz.control.ShowQuestion(this);
        }
        

		
	}

	//
	// Reassign collider to prevent unclickable collider bug
	//
	public void ResetCollider ()
	{
		Destroy (this.gameObject.GetComponent<Collider2D> ());
		this.gameObject.AddComponent<BoxCollider2D> ();
	}

	//
	//
	// Properties
	//
	//
	public int Id 
	{
		get { return this.id; }
		set { this.id = value; }
	}

	public Sprite Front
	{
		set { this.front = value; }
	}

	public Sprite Back 
	{
		set { this.back = value; }
	}

	public QuestionHolder Question {
		get { return this.question; }
		set { this.question = value; }
	}
}
