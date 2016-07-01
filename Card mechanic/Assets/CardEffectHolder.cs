using UnityEngine;
using System.Collections;

public class CardEffectHolder : MonoBehaviour {

    public NewCardScript cardHolder;

    public card.positiveEffects posEff;
    public card.negativeEffects negEff;

    public float posAmount = 0.0f;
    public float negAmount = 0.0f;

    // Use this for initialization
    void Start () {
        cardHolder = gameObject.GetComponent<NewCardScript>();
	}
	
	// Update is called once per frame
	void Update () {
        ApplyEffects();
	}

    void ApplyEffects()
    {
        if (!cardHolder.isActive)
        {
            #region apply positive effects
            switch (posEff)
            {
                case card.positiveEffects.championMoveSpeed:
                    break;
                case card.positiveEffects.championHealth:
                    break;
                case card.positiveEffects.towerHealth:
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

                    break;
                case card.negativeEffects.championHealth:
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
}
