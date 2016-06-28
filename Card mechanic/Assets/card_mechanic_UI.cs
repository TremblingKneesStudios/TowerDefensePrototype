using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class card_mechanic_UI : MonoBehaviour
{
	#region Vars
	public int drawnCards = 5;
	private int maxCards = 5;
	[Range (0, 1)]
	public float cardLerpRate;
	public bool useDim;

	public testTime testTimeScript;
	public GameObject cardPrefab;

	public GameObject dimScreen;
	public Transform returnPos;
	private card[] cards;
	public List<card> activeCards;
    public List<GameObject> deckOfCards;
	public cardpos[] cardPoss;
	#endregion
	#region Stock
	void Awake()
	{
		testTimeScript = GetComponent<testTime>();
		cardPoss = GetComponentsInChildren<cardpos>();
        drawCards();
		cards = GetComponentsInChildren<card>();
		for (int i = 0; i < cards.Length; i++)
		{
			activeCards.Add(cards[i]);
		}

	}
	void Start()
	{
		
	}
	void Update()
	{
		if (useDim)
		{
			dimScreen.SetActive(true);
		}
		else
		{
			dimScreen.SetActive(false);
		}
		moveCards(useDim);
		returnCards(!useDim);
	}
	#endregion
	#region Custom
	public void moveCards(bool _use)
	{
		if (_use)
		{
			StartCoroutine("waitTime", 1f);
			Vector3 carD;
			Vector3 currentDest;
			Vector3 nextDest;

			
			if(drawnCards < maxCards
			&& drawnCards > 1
			&& drawnCards % 2 == 1)
			{
				/*dumb :(*/
			//	Debug.Log("odd card num");
				for (int i = 0; i < drawnCards; i++)
				{
					carD = activeCards[i].transform.position;
					currentDest = cardPoss[i].transform.position;
					nextDest = cardPoss[i + 1].transform.position;

					if (carD != nextDest)
					{
						activeCards[i].transform.position = Vector3.LerpUnclamped(carD, nextDest, cardLerpRate);
						Debug.Log("cardpos " + i + " = " + carD.x + "  dest " + i + " = " + nextDest.x);
					//	Debug.Log("dest " + i + " = " + nextDest.x);
					}
					else
					{
						Debug.Log("reched destination");
					}
				}
			}
			if (drawnCards % 2 == 0)
			{
				/*sorted*/
				Debug.Log("even card num");
				for (int i = 0; i < drawnCards; i++)
				{
					carD = activeCards[i].transform.position;
					currentDest = cardPoss[i].transform.position;
					nextDest = cardPoss[i + 1].transform.position;
					Vector3 mid = new Vector3((currentDest.x + nextDest.x)/2, currentDest.y, 0);

					if (carD != mid)
					{
						activeCards[i].transform.position = Vector3.Lerp(carD, mid, cardLerpRate);
					}
				}				
			}
			if (drawnCards == 1)
			{
				Debug.Log("1 card left");
				for (int i = 0; i < drawnCards; i++)
				{
					carD = activeCards[i].transform.position;
					Vector3 centre = cardPoss[2].transform.position;

					if (carD != centre)
					{
						activeCards[i].transform.position = Vector3.Lerp(carD, centre, cardLerpRate);
					}
				}
			}
			else
			{
				/*sorted*/
				for (int i = 0; i < drawnCards; i++)
				{
					carD = activeCards[i].transform.position;
					currentDest = cardPoss[i].transform.position;
				//	nextDest = cardPoss[i + 1].transform.position;

					if (activeCards[i].transform.position != currentDest)
					{
						activeCards[i].transform.position = Vector3.Lerp(carD, currentDest, cardLerpRate);
					}
				}
			}
		}
	}

	public void returnCards(bool _use)
	{
		if (_use)
		{
			StartCoroutine("waitTime", 1f);
			/**/
			for (int i = 0; i < drawnCards; i++)
			{
				if(activeCards[i].transform.position != returnPos.position)
				{
					activeCards[i].transform.position = Vector3.Lerp(activeCards[i].transform.position, returnPos.position, cardLerpRate);
				}
			}
		}
	}

	public void selectCard()
	{
		drawnCards--;
		activeCards.Clear();
		for (int i = 0; i < cards.Length; i++)
		{
			if (cards[i].gameObject.activeInHierarchy)
			{
				activeCards.Add(cards[i]);
			}
		}
		print("using effect of card");
		useDim = false;
	//	testTimeScript.isTimerRunning = true;	
	}

    public void drawCards()
    {
        //Get all cards into a list
        GameObject[] localCards = GameObject.FindGameObjectsWithTag("Card");
        for(int i = 0; i < localCards.Length; i++)
        {
            deckOfCards.Add(localCards[i]);
            deckOfCards[i].SetActive(false);
        }
        //Randomly choose 5 from the list
        for(int j = 0; j < drawnCards ; j++)
        {
            GameObject activeCard = deckOfCards[Random.Range(0, deckOfCards.Count )];  
            activeCard.SetActive(true);
            deckOfCards.Remove(activeCard);
        }
        //Instantiate them and make them children of the canvas 'Card System'
    }

	public IEnumerator waitTime(float _time)
	{
		yield return new WaitForSeconds(_time);
		StopCoroutine("waitTime");
	}
	#endregion
}
