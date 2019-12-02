using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreController : MonoBehaviour
{
    
    private Text Pnumber;
    private GameObject Bags_1,Bags_2,Bags_3,Bags_4,Bags_5;
    private int CurrentBag = 1;
    private GameObject HideStore, HidePeople,RocketDialog,Buy2,Buy2Disable;
    private int BagsCount_1,BagsCount_2,BagsCount_3,BagsCount_4,BagsCount_5;
    private GameObject Equipment,EquipmentBuy,EquipmentCantBuy;
    private int BagValue_1,BagValue_2,BagValue_3,BagValue_4,BagValue_5;
    private  int memeValue = 0;
    private Animator PaymentDialog,LeaderBoard;

    public GameObject NotRegister, LeaderBoardBG;

    public static int CurrentEquipNow = 1;

    private int PowerUp2X  = 0;
    void Awake(){
        PowerUp2X =  PlayerPrefs.GetInt("PowerUp2X");
        if(PowerUp2X == 1){
            
        }
        Buy2  = GameObject.Find("PaymentDialog/Buy2Group/Buy2");
        Buy2Disable  = GameObject.Find("PaymentDialog/Buy2Group/Buy2Disable");
    }
    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs.DeleteAll();
        BagValue_1 = 0;
        BagValue_2 = 10000;
        BagValue_3 = 40000;
        BagValue_4 = 30000;
        BagValue_5 = 30000;
        Equipment = GameObject.Find("StoreBG/BagEquipments/Equipment");
        EquipmentBuy = GameObject.Find("StoreBG/BagEquipments/EquipmentBuy");
        EquipmentCantBuy = GameObject.Find("StoreBG/BagEquipments/EquipmentCantBuy");
         Equipment.SetActive(false);
         EquipmentBuy.SetActive(false);
         EquipmentCantBuy.SetActive(false);

         Pnumber = GameObject.Find("Store/StoreScoreText").GetComponent<Text>();

         Bags_1 = GameObject.Find("StoreBG/BagEquipments/Bags_1");
         Bags_2 = GameObject.Find("StoreBG/BagEquipments/Bags_2");
         Bags_3 = GameObject.Find("StoreBG/BagEquipments/Bags_3");
         Bags_4 = GameObject.Find("StoreBG/BagEquipments/Bags_4");
         Bags_5 = GameObject.Find("StoreBG/BagEquipments/Bags_5");

         Bags_1.SetActive(true);
         Bags_2.SetActive(false);
         Bags_3.SetActive(false);
         Bags_4.SetActive(false);
         Bags_5.SetActive(false);

         HideStore = GameObject.Find("StoreBG");
         HideStore.SetActive(false);

         PaymentDialog  = GameObject.Find("PaymentDialog").GetComponent<Animator>();
         RocketDialog = GameObject.Find("RocketDialog");
         RocketDialog.SetActive(false);

        LeaderBoard  = GameObject.Find("LeaderBoard").GetComponent<Animator>();
         HidePeople = GameObject.Find("LeaderBoardBG");
        //  HidePeople.SetActive(false);

        if(PlayerPrefs.HasKey("BagsCount_1")){
             BagsCount_1 = PlayerPrefs.GetInt("BagsCount_1");
             BagsCount_2 = PlayerPrefs.GetInt("BagsCount_2");
             BagsCount_3 = PlayerPrefs.GetInt("BagsCount_3");
             BagsCount_4 = PlayerPrefs.GetInt("BagsCount_4");
             BagsCount_5 = PlayerPrefs.GetInt("BagsCount_5");

             
             CurrentEquipNow = PlayerPrefs.GetInt("CurrentEquipNow");
        }else{
            BagsCount_1 = 1;
            PlayerPrefs.SetInt("BagsCount_1", BagsCount_1);
            BagsCount_2 = 0;
            PlayerPrefs.SetInt("BagsCount_2", BagsCount_2);
            BagsCount_3 = 0;
            PlayerPrefs.SetInt("BagsCount_3", BagsCount_3);
            BagsCount_4 = 0;
            PlayerPrefs.SetInt("BagsCount_4", BagsCount_4);
            BagsCount_5 = 0;
            PlayerPrefs.SetInt("BagsCount_5", BagsCount_5);

            CurrentEquipNow = 1;
            PlayerPrefs.SetInt("CurrentEquipNow", CurrentEquipNow);
        }

        NotRegister = GameObject.Find("NotRegister");
        LeaderBoardBG = GameObject.Find("LeaderBoardBG");

        NotRegister.SetActive(false);
        LeaderBoardBG.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        PowerUp2X =  PlayerPrefs.GetInt("PowerUp2X");
        if(PowerUp2X == 1){
            //Buy2.SetActive(false);
            //Buy2Disable.SetActive(true);
        }else{
            //Buy2.SetActive(true);
            //Buy2Disable.SetActive(false);
        }

        if(PBagGameContoller.GPnumber == "" || PBagGameContoller.GPnumber == null){
            PBagGameContoller.GPnumber = "0";
        }

        Pnumber.text = PBagGameContoller.GPnumber;

        memeValue = PBagGameContoller. NumberOfPunchesThrown;
       
        //int.TryParse(PBagGameContoller.GPnumber, out memeValue);

        if(CurrentBag == 1){
            Bags_1.SetActive(true);
            Bags_2.SetActive(false);
            Bags_3.SetActive(false);
            Bags_4.SetActive(false);
            Bags_5.SetActive(false);
            if(BagsCount_1 == 1){
                Equipment.SetActive(true);
                EquipmentBuy.SetActive(false);
                EquipmentCantBuy.SetActive(false);
            }else if(BagsCount_1 == 0 && memeValue >= BagValue_1){
                Equipment.SetActive(false);
                EquipmentBuy.SetActive(true);
                EquipmentCantBuy.SetActive(false);
            }else if(memeValue <= BagValue_1) {
                Equipment.SetActive(false);
                EquipmentBuy.SetActive(false);
                EquipmentCantBuy.SetActive(true);
            }
        }else if(CurrentBag == 2){
            Bags_1.SetActive(false);
            Bags_2.SetActive(true);
            Bags_3.SetActive(false);
            Bags_4.SetActive(false);
            Bags_5.SetActive(false);
            if(BagsCount_2 == 1){
                Equipment.SetActive(true);
                EquipmentBuy.SetActive(false);
                EquipmentCantBuy.SetActive(false);
            }else if(BagsCount_2 == 0 && memeValue >= BagValue_2){
                Equipment.SetActive(false);
                EquipmentBuy.SetActive(true);
                EquipmentCantBuy.SetActive(false);
            }else if(memeValue <= BagValue_2) {
                Equipment.SetActive(false);
                EquipmentBuy.SetActive(false);
                EquipmentCantBuy.SetActive(true);
            }
        }else if(CurrentBag == 3){
            Bags_1.SetActive(false);
            Bags_2.SetActive(false);
            Bags_3.SetActive(true);
            Bags_4.SetActive(false);
            Bags_5.SetActive(false);
            if(BagsCount_3 == 1){
                Equipment.SetActive(true);
                EquipmentBuy.SetActive(false);
                EquipmentCantBuy.SetActive(false);
            }else if(BagsCount_3 == 0 && memeValue >= BagValue_3){
                Equipment.SetActive(false);
                EquipmentBuy.SetActive(true);
                EquipmentCantBuy.SetActive(false);
            }else if(memeValue <= BagValue_3) {
                Equipment.SetActive(false);
                EquipmentBuy.SetActive(false);
                EquipmentCantBuy.SetActive(true);
            }
        }else if(CurrentBag == 4){
            Bags_1.SetActive(false);
            Bags_2.SetActive(false);
            Bags_3.SetActive(false);
            Bags_4.SetActive(true);
            Bags_5.SetActive(false);
            if(BagsCount_4 == 1){
                Equipment.SetActive(true);
                EquipmentBuy.SetActive(false);
                EquipmentCantBuy.SetActive(false);
            }else if(BagsCount_4 == 0 && memeValue >= BagValue_4){
                Equipment.SetActive(false);
                EquipmentBuy.SetActive(true);
                EquipmentCantBuy.SetActive(false);
            }else if(memeValue <= BagValue_4) {
                Equipment.SetActive(false);
                EquipmentBuy.SetActive(false);
                EquipmentCantBuy.SetActive(true);
            }
        }else if(CurrentBag == 5){
            Bags_1.SetActive(false);
            Bags_2.SetActive(false);
            Bags_3.SetActive(false);
            Bags_4.SetActive(false);
            Bags_5.SetActive(true);
            if(BagsCount_5 == 1){
                Equipment.SetActive(true);
                EquipmentBuy.SetActive(false);
                EquipmentCantBuy.SetActive(false);
            }else if(BagsCount_5 == 0 && memeValue >= BagValue_5){
                Equipment.SetActive(false);
                EquipmentBuy.SetActive(true);
                EquipmentCantBuy.SetActive(false);
            }else if(memeValue <= BagValue_5) {
                Equipment.SetActive(false);
                EquipmentBuy.SetActive(false);
                EquipmentCantBuy.SetActive(true);
            }
        }
    }

    public void NextBug(){
        CurrentBag++;
        if(CurrentBag == 6){
            CurrentBag = 1;
        }
    }

    public void PrevBug(){
        CurrentBag--;
        if(CurrentBag == 0){
            CurrentBag = 5;
        }
    }

    public void StoreHide(){
        HideStore.SetActive(false);
    }

    public void StoreShow(){
        HideStore.SetActive(true);
    }

    public void RocketHide(){
        PaymentDialog.SetBool ("Show", false);
        PaymentDialog.SetBool ("Hide", true);
        StartCoroutine(HidePaymentDialog());
    }

    public void RocketShow(){
        PaymentDialog.SetBool ("Show", true);
        PaymentDialog.SetBool ("Hide", false);
        RocketDialog.SetActive(true);
    }

     IEnumerator HidePaymentDialog()
    {
        
        yield return new WaitForSeconds(.8f);
        RocketDialog.SetActive(false);
    }

    public void PeopleHide(){
        LeaderBoard.SetBool ("Show", false);
        LeaderBoard.SetBool ("Hide", true);
        StartCoroutine(HideHidePeople());
    }

    public void PeopleShow(){
        if (PlayerPrefs.HasKey("SavePlayerName") != null && PlayerPrefs.GetString("SavePlayerName") != "")
        {
            LeaderBoard.SetBool("Show", true);
            LeaderBoard.SetBool("Hide", false);
            HidePeople.SetActive(true);
        }
        else
        {
            //print("Dartaasasdasd");
            NotRegister.SetActive(true);
            LeaderBoardBG.SetActive(false);
        }
        
    }
    
     IEnumerator HideHidePeople()
    {
        yield return new WaitForSeconds(.8f);
        HidePeople.SetActive(false);
    }

    private void PurchaseOn(int RemoveScore){
        int CurrentScore = memeValue - RemoveScore;
        PBagGameContoller.NumberOfPunchesThrown = CurrentScore;
        PlayerPrefs.SetInt("NumberOfPunchesThrown", CurrentScore);
        // print("1111: "+ CurrentBag);
    }

    public void  Purchase(){
        // int Buy = CurrentBag;
        
        if(CurrentBag == 1){
            PurchaseOn(BagValue_1);
        }
        else if(CurrentBag == 2){
            PurchaseOn(BagValue_2);
            BagsCount_2 = 1;
            PlayerPrefs.SetInt("BagsCount_2", BagsCount_2);
        }
        else if(CurrentBag == 3){
            PurchaseOn(BagValue_3);
            BagsCount_3 = 1;
            PlayerPrefs.SetInt("BagsCount_3", BagsCount_3);
        }
        else if(CurrentBag == 4){
            PurchaseOn(BagValue_4);
            BagsCount_4 = 1;
            PlayerPrefs.SetInt("BagsCount_4", BagsCount_4);
        }
        else if(CurrentBag == 5){
            PurchaseOn(BagValue_5);
            BagsCount_5 = 1;
            PlayerPrefs.SetInt("BagsCount_5", BagsCount_5);
        }
    }

    public void  EquipNow(){
        // int Buy = CurrentBag;
        
        if(CurrentBag == 1){
            CurrentEquipNow = 1;
            PlayerPrefs.SetInt("CurrentEquipNow", CurrentEquipNow);
        }
        else if(CurrentBag == 2){
            CurrentEquipNow = 2;
            PlayerPrefs.SetInt("CurrentEquipNow", CurrentEquipNow);
        }
        else if(CurrentBag == 3){
            CurrentEquipNow = 3;
            PlayerPrefs.SetInt("CurrentEquipNow", CurrentEquipNow);
        }
        else if(CurrentBag == 4){
           CurrentEquipNow = 4;
           PlayerPrefs.SetInt("CurrentEquipNow", CurrentEquipNow);
        }
        else if(CurrentBag == 5){
            CurrentEquipNow = 5;
            PlayerPrefs.SetInt("CurrentEquipNow", CurrentEquipNow);
        }
        StoreHide();
    }

    public void BuyPowerUps(){
        PBagGameContoller.isAddScore = true;
		print ("BuyPowerUps");
	}

	public void BuyPowerUps2(){
		PBagGameContoller.isAddScore2 = true;
		print ("BuyPowerUps2");
	}

    public void BuyPowerUpsGold(){
        
       PlayerPrefs.SetInt("PowerUp2X", 1);
	     print ("BuyPowerUps");
	}
}
