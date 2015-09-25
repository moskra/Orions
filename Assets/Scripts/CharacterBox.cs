using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Connect;
public class CharacterBox : MonoBehaviour {
	public Text 			name;
	public RawImage 		image;
	public string 			address;
	public GameObject		path;
	public string			id;
	public Connection		con;
	public Texture2D		texture; 
	private bool 			isAvailable = true;
	public bool				isClicked = false;
	private GameObject		selectedBox;
	// Use this for initialization
	void Start () {
		//con.isLoad = true;
		//if(con != null)
			texture = con.getCharacterImage (address);
		path = GameObject.FindGameObjectWithTag ("ChoosePanel");
	}
	
	// Update is called once per frame
	void Update () {
		if ((con.isLoad) && (isAvailable)) {
			image.texture = con.getCharacterImage (address);
			if (con.isLoad) {
				isAvailable = false;
				con.isLoad = false;
			}	
		}

	}
	public void OnMouseClick() 
	{
		Debug.Log ("clicked");
		path.SetActive (false);


	}
	public void setConnection(Connection _con) {
		con = _con;
		if (con != null) {
			texture = con.getCharacterImage (address);
			Debug.Log("Sets Con");
		}
	}
	public void setId(string _id) {
		id = _id;
	}

}
