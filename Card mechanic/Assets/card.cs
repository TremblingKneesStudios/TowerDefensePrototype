using UnityEngine;
using System.Collections;

public class card : MonoBehaviour
{

    //When this card is clicked, apply the effect changes for this round
    //Deactivate this card
	public void SelectThisCard()
	{
		this.gameObject.SetActive(false);
	}
}
