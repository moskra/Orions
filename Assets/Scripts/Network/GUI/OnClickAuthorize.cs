using UnityEngine;
using System.Collections;
using Connect;
using UnityEngine.UI;
public class OnClickAuthorize : MonoBehaviour {

	Connection 				con;
	public GameObject		conObj;
	public string 			level;
	public InputField 		m_UserInput = null;
	public InputField 		m_PassInput = null;
	public Text				textField = null;				
	// Use this for initialization
	void Awake() {

	}
	void Start () {
		con = conObj.gameObject.AddComponent<Connection>();
	}
	public void authorize()
	{
		if (m_UserInput.text != "" && m_PassInput.text != "") {
			con.setUsrParams (m_UserInput.text, m_PassInput.text);
			con.Connect ();

		}

	}
	
	// Update is called once per frame
	void Update () {
		if (!con.isAuth) {
			textField.text = con.log ();
		}
		if (con.isAuth) {
			//Debug.Log ("df");
			con.authorize (level);
			m_UserInput = null;
			m_PassInput = null;
			textField = null;
		}

	}
}
