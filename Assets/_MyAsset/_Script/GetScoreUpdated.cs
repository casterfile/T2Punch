using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetScoreUpdated : MonoBehaviour {
	private string GetPlayerScorePHP_Url = "https://immersivemedia.ph/Tap2Punch/MK_GetPlayerScore.php";
	private bool isget = false;

	// Use this for initialization
	void Start () {
//		PlayerPrefs.DeleteKey ("SavePlayerName");
//		if (PlayerPrefs.HasKey ("SavePlayerName") == false) {
//			StartCoroutine (GetTop ());
//
//		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

//	IEnumerator GetTop()
//	{
//		int count = 1;
//
//		if (isget)//if alredy load info
//			yield return null;
//
//		isget = true;//notify is load now
//
//		WWW www = new WWW(GetPlayerScorePHP_Url);
//		yield return www;//wait for response
//
//		if (www.error != null)
//		{
//			print("There was an error getting the high score: " + www.error);
//		}
//		else
//		{
//
//			//get info from data base
//			string result = www.text;
//			//get and separate users
//			string[] splituser = result.Split("\n"[0]);
//
//			int numbers = 0;
//			bool mtype = false;
//
//			foreach (string u in splituser)
//			{
//				numbers++;
//				mtype = !mtype;
//				//get separate info user
//				string[] splitinfo = u.Split("-"[0]);
//
//				if (u != string.Empty && u != null)
//				{
//					string Data1 = numbers + "";
//					string Data2 = splitinfo[0];
//					string Data3 = splitinfo [1];
//					//					PlayerPrefs.SetString ("ScoreListName"+count, Data2);
//					//					PlayerPrefs.SetString ("ScoreListScore"+count, Data3);
//
//					PlayerPrefs.SetString ("SavePlayerName",Data2);
//					MK_RegisterUpdate_Name = PlayerPrefs.GetString ("SavePlayerName");
//					int TempData3 = int.Parse (Data3);
//					PlayerPrefs.SetInt ("NumberOfPunchesThrownTOTAL",TempData3);
//					int TempScore = PlayerPrefs.GetInt ("NumberOfPunchesThrownTOTAL");
//
//					PlayerPrefs.SetInt("NumberOfPunchesThrownUpdate", TempData3);
//					MK_RegisterUpdate_Score = TempScore + "";
//
//					print ("count: "+count);
//					print ("NumberOfPunchesThrown: "+PlayerPrefs.GetInt("NumberOfPunchesThrown"));
//
//					count++;
//				}
//			}
//
//		}
//
//		isget = false;
//	}
}
