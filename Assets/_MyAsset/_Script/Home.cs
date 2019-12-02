using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    public static int InternetScore = 0;
    public static bool isScoreResetting = false;
    public static bool isRegisterLB = false;


    private string LoginPHP_Url = "https://immersivemedia.ph/Tap2Punch/MK_LoginOnly.php";

	private string RegisterPHP_Url = "https://immersivemedia.ph/Tap2Punch/MK_RegisterOnly.php";
	private bool isRegister = false;
	public bool UpdateData = true;
	protected string MK_RegisterUpdate_UUID = "";
	protected string MK_RegisterUpdate_Name = "";
	protected string MK_RegisterUpdate_Score = "";
	protected string MK_RegisterUpdate_Password = "";



	private GameObject HomeUI,GameController,HighScoreBG,LeaderBoardBG,EnterYourName,Login_Form,Registration_Form;
	private GameObject Button_Login,Button_Registration,Popup_Login_Failed,Popup_Login_Successful,Popup_Registration_Failed,Popup_Registration_Successful;
    private GameObject Button_Login_Hide, Button_Registration_Hide, TipHelp;
    public GameObject NotRegister;
    private Text HighScoreText;
    private InputField InboxInputField;
    private Animator HighScore;


	public static int isRegisterAccount = 0;
	public static string CurrentPupup = "None";
	private InputField L_IF_Email, L_IF_Password,R_IF_Email,R_IF_Password;

    // Start is called before the first frame update
    void Awake(){
        NotRegister = GameObject.Find("NotRegister");
        InboxInputField = GameObject.Find("InboxInputField").GetComponent<InputField>();
		L_IF_Email = GameObject.Find("L_IF_Email").GetComponent<InputField>();
		L_IF_Password = GameObject.Find("L_IF_Password").GetComponent<InputField>();
		R_IF_Email = GameObject.Find("R_IF_Email").GetComponent<InputField>();
		R_IF_Password = GameObject.Find("R_IF_Password").GetComponent<InputField>();

		EnterYourName = GameObject.Find("EnterYourName");

		Login_Form = GameObject.Find("Login_Form");
		Registration_Form = GameObject.Find("Registration_Form");
        TipHelp = GameObject.Find("TipHelp");

        Popup_Login_Failed = GameObject.Find("Popup_Login_Failed");
		Popup_Login_Successful = GameObject.Find("Popup_Login_Successful");
		Popup_Registration_Failed = GameObject.Find("Popup_Registration_Failed");
		Popup_Registration_Successful = GameObject.Find("Popup_Registration_Successful");

		Login_Form.SetActive (false);
		Registration_Form.SetActive (false);

		Popup_Login_Failed.SetActive (false);
		Popup_Login_Successful.SetActive (false);
		Popup_Registration_Failed.SetActive (false);
		Popup_Registration_Successful.SetActive (false);

        

        Button_Login_Hide = GameObject.Find("Button_Login");
        Button_Registration_Hide = GameObject.Find("Button_Registration");



        if (PlayerPrefs.HasKey ("isRegisterAccount") == true) {
			isRegisterAccount = PlayerPrefs.GetInt ("isRegisterAccount");
		} else {
			PlayerPrefs.SetInt ("isRegisterAccount", isRegisterAccount);
			isRegisterAccount = PlayerPrefs.GetInt ("isRegisterAccount");
        }

        if (isRegisterAccount == 1)
        {
            TipHelp.SetActive(false);
        }
        else
        {
            TipHelp.SetActive(true);
        }

    }
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        HomeUI = GameObject.Find("HomeBG");
        HomeUI.SetActive(true);

        GameController = GameObject.Find("GameController");
        GameController.SetActive(false);

        
        HighScore = GameObject.Find("HighScoreBG/HighScore").GetComponent<Animator>();
        HighScoreText = GameObject.Find("TitleText/HighScoreText").GetComponent<Text>();

        HighScoreBG = GameObject.Find("HighScoreBG");
        HighScoreBG.SetActive(false);

        LeaderBoardBG = GameObject.Find("LeaderBoardBG");
       

        //LeaderBoardBG.SetActive(false);
    }

    void Update(){
        // print("InboxInputField: "+InboxInputField.text);
        string Format = string.Format("{0:#,#}", PBagGameContoller.NumberOfPunchesThrownTOTAL);

        if(Format == "" || Format == null){
            Format = "0";
        }

        HighScoreText.text = Format;

		
		if(CurrentPupup == "None"){
			RemovePopup ();
		}
		else if(CurrentPupup == "Popup_Login_Failed"){
			Popup_Login_Failed.SetActive (true);
		}
		else if(CurrentPupup == "Popup_Login_Successful"){
			Popup_Login_Successful.SetActive (true);
		}
		else if(CurrentPupup == "Popup_Registration_Failed"){
			Popup_Registration_Failed.SetActive (true);
		}
		else if(CurrentPupup == "Popup_Registration_Successful"){
			Popup_Registration_Successful.SetActive (true);
		}

        if (isRegisterAccount == 1)
        {
            Button_Login_Hide.SetActive(false);
            Button_Registration_Hide.SetActive(false);
        }

        else if (isRegisterAccount == 0)
        {
            Button_Login_Hide.SetActive(true);
            Button_Registration_Hide.SetActive(true);
        }
    }
    public void TipHelpHide()
    {
        TipHelp.SetActive(false);
    }

	public void RemovePopup(){
		CurrentPupup = "None";
		Popup_Login_Failed.SetActive (false);
		Popup_Login_Successful.SetActive (false);
		Popup_Registration_Failed.SetActive (false);
		Popup_Registration_Successful.SetActive (false);

        if (isRegisterAccount == 1)
        {
            Registration_Form.SetActive(false);
            Login_Form.SetActive(false);

        }


    }

    // Update is called once per frame
    public void HomeShow()
    {
        HomeUI.SetActive(true);
        GameController.SetActive(false);
    }

    public void HomeHide()
    {
        HomeUI.SetActive(false);
        GameController.SetActive(true);
    }

    public void HighScoreShow()
    {
        HighScore.SetBool ("Show", true);
        HighScore.SetBool ("Hide", false);
        HighScoreBG.SetActive(true);
    }

    public void HighScoreHide()
    {
        HighScore.SetBool ("Show", false);
        HighScore.SetBool ("Hide", true);
        StartCoroutine(HideHighScore());
    }

   

     IEnumerator HideHighScore()
    {
        
        yield return new WaitForSeconds(.8f);
        HighScoreBG.SetActive(false);
    }

    public void SaveName(){
        
        PlayerPrefs.SetString("SavePlayerName", InboxInputField.text);
        print("SavePlayerName.text: "+InboxInputField.text);
    }



    public void SuccessfulEverthing()
    {
        Login_Hide();
        Registration_Hide();
    }

	public void Submit_Login(){
        //CurrentPupup = "Popup_Login_Successful";
        if (isRegister)
            return;

        MK_RegisterUpdate_UUID = L_IF_Email.text;
        MK_RegisterUpdate_Password = L_IF_Password.text;
        //print("Data file 1");
        if (MK_RegisterUpdate_UUID != string.Empty && MK_RegisterUpdate_Password != string.Empty)
        {
            //print("Data 1234");
            StartCoroutine(LoginProcessOnly());
        }
    }

    IEnumerator LoginProcessOnly()
    {
        if (isRegister)
            yield return null;


        //print("Data");
        isRegister = true;

        //Used for security check for authorization to modify database

        //Assigns the data we want to save
        //Where -> Form.AddField("name" = matching name of value in SQL database
        WWWForm mForm = new WWWForm();
        //print("MK_RegisterUpdate_UUID> "+ MK_RegisterUpdate_UUID);
        //print("MK_RegisterUpdate_Password> " + MK_RegisterUpdate_Password);
        mForm.AddField("MK_RegisterUpdate_UUID", MK_RegisterUpdate_UUID); // adds the player name to the form
        mForm.AddField("MK_RegisterUpdate_Password", MK_RegisterUpdate_Password); // adds the player password to the form

        //Creates instance of WWW to runs the PHP script to save data to mySQL database
        WWW www = new WWW(LoginPHP_Url, mForm);
        Debug.Log("Processing...");
        yield return www;

        Debug.Log("" + www.text);
        string[] splitArray = www.text.Split(char.Parse("-"));
        string isDone = splitArray[0];
        if (isDone == "Done")
        {
            print("ScoreData: "+ splitArray[1]);
            InternetScore = int.Parse(splitArray[1]);
            isScoreResetting = true;
            isRegisterAccount = 1;
            PlayerPrefs.SetInt("isRegisterAccount", isRegisterAccount);
            isRegisterAccount = PlayerPrefs.GetInt("isRegisterAccount");

            PlayerPrefs.SetString("EmailAccount", MK_RegisterUpdate_UUID);
            CurrentPupup = "Popup_Login_Successful";
            Debug.Log("Popup_Login_Successful");
            // print("DataLoop");
        }
        else
        {
            CurrentPupup = "Popup_Login_Failed";
            Debug.Log("Popup_Login_Failed");
            Debug.Log(www.text);

        }
        isRegister = false;
        UpdateData = true;
    }

    public void Submit_Registration(){
//		CurrentPupup = "Popup_Registration_Successful";

		if (isRegister)
			return;
		
		MK_RegisterUpdate_UUID = R_IF_Email.text;
		MK_RegisterUpdate_Password = R_IF_Password.text;
		print ("Data file 1");
		if (MK_RegisterUpdate_UUID != string.Empty && MK_RegisterUpdate_Password != string.Empty)
		{
			print ("Data 1234");
			StartCoroutine(RegisterProcessOnly());
		}
	}


	IEnumerator RegisterProcessOnly()
	{
		if (isRegister)
			yield return null;


		print ("Data");
		isRegister = true;

		//Used for security check for authorization to modify database

		//Assigns the data we want to save
		//Where -> Form.AddField("name" = matching name of value in SQL database
		WWWForm mForm = new WWWForm();
		mForm.AddField("MK_RegisterUpdate_UUID", MK_RegisterUpdate_UUID); // adds the player name to the form
		mForm.AddField("MK_RegisterUpdate_Password", MK_RegisterUpdate_Password); // adds the player password to the form

		//Creates instance of WWW to runs the PHP script to save data to mySQL database
		WWW www = new WWW(RegisterPHP_Url, mForm);
		Debug.Log("Processing...");
		yield return www;

		Debug.Log("" + www.text);
		if (www.text == "Done")
		{
            isRegisterAccount = 1;
            PlayerPrefs.SetInt("isRegisterAccount", isRegisterAccount);
            isRegisterAccount = PlayerPrefs.GetInt("isRegisterAccount");

            PlayerPrefs.SetString ("EmailAccount",MK_RegisterUpdate_UUID);
			CurrentPupup = "Popup_Registration_Successful";
			Debug.Log("Registered Successfully.");
			// print("DataLoop");
		}
		else
		{
			CurrentPupup = "Popup_Registration_Failed";
			Debug.Log(www.text);

		}
		isRegister = false;
		UpdateData = true;
	}


    public void Registration_Hide()
    {
        if (isRegisterLB == true)
        {
            Registration_Form.SetActive(false);
            HomeUI.SetActive(false);
        }
        else
        {
            Registration_Form.SetActive(false);
        }
        isRegisterLB = false;
    }

    public void Registration_Show()
    {
        Registration_Form.SetActive(true);
    }

    public void Login_Hide()
    {
        
        if (isRegisterLB == true)
        {
            Login_Form.SetActive(false);
            HomeUI.SetActive(false);
        }
        else
        {
            Login_Form.SetActive(false);
        }
        isRegisterLB = false;
    }

    public void Login_Show()
    {
        Login_Form.SetActive(true);
    }


    //
    //public void LB_Registration_Show()
    //{
    //    Registration_Form.SetActive(true);
    //    HomeUI.SetActive(false);
    //}

    //public void LB_Login_Show()
    //{
    //    Login_Form.SetActive(true);
    //    HomeUI.SetActive(false);
    //}

    public void LB_HomeUI_Show()
    {
        isRegisterLB = true;
        HomeUI.SetActive(true);
        NotRegister.SetActive(false);
    }


    public void LB_NotRegister_Show()
    {
        isRegisterLB = true;
        NotRegister.SetActive(true);
    }

    public void LB_NotRegister_Close()
    {
        NotRegister.SetActive(false);
    }

    public void SuccessfulLogin()
    {
        if (isRegisterLB == true)
        {
            Login_Form.SetActive(false);
            HomeUI.SetActive(false);
            isRegisterLB = false;
        }
    }


}
