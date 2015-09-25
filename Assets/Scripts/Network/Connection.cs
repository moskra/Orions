using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace Connect {

	public class Connection : MonoBehaviour {
		private string level = "";
		private string username = ""; //Переменная для хранения имени
		private string pswd = ""; //Переменная для хранения пароля
		private string email = ""; //Переменная для хранения почтового ящика
		private string login = "http://www.in-box.bl.ee/orions/PHP/connect.php"; //Переменная для хранения адреса
		private string money = "http://www.in-box.bl.ee/orions/PHP/getStorage.php"; //Переменная для хранения адреса
		private string getCharacter = "http://www.in-box.bl.ee/orions/PHP/getCharacters.php"; //Переменная для хранения адреса
		public string address = "http://www.in-box.bl.ee/orions/";
		public bool isAuth = false;
		public bool isLoad = false;
		public Texture2D characterImage;
		WWW connect;
		private string _log;

		public string moneyData = "";
		public string characterData = "";
		//string constr = "Server=localhost;Database=demo;User ID=demo;Password=demo;Pooling=true;CharSet=utf8;"; 
		// соединение 
		//MySqlConnection con = null; 
		// команда к БД
		//MySqlCommand cmd = null; 
		// чтение
		//MySqlDataReader rdr = null; 
		// ошибки
		//MySqlError er = null; 

		// Use this for initialization
		public void setUsrParams(string usr = "test", string pass = "123456")
		{
			username = usr;
			pswd = pass;

		}

		//public getCharacterImage ()
		public void Connect()
		{
			_log = "Loading...";

			WWWForm form = new WWWForm();

			form.AddField("u900151974_login", username);
			form.AddField("u900151974_pass", pswd);

			connect = new WWW(login, form);

			StartCoroutine(WaitForRequest(connect));

		}
		public void Money()
		{
			_log = "Loading...";
			
			WWWForm form = new WWWForm();
			
			form.AddField("u900151974_login", username);
			form.AddField("u900151974_pass", pswd);
			
			connect = new WWW(money, form);
			
			StartCoroutine(WaitForRequestMoney(connect));
			
		}

		public void Character()
		{
			_log = "Loading...";
			
			WWWForm form = new WWWForm();
			
			form.AddField("u900151974_login", username);
			form.AddField("u900151974_pass", pswd);
			
			connect = new WWW(getCharacter, form);
			
			StartCoroutine(WaitForRequestCharacter(connect));
			
		}

		public void authorize (string _level)
		{
			if (isAuth) {
				Application.LoadLevel(_level);
			}
		}

		public Texture2D getCharacterImage (string image)
		{

			StartCoroutine(WaitForRequestCharacterImage(address + image));
			Texture2D temp;
			temp = characterImage;
			Debug.Log (temp);
			characterImage = null;
			//isLoad = false;
			return temp;

			//characterImage = null;
		}

		public int getCoins ()
		{
			if (isAuth) {
				//Application.LoadLevel(_level);
			}
			return 0;
		}

		public int getCrystal ()
		{
			if (isAuth) {
				//Application.LoadLevel(_level);
			}
			return 0;
		}
		public string getDataOfMoney () {
			return moneyData;
		}

		public string getDataOfCharacter () {
			return characterData;
		}
		//Создаём метод OnGUI()
		void OnGUI()
		{

		}

		void Start () {

		}

		void Awake () {
			DontDestroyOnLoad(this);
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		bool parse (WWW www)
		{
			if (www.text == "true") {
				return true;
				_log = "Well done!";
			} 
			if((www.text == "false") || (www.text == ""))
			{
				return false;
				_log = "Incorrect!";
			}
			return false;
		}

		public string log ()
		{
			
			return _log;
		}

		IEnumerator WaitForRequest(WWW www)
		{
			yield return www;

			// check for errors
			if (www.error == null)
			{

				//Debug.Log("WWW Ok!: " + www.text);
				isAuth = parse(www);
				if((www.text == "false") || (www.text == ""))
				{
					_log = "Incorrect!";
				}

			} else {
				//isAuth = parse(www);
				Debug.Log("WWW Error: "+ www.error);
				_log = www.error;
			}    
		}
		IEnumerator WaitForRequestMoney(WWW www)
		{
			yield return www;
			
			// check for errors
			if (www.error == null)
			{
				
				//Debug.Log("WWW Ok!: " + www.text);
				moneyData = www.text;
				_log = "Well done!";
			} else {
				//isAuth = parse(www);
				Debug.Log("WWW Error: "+ www.error);
				_log = www.error;
			}    
		}

		IEnumerator WaitForRequestCharacter(WWW www)
		{
			yield return www;
			
			// check for errors
			if (www.error == null)
			{
				
				//Debug.Log("WWW Ok!: " + www.text);
				characterData = www.text;
				_log = "Well done!";
			} else {
				//isAuth = parse(www);
				Debug.Log("WWW Error: "+ www.error);
				_log = www.error;
			}    
		}

		IEnumerator WaitForRequestCharacterImage(string imageUrl)
		{
			WWW www = new WWW( imageUrl );
			
			yield return www;
			if (www.error == null) {
				Debug.Log("ok");
				Texture2D temp = new Texture2D (www.texture.width, www.texture.height, TextureFormat.DXT1, false);
				www.LoadImageIntoTexture (temp as Texture2D);
				characterImage = temp;
				isLoad = true;
				www.Dispose ();
				www = null;
			}

		}

	}
}
