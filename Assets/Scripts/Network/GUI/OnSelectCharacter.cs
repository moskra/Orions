using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Connect;
using System.Collections.Generic;

public class OnSelectCharacter : MonoBehaviour {

	public GameObject								characterBox
													, characterBoxTemp;
	public GameObject								path;
	public GameObject 								conObj;
	Connection 										con;
	ParserCharacter									parser;
	bool											isdata;
	ArrayList										characters;
	Dictionary<string,string>						imagelink;
	public Dictionary<string,Texture2D>				images;
	int 											i = 0;
	// Use this for initialization
	void Start () {
		conObj = GameObject.Find ("Con");
		
		con = conObj.GetComponent<Connection>();
		parser = this.gameObject.AddComponent<ParserCharacter>();
		con.Character ();
		characters = new ArrayList ();

		//coins.text = con.getCoins() + "";
		//crystals.text = con.getCrystal() + "";
	}
	
	// Update is called once per frame
	void Update () {
		if (con.getDataOfCharacter () != "") {
			
			isdata = true;
			parser.con = con;
			parser.asset = con.getDataOfCharacter ();
			con.characterData = "";
			parser.parse();

		}
		if (isdata) {
			



			imagelink = new Dictionary <string, string>();
			images = new Dictionary <string, Texture2D>();
			foreach (NodeCharacter n in parser.getObjList()) {
				i++;
				if(i <= parser.getObjList().Count)
				{
					characterBox.GetComponent<CharacterBox>().con = con;
					characterBox.GetComponent<CharacterBox>().name.text = n.name;
					characterBox.GetComponent<CharacterBox>().id = n.id;
					characterBox.name = n.name;
					//if (con.getCharacterImage(n.image) != null)
					//{
						//Debug.Log(con.log());
					//characterBox.GetComponent<CharacterBox>().image.texture = n.texture;
					characterBox.GetComponent<CharacterBox>().address = n.image;
					//}
					characterBox.GetComponent<RectTransform>().anchoredPosition = new Vector2(Screen.width/2,((Screen.height/3.3f) + 20)*i);
					characterBoxTemp = (GameObject) GameObject.Instantiate(characterBox);
					characterBoxTemp.transform.SetParent(path.transform);

					//characters.Add(characterBoxTemp);
					//imagelink.Add(n.id, n.image);
					//images[n.id] = con.getCharacterImage (imagelink [n.id]);
					//Debug.Log(images[n.id]);
					
				}
				//characterBoxTemp.transform.OverlayPosition(path.transform);




			}
			isdata = false;

		}

		/*for(int s = 0; s < characters.Count; s++) {
			GameObject n = (GameObject)characters[s];
			if (n.GetComponent<CharacterBox> ().image.texture == null || images [n.GetComponent<CharacterBox> ().id] != "")
			{
				n.GetComponent<CharacterBox> ().image.texture = con.getCharacterImage (images [n.GetComponent<CharacterBox> ().id]);
				Debug.Log(images [n.GetComponent<CharacterBox> ().id]);
			}
			else
			//
			{

				break;
			}
			//if (n.GetComponent<CharacterBox> ().image.texture == null)
		}*/

	}
}
