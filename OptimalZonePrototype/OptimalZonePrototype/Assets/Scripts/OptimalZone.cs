using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Serialization;

[System.Serializable]
public struct TowerIncreaseValues
{
    public float healthToAdd;
    public float damageToAdd;
    public float movementSpeedToAdd;
    public float attackSpeedToAdd;
}

public class OptimalZone : MonoBehaviour
{
    private     GameObject          tower;
    public      TowerIncreaseValues towerIncreaseValues;

    public void onTowerDrop(GameObject _towerGameObject)
    {
        tower = _towerGameObject;
        checkChildCount();
    }

    public void checkChildCount()
    {
        if (transform.childCount == 0)
        {
            dropTower();
        }

        else
        {
            return;
        }
    }

    public void dropTower()
    {
        tower.transform.position    = new Vector3(  transform.position.x,
                                                    transform.GetComponent<MeshRenderer>().bounds.size.y * 2 + tower.GetComponent<MeshRenderer>().bounds.size.y / 2,
                                                    transform.position.z);
        tower.transform.SetParent(transform);

        switch (gameObject.tag)
        {
            case "HealthIncreaseZone":
                // Get a reference to the tower stats here and update accordingly
                //tower.GetComponent<TowerStats>().health += towerIncreaseValues.healthToAdd;
                break;
            case "DamageIncreaseZone":
                // Get a reference to the tower stats here and update accordingly
                //tower.GetComponent<TowerStats>().damage += towerIncreaseValues.damageToAdd;
                break;
            case "MovementSpeedZone":
                // Get a reference to the tower stats here and update accordingly
                //tower.GetComponent<TowerStats>().movementSpeed += towerIncreaseValues.movementSpeedToAdd;
                break;
            case "AttackSpeedZone":
                // Get a reference to the tower stats here and update accordingly
                //tower.GetComponent<TowerStats>().attackSpeed += towerIncreaseValues.attackSpeedToAdd;
                break;
        }
    }
}
