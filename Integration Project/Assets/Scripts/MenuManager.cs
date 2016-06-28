using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour 
{
	[System.Serializable]
	public class MenuItemValues
	{
		public string heroName;
		public float damage;
		public float moveSpeed;
		public float attackSpeed;
		public float health;
		public Sprite menuSprite;
		public Color menuSpriteColor;
		public Sprite menuIconSprite;
		public GameObject heroPrefab;
	}

	public GameObject menuParent;
	public GameObject menuItemPrefab;
	public Canvas menuCanvas;


	public MenuItemValues[] menuItems;

	void Start()
	{
		for (int i = 0; i < menuItems.Length; i++) 
		{
			GameObject newMenuItem = Instantiate (menuItemPrefab) as GameObject;

			newMenuItem.transform.SetParent(menuParent.transform);

			newMenuItem.transform.localScale = Vector3.one;

			MenuItem menuItem = newMenuItem.GetComponent<MenuItem> ();

			menuItem.SetMenuItem (menuItems [i].damage, menuItems [i].moveSpeed, menuItems [i].attackSpeed, menuItems [i].health, menuItems [i].heroName, menuItems [i].menuSprite, menuItems[i].menuSpriteColor, menuItems [i].menuIconSprite, menuItems[i].heroPrefab, menuCanvas);
		}
	}
}
