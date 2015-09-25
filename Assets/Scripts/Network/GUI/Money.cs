using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Connect;

public class Money : MonoBehaviour {

	public Text 			coins;
	public Text 			crystals;
	public GameObject 		conObj;
	Connection 				con;
	ParserMoney				parser;
	bool					isdata;
	// Use this for initialization
	void Start () {
		conObj = GameObject.Find ("Con");

		con = conObj.GetComponent<Connection>();
		parser = this.gameObject.AddComponent<ParserMoney>();
		con.Money ();

		coins.text = con.getCoins() + "";
		crystals.text = con.getCrystal() + "";
	}
	
	// Update is called once per frame
	void Update () {
		if (con.getDataOfMoney () != "") {

			isdata = true;

		}
		if (isdata) {

			parser.asset = con.getDataOfMoney ();
			isdata = false;
			con.moneyData = "";
			parser.parse();

		}
		coins.text = parser.coins;
		crystals.text = parser.crystals;

	}
}
