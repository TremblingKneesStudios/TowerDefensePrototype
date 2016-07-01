using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewCardScript : MonoBehaviour
{
    #region Variables
    public int maxAmount = 5;
    public List<GameObject> masterDeck;
    [HideInInspector]
    public List<GameObject> masterDeckClone;    //aim to get rid mof this, make i redundant
    public List<GameObject> myDeck;
    public bool isActive;
    private float speed = 7.5f;
    #endregion

    // Use this for initialization
    void Start () {
        GatherMasterCards();        
	}
	
	// Update is called once per frame
	void Update () {
	    if(myDeck.Count <= 0)
        {
            ResetMasterDeckCards();
            DealCards();
        }
        MoveCards();
        //for debuggin purposes
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isActive = true;        //put this on the game logic script when it changes wave
        }
	}

    //This function will gather all the cards at the start
    void GatherMasterCards()
    {
        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
        for (int i = 0; i < cards.Length; i++)
        {
            masterDeck.Add(cards[i]);
            masterDeckClone.Add(cards[i]);
            cards[i].SetActive(false);
        }
    }

    //this function gives the players 5 cards
    public void DealCards()
    {
        for (int i = 0; i < maxAmount; i++)
        {
            int cardIndex = Random.Range(0, masterDeck.Count);      //this creates a random index to select and create cards
            myDeck.Add(masterDeck[cardIndex]);
            masterDeck[cardIndex].SetActive(true);
            masterDeck.Remove(masterDeck[cardIndex]);
        }
        
    }

    //this function is to solve so many shit issues!
    void ResetMasterDeckCards()
    {
        masterDeck.Clear();
        for (int i = 0; i < masterDeckClone.Count; i++)
        {
            masterDeck.Add(masterDeckClone[i]);
        }
    }

    //this function is to move the card when activated
    public void MoveCards()
    {
        Vector2 offScreenTarget = new Vector2(0,0 - Screen.height);
        RectTransform myRect = gameObject.GetComponent<RectTransform>();
        if (isActive)
        {
            myRect.anchoredPosition = Vector2.MoveTowards(myRect.anchoredPosition, Vector2.zero, speed);
            //transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, speed);
        }
        else
        {
            myRect.anchoredPosition = Vector2.MoveTowards(myRect.anchoredPosition, offScreenTarget, speed);
        }
    }
}