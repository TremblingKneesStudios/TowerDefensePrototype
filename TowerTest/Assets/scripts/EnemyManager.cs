using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
    public float health = 100f;
    private float power = 20f;
    private bool canAtt;
    private float delay = 1f;
    private float range = 0.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0) {
            Destroy(gameObject);
        }
	}
    void Attacking() {
        GameObject[] towers;
        float dist;
        if (canAtt) {
            towers = GameObject.FindGameObjectsWithTag("Towers");
            for (int i = 0; i < towers.Length; i++) {
                dist = Vector3.Distance(gameObject.transform.position, towers[i].transform.position);
                if (dist <= range) {
                    towers[i].GetComponent<TowerManager>().curHealth -= power;
                    if (towers[i].GetComponent<TowerManager>().curHealth > 0) {
                        i--;
                    }
                }
            }
            StartCoroutine(AttCooldown(canAtt));
        }
    }
    IEnumerator AttCooldown(bool CA) {
        CA = false;
        yield return new WaitForSeconds(delay);
        CA = true;
        StopCoroutine("AttCooldown");
    }
}
