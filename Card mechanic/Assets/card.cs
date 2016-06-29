using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class card : MonoBehaviour
{
    public NewCardScript cardManager;


    //When this card is clicked, apply the effect changes for this round
    //Add this card back to the deck of cards
    //Deactivate this card
    public void SelectThisCard()
	{
        cardManager.myDeck.Remove(this.gameObject);
		this.gameObject.SetActive(false);
        cardManager.isActive = false;
	}
}
