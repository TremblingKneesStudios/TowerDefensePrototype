using UnityEngine;
using System.Collections;

public class CardEffectHolder : MonoBehaviour {

    public NewCardScript cardHolder;

    public card.positiveEffects posEff;
    public card.negativeEffects negEff;

    public float posAmount = 0.0f;
    public float negAmount = 0.0f;

    #region BaseVariables
    float baseTowerHTH;
    #endregion

    void Start () {
        cardHolder = gameObject.GetComponent<NewCardScript>();
	}
	
	void Update () {
        ApplyEffects();
	}

    void ResetValues()
    {
        //Player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<HeroStats>().moveSpeed = player.GetComponent<HeroStats>().baseMoveSpeed;
        player.GetComponent<HeroStats>().health = player.GetComponent<HeroStats>().baseHealth;
        //Towers

        //Enemies
    }

    public void ApplyEffects()
    {
        ResetValues();
            #region apply positive effects
            switch (posEff)
            {
                case card.positiveEffects.championMoveSpeed:
                    GameObject player = GameObject.FindGameObjectWithTag("Player");
                    float playerMS = player.GetComponent<HeroStats>().moveSpeed;
                    float playerMSBase = player.GetComponent<HeroStats>().baseMoveSpeed;
                    player.GetComponent<HeroStats>().moveSpeed = playerMSBase + (playerMSBase / posAmount);
                    break;

                case card.positiveEffects.championHealth:
                    player = GameObject.FindGameObjectWithTag("Player");
                    float playerHth = player.GetComponent<HeroStats>().health;
                    player.GetComponent<HeroStats>().health = playerHth + (playerHth / posAmount);
                    break;

                case card.positiveEffects.towerHealth:
                GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
                for (int i = 0; i < towers.Length; i++)
                {
                    //*Needs multiple floats for different tower types with different health values
                    //towers[i].GetComponent<TowerManager>().curHealth = baseTowerHTH
                }
                    break;
                case card.positiveEffects.towerRange:
                    break;
                case card.positiveEffects.towerAttackSpeed:
                    break;
                case card.positiveEffects.towerDamage:
                    break;
                case card.positiveEffects.enemyHealth:
                    break;
                case card.positiveEffects.enemyMoveSpeed:
                    break;
                case card.positiveEffects.enemyAttackSpeed:
                    break;
                case card.positiveEffects.enemyDamage:
                    break;
                default:
                    break;
            }
            #endregion

            #region Apply negative effects
            switch (negEff)
            {
                case card.negativeEffects.championMoveSpeed:
                    GameObject player = GameObject.FindGameObjectWithTag("Player");
                    float playerMS = player.GetComponent<HeroStats>().moveSpeed;
                    float playerMSBase = player.GetComponent<HeroStats>().baseMoveSpeed;
                    player.GetComponent<HeroStats>().moveSpeed = playerMSBase - (playerMSBase / posAmount);
                    break;

                case card.negativeEffects.championHealth:
                    player = GameObject.FindGameObjectWithTag("Player");
                    float playerHth = player.GetComponent<HeroStats>().health;
                    player.GetComponent<HeroStats>().health = playerHth - (playerHth / posAmount);
                    break;

                case card.negativeEffects.towerHealth:
                    break;
                case card.negativeEffects.towerRange:
                    break;
                case card.negativeEffects.towerAttackSpeed:
                    break;
                case card.negativeEffects.towerDamage:
                    break;
                case card.negativeEffects.enemyHealth:
                    break;
                case card.negativeEffects.enemyMoveSpeed:
                    break;
                case card.negativeEffects.enemyAttackSpeed:
                    break;
                case card.negativeEffects.enemyDamage:
                    break;
                default:
                    break;
            }
            #endregion
        

    }
}
