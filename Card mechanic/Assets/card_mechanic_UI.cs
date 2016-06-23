using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class card_mechanic_UI : MonoBehaviour
{
	public int drawnCards = 5;
	[Range (0, 1)]
	public float cardLerpRate;
	public bool useDim;

	public GameObject dimScreen;
	public Transform returnPos;
	public card[] cards;
	public List<card> activeCards;
	public cardpos[] cardPoss; 

	void Awake()
	{
		cardPoss = GetComponentsInChildren<cardpos>();
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

	public void moveCards(bool _use)
	{
		if (_use)
		{
			StartCoroutine("waitTime", 1f);
			if (drawnCards < 5)
			{
				/**/
				for (int i = 0; i < drawnCards; i++)
				{
					activeCards[i].transform.position = Vector3.Lerp(activeCards[i].transform.position, cardPoss[i + 1].transform.position, cardLerpRate);
				}
				/*
				for (int i = 0; i < cards.Length; i++)
				{
					float distance = Vector3.Distance(cards[i].transform.position, cardPoss[i].transform.position) / 100f;
					cards[i].transform.position = Vector3.Lerp(cards[i].transform.position, cardPoss[i + 1].transform.position, distance * cardLerpRate);
				}
				*/
			}
			if (drawnCards == 1)
			{
				for (int i = 0; i < drawnCards; i++)
				{
					activeCards[i].transform.position = Vector3.Lerp(activeCards[i].transform.position, cardPoss[2].transform.position, cardLerpRate);
				}
			}
			else
			{
				/**/
				for (int i = 0; i < drawnCards; i++)
				{
					activeCards[i].transform.position = Vector3.Lerp(activeCards[i].transform.position, cardPoss[i].transform.position, cardLerpRate);
				}
				/*
				for (int i = 0; i < cards.Length; i++)
				{
					float distance = Vector3.Distance(cards[i].transform.position, cardPoss[i].transform.position) / 100f;
					cards[i].transform.position = Vector3.Lerp(cards[i].transform.position, cardPoss[i].transform.position, distance * cardLerpRate);
				}
				*/
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
			/*
			for (int i = 0; i < cards.Length; i++)
			{
				float distance = Vector3.Distance(cards[i].transform.position, cardPoss[i].transform.position) / 100f;
				cards[i].transform.position = Vector3.Lerp(cards[i].transform.position, returnPos.position, distance * cardLerpRate);
			}
			*/
		//	yield return null;
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
		useDim = false;		
	}

	public IEnumerator waitTime(float _time)
	{
		yield return new WaitForSeconds(_time);
		StopCoroutine("waitTime");
	}
}
