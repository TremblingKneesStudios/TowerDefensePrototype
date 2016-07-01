using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class card : MonoBehaviour
{
    public NewCardScript cardManager;
    public CardEffectHolder cardEffect;

    public enum positiveEffects
    {
        championMoveSpeed,
        championHealth,
        towerHealth,
        towerRange,
        towerAttackSpeed,
        towerDamage,
        enemyHealth,
        enemyMoveSpeed,
        enemyAttackSpeed,
        enemyDamage
    }
    public enum negativeEffects
    {
        championMoveSpeed,
        championHealth,
        towerHealth,
        towerRange,
        towerAttackSpeed,
        towerDamage,
        enemyHealth,
        enemyMoveSpeed,
        enemyAttackSpeed,
        enemyDamage
    }

    public positiveEffects posEffect;
    public negativeEffects negEffect;

    public float posEffectAmount = 0.0f;
    public float negEffectAmount = 0.0f;

    void Update()
    {
        cardManager = GameObject.FindGameObjectWithTag("CardSystem").GetComponent<NewCardScript>();
        cardEffect = GameObject.FindGameObjectWithTag("CardSystem").GetComponent<CardEffectHolder>();
    }

    //Remove card from player's hand
    //Set this gameobject to be false
    //Make cardManager disappear
    public void SelectThisCard()
	{
        if(cardManager.isActive)
        {
            cardManager.myDeck.Remove(this.gameObject);
            this.gameObject.SetActive(false);
            cardManager.isActive = false;

            cardEffect.posEff = posEffect;
            cardEffect.negEff = negEffect;

            cardEffect.posAmount = posEffectAmount;
            cardEffect.negAmount = negEffectAmount;
        }
	}
}
