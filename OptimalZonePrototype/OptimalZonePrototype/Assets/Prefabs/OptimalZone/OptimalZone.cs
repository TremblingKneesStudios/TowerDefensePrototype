using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Serialization;

[System.Serializable]
public struct TowerIncreaseValues
{
	[Range(0,1)]
    public float healthToAdd;
	[Range(0, 1)]
	public float damageToAdd;
	[Range(0, 1)]
	public float rangeToAdd;
	[Range(0, 1)]
	public float attackSpeedToAdd;
}

public class OptimalZone : MonoBehaviour
{
    private     GameObject          tower;
    public      TowerIncreaseValues towerbuffValues;
	public enum BuffType
	{
		health,
		damage,
		range,
		speed,
	};
	public BuffType type;

	void Start()
	{
		MeshRenderer mesh = GetComponent<MeshRenderer>();
		switch (type)
		{
			case BuffType.health:
				mesh.material.color = Color.green;
				break;
			case BuffType.damage:
				mesh.material.color = Color.red;
				break;
			case BuffType.range:
				mesh.material.color = Color.yellow;
				break;
			case BuffType.speed:
				mesh.material.color = Color.blue;
				break;
			default:
				break;
		}
	}

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

		switch (type)
		{
			case BuffType.health:
			//	tower.GetComponent<TowerStats>().maxHealth *= (1 + towerbuffValues.healthToAdd); 
				break;
			case BuffType.damage:
			//	tower.GetComponent<TowerStats>().damage *= (1 + towerbuffValues.damageToAdd);
				break;
			case BuffType.range:
			//	tower.GetComponent<TowerStats>().range *= (1 + towerbuffValues.rangeToAdd);
				break;
			case BuffType.speed:
			//	tower.GetComponent<TowerStats>().speed *= (1 + towerbuffValues.attackSpeedToAdd);
				break;
			default:
				Debug.Log("no tower");
				break;
		}
	}
}
