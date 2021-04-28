using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
	public static BuildManager instance;

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager");
			return;
		}

		instance = this;
	}

	public GameObject tableRoundPrefab;
	public GameObject sofaPrefab;
	public GameObject fridgePrefab;
	public GameObject counterPrefab;

	private ItemBlueprint itemToBuild;
	private Node selectedNode;

	public NodeUI nodeUI;

	public bool CanBuild { get { return itemToBuild != null; } }
	public bool HasMoney { get { return PlayerStats.Money >= itemToBuild.cost; } }

	public void SelectNode (Node node)
	{
		if (selectedNode == node)
		{
			DeselectNode();
			return;
		}

		selectedNode = node;
		itemToBuild = null;

		nodeUI.SetTarget(node);
	}

	public void DeselectNode()
	{
		selectedNode = null;
		nodeUI.Hide();
	}

	public void SetItemToBuild(ItemBlueprint item)
	{
		itemToBuild = item;
		DeselectNode();
	}

	public ItemBlueprint GetItemToBuild()
	{
		return itemToBuild;
	}
}
