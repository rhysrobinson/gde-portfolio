using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
	public ItemBlueprint tableRound;
	public ItemBlueprint sofa;
	public ItemBlueprint fridge;
	public ItemBlueprint counter;

	BuildManager buildManager;

	void Start()
	{
		buildManager = BuildManager.instance;
	}

	public void TableRound()
	{
		buildManager.SetItemToBuild(tableRound);
	}

	public void Sofa()
	{
		buildManager.SetItemToBuild(sofa);
	}

	public void Fridge()
	{
		buildManager.SetItemToBuild(fridge);
	}

	public void Counter()
	{
		buildManager.SetItemToBuild(counter);
	}
}
