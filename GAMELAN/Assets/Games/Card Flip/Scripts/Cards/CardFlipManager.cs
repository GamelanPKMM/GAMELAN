using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CardFlipManager : MonoBehaviour 
{
	public static CardFlipManager control;

	public GameObject card;
	public List<Sprite> cardFrontFaces;
	public Sprite cardBackFace;
	public Vector3[] cardPositions;
	public List<GameObject> openedCards;
	public GameObject cardsHolder;

	public TextAsset questionData;

	public int[] sessionMaxCards;
	public int[] sessionMaxQuestions;

	public GameObject winDisplay;
    public Text ending;
	public GameObject gameOverDisplay;
	public GameObject pauseDisplay;
    public bool stop = false;
    public bool init = false;

	public float previewTime;

	private List<QuestionHolder> questionList;

	private int remainingCardPairs = 0;
	private int currentSession = 1;
    public bool gameOver;

	void Awake () 
	{
		if(control == null) 
		{ 
			control = this; 
		}
		else 
		{ 
			Destroy (this); 
		}
	}

	void Start () 
	{
        Application.targetFrameRate = 75;
        DeserializeQuestions ();
		InitSession ();
        gameOver = false;
	}

	//
	// Pause the gameplay
	//
	public void Pause ()
	{
		Time.timeScale = 0;
		pauseDisplay.SetActive (true);
        stop = true;
	}

	//
	// Resume paused gameplay
	//
	public void Resume ()
	{
		Time.timeScale = 1;
		pauseDisplay.SetActive (false);
        stop = false;
	}

	//
	// Player's win
	//
	public void Win ()
	{
        gameOver = true;
        Time.timeScale = 0;
        winDisplay.SetActive (true);
        //change String if winner
        ending.text = "MENANG !!";
        stop = true;
	}

	//
	// Player's loss
	//
	public void GameOver ()
	{
        gameOver = true;
        stop = true;
        Destroy (cardsHolder);
        //change String if lose
        gameOverDisplay.SetActive (true);
        ending.text = "KALAH !!";
        Quiz.control.holder.SetActive(false);
   
	}

    //
    // reset game
    //
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    //
    // Flip card and add it into opened card list
    //
    public void OpenCard (GameObject card) 
	{
		this.openedCards.Add (card);
	}

	//
	// Flip card and remove it from opened card list
	//
	public void CloseCard (GameObject card) 
	{
		this.openedCards.Remove (card);
	}

	//
	// Start a new session
	//
	private void InitSession () 
	{
		this.remainingCardPairs = (this.sessionMaxCards [this.currentSession - 1] / 2);

		List<int> cardId = GenerateId ();
		List<int> cardWithQuestion = RandomQuestionAssign (cardId);

		// Stop time
		Time.timeScale = 0;

		for (int i = 0; i < this.sessionMaxCards[this.currentSession - 1]; i++)
		{
			GameObject card = 
				Instantiate (this.card, this.cardPositions [i], Quaternion.identity, this.cardsHolder.transform) 
				as GameObject;

			int instantiatedId = PickRandomUniqueId (cardId);

			if (this.questionList.Count > 0 && cardWithQuestion.Contains(instantiatedId))
			{
				// Initialize card
				int questionIndex = Random.Range (0, this.questionList.Count);
				InitCard (card, instantiatedId, this.questionList [questionIndex]);

				// Remove assigned question and instantiated question card
				this.questionList.RemoveAt (questionIndex);
				cardWithQuestion.Remove (instantiatedId);
			}
			else
			{
				InitCard (card, instantiatedId, null);
			}
		}

		// Resume time
		Time.timeScale = 1;
	}

	//
	// Get a list of card's id that's going to be initialized
	//
	private List<int> GenerateId ()
	{
		// List of possible card id
		List<int> id = Enumerable.Range (0, cardFrontFaces.Count).ToList<int> ();

		// List of card id that's going to be initialized
		List<int> initializedId = new List<int>();

		// Random picks card id that's going to be initialized
		for (int i = 0; i < (sessionMaxCards [currentSession - 1] / 2); i++) 
		{
			int randomId = Random.Range (0, id.Count);
			initializedId.Add (id [randomId]);
			initializedId.Add (id [randomId]);
			id.RemoveAt (randomId);
		}

		return initializedId;
	}

	//
	// Assign values into given card
	//
	private void InitCard (GameObject card, int id, QuestionHolder question) 
	{
		Card initCard = card.GetComponent<Card> ();
		initCard.Id = id;
		initCard.Front = cardFrontFaces [id];
		initCard.Back = cardBackFace;
		initCard.Question = question;
		StartCoroutine (initCard.Preview (this.previewTime));
	}

	//
	// Get a card id from given list
	//
	private int PickRandomUniqueId (List<int> id) 
	{
		int index = Random.Range (0, id.Count);
		int randomId = id [index];
		id.Remove (randomId);

		return randomId;
	}

	//
	// Close all opened cards
	//
	private void CloseAllCards ()
	{
		openedCards [0].GetComponent<Card> ().CloseCard ();
		openedCards [0].GetComponent<Card> ().CloseCard ();
	}

	//
	// Do a card match check and remove them if matches
	//
	public void CardMatching () 
	{
		if(openedCards.Count > 1)
		{
			if(OpenedCardsIsMatch()) 
			{
				RemoveCardPair ();
			}
			else 
			{
				CloseAllCards ();
			}
		}
		if(remainingCardPairs == 0)
		{
			NextSession ();
		}
	}

	//
	// Check whether a pair of card is matching
	//
	private bool OpenedCardsIsMatch () 
	{
		if(openedCards.Count > 1) 
		{
			return openedCards [0].GetComponent<Card> ().Id == openedCards [1].GetComponent<Card> ().Id;
		}

		return false;
	}

	//
	// Remove matching pair of card from game screen
	//
	private void RemoveCardPair ()
	{
		Destroy (openedCards [0]);
		Destroy (openedCards [1]);
		this.remainingCardPairs -= 1;
		openedCards.Clear ();
	}

	//
	// Move onto the next session
	//
	private void NextSession () 
	{
		if (currentSession < sessionMaxCards.Length)
		{
			this.currentSession += 1;
			InitSession ();
		}
		else
		{
			this.Win ();
		}
	}

	//
	// Get a list of card's id that's going to have question on them
	//
	private List<int> RandomQuestionAssign (List<int> id) 
	{
		int[] randomId = new int[id.Count];
		List<int> cardId = new List<int> ();
		id.CopyTo (randomId);
		List<int> ranId = randomId.ToList<int> ();

		for(int i = 0; i < sessionMaxQuestions[currentSession - 1]; i++) 
		{
			int random = ranId [Random.Range (0, ranId.Count)];
			ranId.Remove (random);
			cardId.Add (random);
		}

		return cardId;
	}

	//
	// Deserialize questions from given file
	//
	private void DeserializeQuestions ()
	{
		QuestionList data = JsonUtility.FromJson<QuestionList> (questionData.text);
		questionList = data.questions.ToList<QuestionHolder>();
	}


    public void gotoMap()
    {
        /*
        //Tambah penghargaan
        if (StarScore.control.obtainedStar >= 5)
        {
            PenghargaanController.self.tambahPenghargaan("Jateng");
        }
        */
        CoreGameInterface.instance.exitGame(StarScore.control.obtainedStar);
    }

}
