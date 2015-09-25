using UnityEngine;
using System.Collections;

public class NodeMoney  {

	public string coins;
	public string crystals;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public int getCoins() {
		return int.Parse(coins);
	}
	public int getCrystals() {
		return int.Parse(crystals);
	}

}
