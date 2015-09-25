using UnityEngine;
using System.Collections; 
using System.Xml; 
using System.Xml.Serialization; 
using System.IO; 
using System.Text; 
using System.Collections.Generic;

public class ParserMoney : MonoBehaviour  {
	//public TextAsset asset;
	public string asset;
	public string coins;
	public string crystals;
	
	
	public Dictionary<string, string> obj;
	public List<Dictionary<string, string>> dialogs= new List<Dictionary<string, string>>();
	private XmlTextReader reader;
	
	private ArrayList _nodeList=new ArrayList();
	private NodeMoney _node;
	// Use this for initialization
	void Start () {

		
	}
	public void parse () {
		//asset = Resources.Load("virus.xml");
		XmlDocument xmlDoc = new XmlDocument();
		if (asset != "") {

			xmlDoc.LoadXml (asset/*.text*/);
			Debug.Log (asset/*.text*/);
		}

		
		XmlNodeList dataList = xmlDoc.GetElementsByTagName("data");
		
		foreach (XmlNode item in dataList) {
			int i=0;
			i++;
			XmlNodeList itemContent = item.ChildNodes;
			obj = new Dictionary <string, string>(); // obj объявлен ранее в описании класса
			
			
			_node=new NodeMoney();
			
			foreach (XmlNode itemItens in itemContent) {
				
				
				if (itemItens.Name == "coins") {
					//Debug.Log(itemItens.InnerText);
					obj.Add("coins", itemItens.InnerText);
					coins = itemItens.InnerText;
					_node.coins = itemItens.InnerText;
				}
				
				if (itemItens.Name == "crystals") {
					//Debug.Log(itemItens.InnerText);
					obj.Add("crystals", itemItens.InnerText);
					crystals = itemItens.InnerText;
					_node.crystals = itemItens.InnerText;
				}
				
			}
			_nodeList.Add(_node);
			dialogs.Add(obj); // dialogs объявлен ранее и имеет тип List<Dictionary<string, string>>
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
	public ArrayList getObjList()
	{
		return _nodeList;
	}
	
	public ArrayList getObjListFromDictionary()
	{
		return null;
	}
	
	
}
