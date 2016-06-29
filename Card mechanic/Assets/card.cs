using UnityEngine;
using System.Collections;

public class card : MonoBehaviour
{
    public card_mechanic_UI cardSystem;

    public void Start()
    {
        cardSystem = GameObject.FindGameObjectWithTag("CardSystem").GetComponent<card_mechanic_UI>();
    }

    //When this card is clicked, apply the effect changes for this round
    //Add this card back to the deck of cards
    //Deactivate this card
	public void SelectThisCard()
	{
        cardSystem.deckOfCards.Add(this.gameObject);
		this.gameObject.SetActive(false);
	}
}
