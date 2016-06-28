using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TowerManager : MonoBehaviour {
    public float curHealth = 20f;
    private float maxHealth = 20f;
    private float power;
    public float range;
    public float delay;

    private float upgradeCost;
    public float increaseAmount = 1.2f;
    public enum towerType {
        healing,
        directDamage,
        generator,
        aoe,
        obelisk
    };
    public towerType types;
    public bool run;
    private bool setHealth;
    public bool canUpgrade;
    private PlayerResources playerScript;

    public GameObject upgradeBttn;//fix later
    //private Vector3 uiPosition;

    void Start () {
        checkType();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerResources>();
        upgradeBttn.SetActive(false);//fix later
        setHealth = false;
        settingValues();
	}
	void Update () {
        checkResources();
        if (canUpgrade) {
            upgradeBttn.SetActive(true);//fix later
        } else {
            upgradeBttn.SetActive(false);//fix later
        }
        if (curHealth > maxHealth) {
            curHealth = maxHealth;
        }
        if (curHealth <= 0) {
            Destroy(gameObject);
        }
    }
    public void checkResources() {
        if (types == towerType.healing && playerScript.elixir >= upgradeCost) {
            canUpgrade = true;
        } else if (types == towerType.healing && playerScript.elixir <= upgradeCost) {
            canUpgrade = false;
        }
        if (types == towerType.directDamage && playerScript.ironOre >= upgradeCost) {
            canUpgrade = true;
        } else if (types == towerType.directDamage && playerScript.ironOre <= upgradeCost) {
            canUpgrade = false;
        }
        if (types == towerType.generator && playerScript.crystal >= upgradeCost) {
            canUpgrade = true;
        } else if (types == towerType.generator && playerScript.crystal <= upgradeCost) {
            canUpgrade = false;
        }
        if (types == towerType.aoe && playerScript.essence >= upgradeCost) {
            canUpgrade = true;
        } else if (types == towerType.aoe && playerScript.essence <= upgradeCost) {
            canUpgrade = false;
        }
        if (types == towerType.obelisk && playerScript.elixir >= upgradeCost && playerScript.ironOre >= upgradeCost && playerScript.crystal >= upgradeCost && playerScript.essence >= upgradeCost) {
            canUpgrade = true;
        } else if (types == towerType.obelisk && playerScript.elixir <= upgradeCost && playerScript.ironOre <= upgradeCost && playerScript.crystal <= upgradeCost && playerScript.essence <= upgradeCost) {
            canUpgrade = false;
        }
    }
    #region towers
    void settingValues() {
        if (types == towerType.healing) {
            HealingTower();
        }
        if (types == towerType.directDamage) {
            DirectDamageTower();
        }
        if (types == towerType.generator) {
            GeneratorTower();
        }
        if (types == towerType.aoe) {
            AOETower();
        }
        if (types == towerType.obelisk) {
            ObeliskTower();
        }
    }

    public void HealingTower() {
        if (!setHealth) {
            maxHealth = 20f;
            curHealth = maxHealth;
            range = 4f;
            delay = 1f;
            upgradeCost = 100f;
            setHealth = true;
        }
        power = 0f;
    }
    public void DirectDamageTower() {
        if (!setHealth) {
            maxHealth = 40f;
            curHealth = maxHealth;
            power = 90f;
            range = 4f;
            delay = 1.5f;
            upgradeCost = 100f;
            setHealth = true;
        }
    }
    public void GeneratorTower() {
        if (!setHealth) {
            maxHealth = 20f;
            curHealth = maxHealth;
            range = 4f;
            upgradeCost = 100f;
            setHealth = true;
        }
        power = 0f;
    }
    public void AOETower() {
        if (!setHealth) {
            maxHealth = 45f;
            curHealth = maxHealth;
            power = 35f;
            range = 4f;
            delay = 2f;
            upgradeCost = 100f;
            setHealth = true;
        }
    }
    public void ObeliskTower() {
        if (!setHealth) {
            maxHealth = 250f;
            curHealth = maxHealth;
            upgradeCost = 25f;
            setHealth = true;
        }
        power = 0f;
    }
    #endregion
    public void upgrade() {
        minusResources();
        maxHealth *= increaseAmount;
        maxHealth = Mathf.RoundToInt(maxHealth);
        curHealth *= increaseAmount;
        curHealth = Mathf.Round(curHealth);
        power *= increaseAmount;
        power = Mathf.Round(power);
        upgradeCost *= increaseAmount;
        upgradeCost = Mathf.Round(upgradeCost);

        Debug.Log(maxHealth);
        Debug.Log(curHealth);
        Debug.Log(power);
        Debug.Log(upgradeCost);

        canUpgrade = false;
    }
    void checkType() {
        if (gameObject.name == "HealingTower") {
            types = towerType.healing;
            //uiPosition = new Vector3(0, 0, 0);
            //upgradeBttn.transform.position = uiPosition;
        }
        if (gameObject.name == "DirectDamageTower") {
            types = towerType.directDamage;
            //uiPosition = new Vector3(0, 2.5f, 0);
            //upgradeBttn.transform.position = uiPosition;
        }
        if (gameObject.name == "GeneratorTower") {
            types = towerType.generator;
            //uiPosition = new Vector3(0, 4.5f, 0);
            //upgradeBttn.transform.position = uiPosition;
        }
        if (gameObject.name == "AOETower") {
            types = towerType.aoe;
            //uiPosition = new Vector3(0, 4.4f, 0);
            //upgradeBttn.transform.position = uiPosition;
        }
        if (gameObject.name == "ObeliskTower") {
            types = towerType.obelisk;
            //uiPosition = new Vector3(0, 3.7f, 0);
            //upgradeBttn.transform.position = uiPosition;
        }
    }
    void minusResources() {
        if (types == towerType.healing) {
            playerScript.elixir -= upgradeCost;
        }
        if (types == towerType.directDamage) {
            playerScript.ironOre -= upgradeCost;
        }
        if (types == towerType.generator) {
            playerScript.crystal -= upgradeCost;
        }
        if (types == towerType.aoe) {
            playerScript.essence -= upgradeCost;
        }
        if (types == towerType.obelisk) {
            playerScript.elixir -= upgradeCost;
            playerScript.ironOre -= upgradeCost;
            playerScript.crystal -= upgradeCost;
            playerScript.essence -= upgradeCost;

        }
    }
    void AOETowerFunction() {
        GameObject[] enimes;
        bool canAtt = true;
        float dist;
        if (canAtt) {
            enimes = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enimes.Length; i++) {
                dist = Vector3.Distance(gameObject.transform.position, enimes[i].transform.position);
                if (dist <= range) {
                    enimes[i].GetComponent<EnemyManager>().health -= power;
                }
                StartCoroutine(AOECooldown(canAtt));
            }
        }
    }
    void DDTowerFunction() {
        GameObject[] enimes;
        bool canAtt = true;
        float dist;
        if (canAtt) {
            enimes = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enimes.Length; i++) {
                dist = Vector3.Distance(gameObject.transform.position, enimes[i].transform.position);
                if (dist <= range) {
                    enimes[i].GetComponent<EnemyManager>().health -= power;
                    if (enimes[i].GetComponent<EnemyManager>().health > 0) {
                        i--;
                    }
                }
            }
            StartCoroutine(AOECooldown(canAtt));
        }
    }
    void HealingTowerFunction() {
        GameObject[] towers;
        List<GameObject> beingHealed = new List<GameObject>();
        bool canHeal = true;
        float dist;
        if (canHeal) {
            towers = GameObject.FindGameObjectsWithTag("Towers");
            for (int i = 0; i < towers.Length; i++) {
                dist = Vector3.Distance(gameObject.transform.position, towers[i].transform.position);
                if (dist <= range) {
                    beingHealed.Add(towers[i]);
                }
            }
            for (int u = 0; u < beingHealed.Count; u++) {
                beingHealed[u].GetComponent<TowerManager>().curHealth += 160f;
            }
            StartCoroutine(HealCooldown(canHeal));
        }
    }
    void GeneratorFunction() {
        GameObject[] towers;
        List<GameObject> beingPowered = new List<GameObject>();
        float dist;
        towers = GameObject.FindGameObjectsWithTag("Towers");
        for (int i = 0; i < towers.Length; i++) {
            dist = Vector3.Distance(gameObject.transform.position, towers[i].transform.position);
            if (dist <= range) {
                beingPowered.Add(towers[i]);
            }
        }
        for (int u = 0; u < beingPowered.Count; u++) {
            beingPowered[u].GetComponent<TowerManager>().run = true;
        }
    }
    IEnumerator AOECooldown(bool CA) {
        CA = false;
        yield return new WaitForSeconds(delay);
        CA = true;
        StopCoroutine("AOECooldown");
    }
    IEnumerator DDCooldown(bool CA) {
        CA = false;
        yield return new WaitForSeconds(delay);
        CA = true;
        StopCoroutine("DDCooldown");
    }
    IEnumerator HealCooldown(bool CH) {
        CH = false;
        yield return new WaitForSeconds(delay);
        CH = true;
        StopCoroutine("HealCooldown");
    }
}
