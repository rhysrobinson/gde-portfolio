using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
	public Color hoverColor;
	public Color notEnoughMoneyColor;
	public Vector3 positionOffset;

	[HideInInspector]
	public GameObject item;
	[HideInInspector]
	public ItemBlueprint itemBlueprint;
	[HideInInspector]
	public bool isUpgraded = false;

	private Renderer rend;
	private Color startColor;

	BuildManager buildManager;

	void Start()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;

		buildManager = BuildManager.instance;
	}

	public Vector3 GetBuildPosition()
	{
		return transform.position + positionOffset;
	}

	void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (item != null)
		{
			buildManager.SelectNode(this);
			return;
		}

		if (!buildManager.CanBuild)
			return;

		BuildItem (buildManager.GetItemToBuild());
	}

	void BuildItem (ItemBlueprint blueprint)
	{
		if (PlayerStats.Money < blueprint.cost)
		{
			return;
		}

		PlayerStats.Money -= blueprint.cost;

		GameObject _item = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
		item = _item;

		itemBlueprint = blueprint;
	}

	public void UpgradeItem()
	{
		if (PlayerStats.Money < itemBlueprint.upgradeCost)
		{
			return;
		}

		PlayerStats.Money -= itemBlueprint.upgradeCost;

		Destroy(item);

		GameObject _item = (GameObject)Instantiate(itemBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
		item = _item;

		isUpgraded = true;
	}

	public void SellItem()
	{
		PlayerStats.Money += itemBlueprint.GetSellAmount();

		Destroy(item);
		itemBlueprint = null;
	}

	void OnMouseEnter()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (!buildManager.CanBuild)
			return;

		if (buildManager.HasMoney)
		{
			rend.material.color = hoverColor;
		}
		else
		{
			rend.material.color = notEnoughMoneyColor;
		}
	}

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}
}
