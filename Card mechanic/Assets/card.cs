using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class card : MonoBehaviour
{
    #region Variables
    public enum positiveEffects
    {   championMoveSpeed,
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

    public positiveEffects posEffEnum;
    public negativeEffects negEffEnum;

    public float posEffectAmount = 0.0f;
    public float negEffectAmount = 0.0f;

    public NewCardScript cardManager;
    #endregion

    void Update()
    {
        ManageEnums();
    }

    void ManageEnums()
    {
        #region PosEnumSwitch
        switch (posEffEnum)
        {
            case positiveEffects.championHealth:
                //apply increase of champion health, based on posEffectAmount
                //Get champion's health value
                //Increase by posEffectAmount, make this a percentage e.g. if posEffectAmount = 15, it increases the champions health by 15%
                break;

            case positiveEffects.championMoveSpeed:
                break;

            case positiveEffects.enemyAttackSpeed:
                //find(detect) all enemies
                //put all enemies into an array
                //loop through array and reduce each enemies' attack speed variable by negEffectAmount
                break;

            case positiveEffects.enemyDamage:
                break;

            case positiveEffects.enemyHealth:
                break;

            case positiveEffects.enemyMoveSpeed:
                break;

            case positiveEffects.towerAttackSpeed:
                //find(detect) all towers
                //put all towers into an array
                //loop through array and increase each tower's attack speed cariable by posEffectAmount
                break;

            case positiveEffects.towerDamage:
                break;

            case positiveEffects.towerHealth:
                break;

            case positiveEffects.towerRange:
                break;
        }
        #endregion
        #region NegEnumSwitch
        switch (negEffEnum)
        {
            case negativeEffects.championHealth:
                //apply increase of champion health, based on posEffectAmount
                break;

            case negativeEffects.championMoveSpeed:
                break;

            case negativeEffects.enemyAttackSpeed:
                break;

            case negativeEffects.enemyDamage:
                break;

            case negativeEffects.enemyHealth:
                break;

            case negativeEffects.enemyMoveSpeed:
                break;

            case negativeEffects.towerAttackSpeed:
                break;

            case negativeEffects.towerDamage:
                break;

            case negativeEffects.towerHealth:
                break;

            case negativeEffects.towerRange:
                break;
        }
        #endregion
    }

    //Remove card from player's hand
    //Set this gameobject to be false
    //Make cardManager disappear
    public void SelectThisCard()
	{
        cardManager.myDeck.Remove(this.gameObject);
		this.gameObject.SetActive(false);
        cardManager.isActive = false;
	}
}
