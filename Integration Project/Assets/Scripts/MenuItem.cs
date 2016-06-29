using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuItem : MonoBehaviour {

	public Slider damageSlider;
	public Slider moveSpeedSlider;
	public Slider attackSpeedSlider;
	public Slider healthSlider;
	public Text buttonText;
	public Image mainImage;
	public Image icon;

	private float damage;
	private float moveSpeed;
	private float attackSpeed;
	private float health;
	private string heroName;
	private GameObject heroPrefab;
	private Canvas menuCanvas;
	private Color mainColor; //Temp

	public void SetMenuItem(float damageIn, float moveSpeedIn, float attackSpeedIn, float healthIn, string heroNameIn, 
		Sprite mainSprite, Color mainColorIn, Sprite iconSprite, GameObject heroPrefabIn, Canvas menuCanvasIn)
	{
		damage = damageIn;
		damageSlider.value = damageIn;
		moveSpeed = moveSpeedIn;
		moveSpeedSlider.value = moveSpeedIn;
		attackSpeed = attackSpeedIn;
		attackSpeedSlider.value = attackSpeedIn;
		health = healthIn;
		healthSlider.value = healthIn;
		heroName = heroNameIn;
		buttonText.text = heroNameIn;
		mainImage.sprite = mainSprite;
		mainColor = mainColorIn; //Temp
		mainImage.color = mainColorIn;
		icon.sprite = iconSprite;
		heroPrefab = heroPrefabIn;
		menuCanvas = menuCanvasIn;

		gameObject.name = "MenuItem - " + heroName;
	}

	public void LoadHero()
	{
		GameObject newHero = Instantiate (heroPrefab) as GameObject;

		HeroStats newHeroStats = newHero.GetComponent<HeroStats> ();

		newHeroStats.damage = damage;
		newHeroStats.moveSpeed = moveSpeed;
		newHeroStats.attackSpeed = attackSpeed;
		newHeroStats.health = health;
		newHeroStats.heroName = heroName;

		newHero.name = heroName + " Hero";

		//Temporary just for visualisation
		newHero.GetComponent<MeshRenderer>().material.color = mainColor;

		menuCanvas.enabled = false;
	}
}
