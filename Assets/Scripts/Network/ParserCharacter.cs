using UnityEngine;
using System.Collections; 
using System.Xml; 
using System.Xml.Serialization; 
using System.IO; 
using System.Text; 
using System.Collections.Generic;
using Connect;

public class ParserCharacter : MonoBehaviour {

	public string asset;
	public string name;
	public string id;
	public string img;
	
	
	public Dictionary<string, string> obj;
	public List<Dictionary<string, string>> dialogs= new List<Dictionary<string, string>>();
	private XmlTextReader reader;
	
	private ArrayList _nodeList=new ArrayList();
	private NodeCharacter _node;
	public Connection 				con;
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
		
		
		XmlNodeList dataList = xmlDoc.GetElementsByTagName("character");
		
		foreach (XmlNode item in dataList) {
			int i=0;
			i++;
			XmlNodeList itemContent = item.ChildNodes;
			obj = new Dictionary <string, string>(); // obj объявлен ранее в описании класса
			
			
			_node=new NodeCharacter();
			
			foreach (XmlNode itemItens in itemContent) {
				
				
				if (itemItens.Name == "id") {
					//Debug.Log(itemItens.InnerText);
					obj.Add("id", itemItens.InnerText);
					id = itemItens.InnerText;
					_node.id = itemItens.InnerText;
				}
				
				if (itemItens.Name == "name") {
					//Debug.Log(itemItens.InnerText);
					obj.Add("name", itemItens.InnerText);
					name = itemItens.InnerText;
					_node.name = itemItens.InnerText;
				}
				if (itemItens.Name == "image") {
					//Debug.Log(itemItens.InnerText);
					obj.Add("image", itemItens.InnerText);
					img = itemItens.InnerText;
					//_node.texture = con.getCharacterImage(itemItens.InnerText);
					_node.image = itemItens.InnerText;
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
