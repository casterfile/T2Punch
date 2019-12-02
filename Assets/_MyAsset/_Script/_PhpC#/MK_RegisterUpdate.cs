using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Security;
using System.Collections;

public class MK_RegisterUpdate : MonoBehaviour {

	private string SecretKey = "123456";
	private string RegisterPHP_Url = "https://immersivemedia.ph/Tap2Punch/MK_RegisterUpdate.php";

	private string GetPlayerScorePHP_Url = "https://immersivemedia.ph/Tap2Punch/MK_GetPlayerScore.php";
	private bool isget = false;

	protected string MK_RegisterUpdate_UUID = "";
	protected string MK_RegisterUpdate_Name = "";
	protected string MK_RegisterUpdate_Score = "";
    private bool isRegister = false;
	public bool UpdateData = true;

    void SettingOfScore(){
        //      MK_RegisterUpdate_UUID = SystemInfo.deviceUniqueIdentifier;

        if (PlayerPrefs.HasKey("EmailAccount") == true)
        {

            MK_RegisterUpdate_UUID = PlayerPrefs.GetString("EmailAccount");

            if (PlayerPrefs.HasKey("SavePlayerName") == false)
            {
                string myStr = MK_RegisterUpdate_UUID;
                string[] arr = myStr.Split('@');
                string EmailName = arr[0].Trim();
                PlayerPrefs.SetString("SavePlayerName", EmailName);

            }
            
        }

        print("Name: "+ PlayerPrefs.GetString("SavePlayerName"));

        if (PlayerPrefs.HasKey ("SavePlayerName") == true){//"SavePlayerName"
            if (Home.isRegisterAccount == 1){
				
			}
            MK_RegisterUpdate_UUID = PlayerPrefs.GetString("EmailAccount");
            MK_RegisterUpdate_Name = PlayerPrefs.GetString ("SavePlayerName");
			int TempScore = PlayerPrefs.GetInt ("NumberOfPunchesThrown");
			MK_RegisterUpdate_Score = TempScore + "";

			print ("MK_RegisterUpdate_UUID: " + MK_RegisterUpdate_UUID);
			print ("SavePlayerName: " + MK_RegisterUpdate_Name);
			print ("MK_RegisterUpdate_Score: " + MK_RegisterUpdate_Score);
			if (UpdateData == true) {
				UpdateData = false;
                
				Register ();
				//StartCoroutine(GetTop());
			}

		}else if (PlayerPrefs.HasKey ("SavePlayerName") == false) {
			StartCoroutine(GetTop());
		}

		print ("PlayerPrefs.HasKey():"+PlayerPrefs.HasKey("SavePlayerName"));

    }

	void Awake(){
//		PlayerPrefs.DeleteKey ("SavePlayerName");
//		StartCoroutine(GetTop());
	}

	// Use this for initialization
	void Start () {
		SettingOfScore();
	}


	
	// Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(){
        // UpdateData = true;
        SettingOfScore();
    }

    /// <summary>
    /// 
    /// </summary>
    public void Register()
    {
        // print("DataLoop: ");
        if (isRegister)
            return;
         
		if (MK_RegisterUpdate_UUID != string.Empty && MK_RegisterUpdate_Name != string.Empty && MK_RegisterUpdate_Score != string.Empty)
        {
            
			StartCoroutine(RegisterProcess());
        }
    }

    IEnumerator RegisterProcess()
    {
        if (isRegister)
            yield return null;

        isRegister = true;
      
        //Used for security check for authorization to modify database

        //Assigns the data we want to save
        //Where -> Form.AddField("name" = matching name of value in SQL database
        WWWForm mForm = new WWWForm();
		mForm.AddField("MK_RegisterUpdate_UUID", MK_RegisterUpdate_UUID); // adds the player name to the form
		mForm.AddField("MK_RegisterUpdate_Name", MK_RegisterUpdate_Name); // adds the player password to the form
		mForm.AddField("MK_RegisterUpdate_Score", MK_RegisterUpdate_Score); // adds the kill total to the form

        //Creates instance of WWW to runs the PHP script to save data to mySQL database
        WWW www = new WWW(RegisterPHP_Url, mForm);
        Debug.Log("Processing...");
        yield return www;
          
        Debug.Log("" + www.text);
        if (www.text == "Done")
        {
            Debug.Log("Registered Successfully.");
            // print("DataLoop");
        }
        else
        {
            Debug.Log(www.text);

        }
        isRegister = false;
        UpdateData = true;
    }


	IEnumerator GetTop()
	{
		int count = 1;

		if (isget)//if alredy load info
			yield return null;

		isget = true;//notify is load now

		WWWForm mForm = new WWWForm();
		mForm.AddField("MK_RegisterUpdate_UUID", MK_RegisterUpdate_UUID); // adds the player name to the form

		WWW www = new WWW(GetPlayerScorePHP_Url, mForm);
		yield return www;//wait for response

		print("execution");
		if (www.error != null)
		{
			print("There was an error getting the high score: " + www.error);
		}
		else
		{

			//get info from data base
			string result = www.text;
			//get and separate users
			string[] splituser = result.Split("\n"[0]);

			int numbers = 0;
			bool mtype = false;

			foreach (string u in splituser)
			{
				numbers++;
				mtype = !mtype;
				//get separate info user
				string[] splitinfo = u.Split("-"[0]);

				if (u != string.Empty && u != null)
				{
					string Data1 = numbers + "";
					string Data2 = splitinfo[0];
					string Data3 = splitinfo [1];
//					PlayerPrefs.SetString ("ScoreListName"+count, Data2);
//					PlayerPrefs.SetString ("ScoreListScore"+count, Data3);

					PlayerPrefs.SetString ("SavePlayerName",Data2);
					MK_RegisterUpdate_Name = PlayerPrefs.GetString ("SavePlayerName");
					int TempData3 = int.Parse (Data3);
					PlayerPrefs.SetInt ("NumberOfPunchesThrownTOTAL",TempData3);
					int TempScore = PlayerPrefs.GetInt ("NumberOfPunchesThrownTOTAL");

					PlayerPrefs.SetInt("NumberOfPunchesThrownUpdate", TempData3);
					MK_RegisterUpdate_Score = TempScore + "";
					PBagGameContoller.isGetUpdateScore = true;

					print ("count: "+count);
					print ("NumberOfPunchesThrown: "+PlayerPrefs.GetInt("NumberOfPunchesThrownUpdate"));

					count++;
				}
			}

		}

		isget = false;
	}
}
