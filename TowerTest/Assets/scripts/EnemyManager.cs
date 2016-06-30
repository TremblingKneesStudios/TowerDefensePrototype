using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
    public float health = 100f;
    private float power = 20f;
    private bool canAtt;
    private float delay = 1f;
    public float range = 2f;
	private NavMeshAgent myAgent;
    public GameObject target;
    public GameObject[] towers;
	public GameObject player;
	void Start () {
		myAgent = gameObject.GetComponent<NavMeshAgent>();
		//myAgent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
		towers = GameObject.FindGameObjectsWithTag("Towers");
		player = GameObject.FindGameObjectWithTag("Player");
	//	myAgent.SetDestination(target.transform.position);
		canAtt = true;
	}
	
	void Update () {
		if (health <= 0) {
            Destroy(gameObject);
        }
		if (target == null)
		{
			setTarget(player);
		}
		Attacking();
	}
    void Attacking() {
        
        float dist;
        float playerDist;
        if (canAtt) {            
            for (int i = 0; i < towers.Length; i++) {
                dist = Vector3.Distance(gameObject.transform.position, towers[i].transform.position);
                playerDist = Vector3.Distance(gameObject.transform.position, player.transform.position);
                if (dist <= range || playerDist <= range) {
                    if (dist <= range) {
						setTarget(towers[i]);
						if (target == towers[i])
						{
							towers[i].GetComponent<TowerManager>().curHealth -= power;
							StartCoroutine("AttCooldown");
						}
                        if (towers[i].GetComponent<TowerManager>().curHealth > 0) {
                            i--;
                        }
                    } else if (playerDist < range) {
                        setTarget(player);
						//player.GetComponent<HeroStats>().health -= power;
						StartCoroutine("AttCooldown");
					}
                }
            }
            StartCoroutine("AttCooldown");
        }
    }

	void setTarget(GameObject _target)
	{
		target = _target;
		Debug.Log(target);
		myAgent.SetDestination(target.transform.position);

	}
    IEnumerator AttCooldown() {
	//	canAtk = false;
		canAtt = false;
        yield return new WaitForSeconds(delay);
		canAtt = true;
	//	canAtk = true;
        StopCoroutine("AttCooldown");
    }
}
