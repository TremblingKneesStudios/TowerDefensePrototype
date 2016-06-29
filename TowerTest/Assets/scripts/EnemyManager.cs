using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
    public float health = 100f;
    private float power = 20f;
    private bool canAtt;
    private float delay = 1f;
    private float range = 0.5f;
	public NavMeshAgent myAgent;
	// Use this for initialization
	void Start () {
		myAgent = gameObject.GetComponent<NavMeshAgent>();
		myAgent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0) {
            Destroy(gameObject);
        }
		Attacking();
	}
    void Attacking() {
        GameObject[] towers;
        GameObject player;
        float dist;
        float playerDist;
        if (canAtt) {
            towers = GameObject.FindGameObjectsWithTag("Towers");
            player = GameObject.FindGameObjectWithTag("Player");
            for (int i = 0; i < towers.Length; i++) {
                dist = Vector3.Distance(gameObject.transform.position, towers[i].transform.position);
                playerDist = Vector3.Distance(gameObject.transform.position, player.transform.position);
                if (dist <= range || playerDist <= range) {
                    if (dist <= range) {
                        towers[i].GetComponent<TowerManager>().curHealth -= power;
                        if (towers[i].GetComponent<TowerManager>().curHealth > 0) {
                            i--;
                        }else if (playerDist <= range) {
                            //player.GetComponent<HeroStats>().health -= power;
                        }
                    }
                }
            }
            StartCoroutine(AttCooldown(canAtt));
        }
    }
    IEnumerator AttCooldown(bool canAtt) {
        canAtt = false;
        yield return new WaitForSeconds(delay);
        canAtt = true;
        StopCoroutine("AttCooldown");
    }
}
