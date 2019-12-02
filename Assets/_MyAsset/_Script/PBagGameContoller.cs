using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class PBagGameContoller : MonoBehaviour
{ 
    public static bool isAddScore = false;
	public static bool isAddScore2 = false;
    
    public static bool isGetUpdateScore = false;
    public static int NumberOfPunchesThrown = 0;  
    public static int NumberOfPunchesThrownTOTAL = 0; 

    public Sprite PBRed_1,
    PBRed_2,PBRed_3,
    PBRed_2_1,PBRed_3_1,
    PBRed_2_2,PBRed_3_2;

    public Sprite PBDeadLine_1,
    PBDeadLine_2,PBDeadLine_3,
    PBDeadLine_2_1,PBDeadLine_3_1,
    PBDeadLine_2_2,PBDeadLine_3_2;

    public Sprite YourEx_1,
    YourEx_2,YourEx_3,
    YourEx_2_1,YourEx_3_1,
    YourEx_2_2,YourEx_3_2;

    public Sprite ThatOne_1,
    ThatOne_2,ThatOne_3,
    ThatOne_2_1,ThatOne_3_1,
    ThatOne_2_2,ThatOne_3_2;

    

    public Sprite OldDummy_1,
    OldDummy_2,OldDummy_3,
    OldDummy_2_1,OldDummy_3_1,
    OldDummy_2_2,OldDummy_3_2;

	public GameObject prefab1,prefabPunch;
    private int lvlCount = 1;

    private Image m_Image; 
    private int Int_ranSprite = 1;
    private Text Pnumber,Pperscond;
    public static string GPnumber;
    private GameObject SpawnLocation0,SpawnLocation1,SpawnLocation2,SpawnLocation3,SpawnLocation4,SpawnLocation5,
    SpawnLocation6,SpawnLocation7,SpawnLocation8,SpawnLocation9,SpawnLocation10,SpawnLocation11,SpawnLocation12,
    SpawnLocation13,SpawnLocation14;

    private GameObject PunchLocation0,PunchLocation1,PunchLocation2,PunchLocation3,PunchLocation4,
    PunchLocation5,PunchLocation6;

    private List<float> taps = new List<float>();
    public static float tapsPerSecond;

    public AudioClip impact,impact2,impact3,impact4,impact5,impact6,impact7;
    AudioSource audioSource;

    private Image InteractivebarInactive;
    private bool coolingDown;
    private int LVLGameBar = 1;
    private float FloatInteractivebarInactive = 1;
    
     private int Number = 0; 
    // Start is called before the first frame update

    void Start() 
    {
//         PlayerPrefs.DeleteAll();
        

        if(PlayerPrefs.HasKey("LVLGameBar")){
            LVLGameBar = PlayerPrefs.GetInt("LVLGameBar");
            StoreController.CurrentEquipNow = PlayerPrefs.GetInt("CurrentEquipNow");
            print("StoreController.CurrentEquipNow: "+StoreController.CurrentEquipNow);
        }else{
           LVLGameBar = 1;
            PlayerPrefs.SetInt("LVLGameBar", LVLGameBar);
            PlayerPrefs.SetInt("CurrentEquipNow", StoreController.CurrentEquipNow);
        }

        if(PlayerPrefs.HasKey("NumberOfPunchesThrown")){
            NumberOfPunchesThrown = PlayerPrefs.GetInt("NumberOfPunchesThrown");
            NumberOfPunchesThrownTOTAL = PlayerPrefs.GetInt("NumberOfPunchesThrownTOTAL");
            FloatInteractivebarInactive = PlayerPrefs.GetFloat("FloatInteractivebarInactive");
        }else{
            NumberOfPunchesThrown = 0;
            PlayerPrefs.SetInt("NumberOfPunchesThrown", NumberOfPunchesThrown);
            PlayerPrefs.SetInt("NumberOfPunchesThrownTOTAL", NumberOfPunchesThrownTOTAL);
            FloatInteractivebarInactive = 1;
            PlayerPrefs.SetFloat("FloatInteractivebarInactive", FloatInteractivebarInactive);
            
        }
        
        lvlCount = 1;
        m_Image = GetComponent<Image>();
        Pnumber = GameObject.Find("Pnumber").GetComponent<Text>();
        Pperscond = GameObject.Find("Pperscond").GetComponent<Text>();

        
        coolingDown = true;
        InteractivebarInactive = GameObject.Find("InteractivebarInactive").GetComponent<Image>();
        InteractivebarInactive.fillAmount = FloatInteractivebarInactive;

        SpawnLocation0 = GameObject.Find("SpawnLocation (0)");
        SpawnLocation1 = GameObject.Find("SpawnLocation (1)");
        SpawnLocation2 = GameObject.Find("SpawnLocation (2)");
        SpawnLocation3 = GameObject.Find("SpawnLocation (3)");
        SpawnLocation4 = GameObject.Find("SpawnLocation (4)");
        SpawnLocation5 = GameObject.Find("SpawnLocation (5)");
        SpawnLocation6 = GameObject.Find("SpawnLocation (6)");
        SpawnLocation7 = GameObject.Find("SpawnLocation (7)");
        SpawnLocation8 = GameObject.Find("SpawnLocation (8)");
        SpawnLocation9 = GameObject.Find("SpawnLocation (9)");
        SpawnLocation10 = GameObject.Find("SpawnLocation (10)");
        SpawnLocation11 = GameObject.Find("SpawnLocation (11)");
        SpawnLocation12 = GameObject.Find("SpawnLocation (12)");
        SpawnLocation13 = GameObject.Find("SpawnLocation (13)");
        SpawnLocation14 = GameObject.Find("SpawnLocation (14)");

        PunchLocation0 = GameObject.Find("PunchLocation (0)");
        PunchLocation1 = GameObject.Find("PunchLocation (1)");
        PunchLocation2 = GameObject.Find("PunchLocation (2)");
        PunchLocation3 = GameObject.Find("PunchLocation (3)");
        PunchLocation4 = GameObject.Find("PunchLocation (4)");
        PunchLocation5 = GameObject.Find("PunchLocation (5)");
        PunchLocation6 = GameObject.Find("PunchLocation (6)");

        audioSource = GetComponent<AudioSource>();

        UpAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("LVLGameBar", LVLGameBar);

		if(isGetUpdateScore == true){
			isGetUpdateScore = false;

			NumberOfPunchesThrown = PlayerPrefs.GetInt("NumberOfPunchesThrown");
			NumberOfPunchesThrownTOTAL = PlayerPrefs.GetInt("NumberOfPunchesThrownTOTAL");

			NumberOfPunchesThrown = PlayerPrefs.GetInt("NumberOfPunchesThrownUpdate");
			NumberOfPunchesThrownTOTAL = PlayerPrefs.GetInt("NumberOfPunchesThrownUpdate");

			PlayerPrefs.SetInt("NumberOfPunchesThrown", NumberOfPunchesThrown);
			PlayerPrefs.SetInt("NumberOfPunchesThrownTOTAL", NumberOfPunchesThrownTOTAL);

			print ("Testing how may times");
		}

        if(isAddScore == true){
            isAddScore = false;
            int AddPunch = 50000;

            NumberOfPunchesThrown = PlayerPrefs.GetInt("NumberOfPunchesThrown");
            NumberOfPunchesThrownTOTAL = PlayerPrefs.GetInt("NumberOfPunchesThrownTOTAL");

            NumberOfPunchesThrown = NumberOfPunchesThrown + AddPunch;
            NumberOfPunchesThrownTOTAL = NumberOfPunchesThrownTOTAL + AddPunch;

            PlayerPrefs.SetInt("NumberOfPunchesThrown", NumberOfPunchesThrown);
            PlayerPrefs.SetInt("NumberOfPunchesThrownTOTAL", NumberOfPunchesThrownTOTAL);

			print ("Testing how may times");
		}

		if(isAddScore2 == true){
			isAddScore2 = false;
			int AddPunch = 100000;

			NumberOfPunchesThrown = PlayerPrefs.GetInt("NumberOfPunchesThrown");
			NumberOfPunchesThrownTOTAL = PlayerPrefs.GetInt("NumberOfPunchesThrownTOTAL");

			NumberOfPunchesThrown = NumberOfPunchesThrown + AddPunch;
			NumberOfPunchesThrownTOTAL = NumberOfPunchesThrownTOTAL + AddPunch;

			PlayerPrefs.SetInt("NumberOfPunchesThrown", NumberOfPunchesThrown);
			PlayerPrefs.SetInt("NumberOfPunchesThrownTOTAL", NumberOfPunchesThrownTOTAL);

			print ("Testing how may times222");
		}



        if (Home.isScoreResetting == true)
        {
            Home.isScoreResetting = false;
            int AddPunch = Home.InternetScore;

            NumberOfPunchesThrown = PlayerPrefs.GetInt("NumberOfPunchesThrown");
            NumberOfPunchesThrownTOTAL = PlayerPrefs.GetInt("NumberOfPunchesThrownTOTAL");

            NumberOfPunchesThrown = NumberOfPunchesThrown + AddPunch;
            NumberOfPunchesThrownTOTAL = NumberOfPunchesThrownTOTAL + AddPunch;

            PlayerPrefs.SetInt("NumberOfPunchesThrown", NumberOfPunchesThrown);
            PlayerPrefs.SetInt("NumberOfPunchesThrownTOTAL", NumberOfPunchesThrownTOTAL);

            print("Testing how may times: "+ Home.InternetScore);
        }
        

        PlayerPrefs.SetInt("NumberOfPunchesThrown", NumberOfPunchesThrown);

        PlayerPrefs.SetInt("NumberOfPunchesThrownTOTAL", NumberOfPunchesThrownTOTAL);

        PlayerPrefs.SetFloat("FloatInteractivebarInactive", InteractivebarInactive.fillAmount);

         if(InteractivebarInactive.fillAmount == 0){
            InteractivebarInactive.fillAmount = 1;
            LVLGameBar = LVLGameBar * 2;
        }
        
       
        string Format = string.Format("{0:#,#}", NumberOfPunchesThrown);
        GPnumber = Format;
        if(NumberOfPunchesThrown == 0){
            Pnumber.text = 0 + " punches thrown!";
        }else{
            Pnumber.text = Format + " punches thrown!"; 
        }

        for (int i = 0; i < taps.Count; i++)
        {
            if (taps[i] <= Time.timeSinceLevelLoad - 1)
            {
                taps.RemoveAt(i);
                //print("tapsPerSecond: "+taps);
            }
        }
        tapsPerSecond = taps.Count;
       

        string FormatPerSecond = string.Format("{0:#,#}", tapsPerSecond);


        if (tapsPerSecond == 0)
        {
            Pperscond.text = 0 + " Punches Per Second!";
        }
        else
        {
            Pperscond.text = FormatPerSecond + " Punches Per Second!";
        }
    }
   
    public void SoundEffect(){
        if(Number == 0){
            Number = 1;
             audioSource.PlayOneShot(impact3);
        }else if(Number == 1){
            Number = 2;
             audioSource.PlayOneShot(impact4);
        }else if(Number == 2){
            Number = 3;
             audioSource.PlayOneShot(impact5);
        }else if(Number == 3){
            Number = 0;
             audioSource.PlayOneShot(impact6);
        }else if(Number == 4){
            Number = 0;
             audioSource.PlayOneShot(impact7);
        }
    }

    public void DownAnimation()
    {
        if(StoreController.CurrentEquipNow == 1){
           if (Int_ranSprite == 1) // if the spriteRenderer sprite = sprite1 then change to sprite2
            {
                Int_ranSprite = 2;
                if(lvlCount == 3 || lvlCount == 4){
                    SoundEffect();
                    m_Image.sprite = PBRed_3_1;
                }else if(lvlCount == 5){
                    SoundEffect();
                    m_Image.sprite = PBRed_3_2;
                }else{
                    SoundEffect();
                    m_Image.sprite = PBRed_3;
                }
            }
            else
            {
                // otherwise change it back to sprite1
                Int_ranSprite = 1;

                if(lvlCount == 3 || lvlCount == 4){
                    SoundEffect();
                    m_Image.sprite = PBRed_2_1;
                }else if(lvlCount == 5){
                    SoundEffect();
                    m_Image.sprite = PBRed_2_2;
                }else{
                    SoundEffect();
                    m_Image.sprite = PBRed_2;
                }
            }
        }else  if(StoreController.CurrentEquipNow == 2){
            if (Int_ranSprite == 1) // if the spriteRenderer sprite = sprite1 then change to sprite2
            {
                Int_ranSprite = 2;
                if(lvlCount == 3 || lvlCount == 4){
                    SoundEffect();
                    m_Image.sprite = PBDeadLine_3_1;
                }else if(lvlCount == 5){
                    SoundEffect();
                    m_Image.sprite = PBDeadLine_3_2;
                }else{
                    SoundEffect();
                    m_Image.sprite = PBDeadLine_3;
                }
            }
            else
            {
                // otherwise change it back to sprite1
                Int_ranSprite = 1;

                if(lvlCount == 3 || lvlCount == 4){
                    SoundEffect();
                    m_Image.sprite = PBDeadLine_2_1;
                }else if(lvlCount == 5){
                    SoundEffect();
                    m_Image.sprite = PBDeadLine_2_2;
                }else{
                    SoundEffect();
                    m_Image.sprite = PBDeadLine_2;
                }
            }
        }else  if(StoreController.CurrentEquipNow == 3){
            if (Int_ranSprite == 1) // if the spriteRenderer sprite = sprite1 then change to sprite2
            {
                Int_ranSprite = 2;
                if(lvlCount == 3 || lvlCount == 4){
                    SoundEffect();
                    m_Image.sprite = YourEx_3_1;
                }else if(lvlCount == 5){
                    SoundEffect();
                    m_Image.sprite = YourEx_3_2;
                }else{
                    SoundEffect();
                    m_Image.sprite = YourEx_3;
                }
            }
            else
            {
                // otherwise change it back to sprite1
                Int_ranSprite = 1;

                if(lvlCount == 3 || lvlCount == 4){
                    SoundEffect();
                    m_Image.sprite = YourEx_2_1;
                }else if(lvlCount == 5){
                    SoundEffect();
                    m_Image.sprite = YourEx_2_2;
                }else{
                    SoundEffect();
                    m_Image.sprite = YourEx_2;
                }
            }
        }else  if(StoreController.CurrentEquipNow == 4){
            if (Int_ranSprite == 1) // if the spriteRenderer sprite = sprite1 then change to sprite2
            {
                Int_ranSprite = 2;
                if(lvlCount == 3 || lvlCount == 4){
                    SoundEffect();
                    m_Image.sprite = ThatOne_3_1;
                }else if(lvlCount == 5){
                    SoundEffect();
                    m_Image.sprite = ThatOne_3_2;
                }else{
                    SoundEffect();
                    m_Image.sprite = ThatOne_3;
                }
            }
            else
            {
                // otherwise change it back to sprite1
                Int_ranSprite = 1;

                if(lvlCount == 3 || lvlCount == 4){
                    SoundEffect();
                    m_Image.sprite = ThatOne_2_1;
                }else if(lvlCount == 5){
                    SoundEffect();
                    m_Image.sprite = ThatOne_2_2;
                }else{
                    SoundEffect();
                    m_Image.sprite = ThatOne_2;
                }
            }
        }else  if(StoreController.CurrentEquipNow == 5){
            if (Int_ranSprite == 1) // if the spriteRenderer sprite = sprite1 then change to sprite2
            {
                Int_ranSprite = 2;
                if(lvlCount == 3 || lvlCount == 4){
                    SoundEffect();
                    m_Image.sprite = OldDummy_3_1;
                }else if(lvlCount == 5){
                    SoundEffect();
                    m_Image.sprite = OldDummy_3_2;
                }else{
                    SoundEffect();
                    m_Image.sprite = OldDummy_3;
                }
            }
            else
            {
                // otherwise change it back to sprite1
                Int_ranSprite = 1;

                if(lvlCount == 3 || lvlCount == 4){
                    SoundEffect();
                    m_Image.sprite = OldDummy_2_1;
                }else if(lvlCount == 5){
                    SoundEffect();
                    m_Image.sprite = OldDummy_2_2;
                }else{
                    SoundEffect();
                    m_Image.sprite = OldDummy_2;
                }
            }
        }
        

        int PowerUp2X =  PlayerPrefs.GetInt("PowerUp2X");
        if(PowerUp2X == 1){
            if(PBagGameContoller.tapsPerSecond  <= 20){
                lvlCount = 2;
                NumberOfPunchesThrown = NumberOfPunchesThrown + 2;
                NumberOfPunchesThrownTOTAL = NumberOfPunchesThrownTOTAL + 2;
            }else if(PBagGameContoller.tapsPerSecond > 20  && PBagGameContoller.tapsPerSecond <= 30){
                lvlCount = 3;
                NumberOfPunchesThrown = NumberOfPunchesThrown + 3;
                NumberOfPunchesThrownTOTAL = NumberOfPunchesThrownTOTAL + 3;
            }else if(PBagGameContoller.tapsPerSecond > 30  && PBagGameContoller.tapsPerSecond <= 40){
                lvlCount = 4;
                NumberOfPunchesThrown = NumberOfPunchesThrown + 4;
                NumberOfPunchesThrownTOTAL = NumberOfPunchesThrownTOTAL + 4;
            }else if(PBagGameContoller.tapsPerSecond > 40 ){
                lvlCount = 5;
                NumberOfPunchesThrown = NumberOfPunchesThrown + 5;
                NumberOfPunchesThrownTOTAL = NumberOfPunchesThrownTOTAL + 5;
            }
        }else{
            if(PBagGameContoller.tapsPerSecond > 10 && PBagGameContoller.tapsPerSecond <= 20){
                lvlCount = 2;
                NumberOfPunchesThrown = NumberOfPunchesThrown + 2;
                NumberOfPunchesThrownTOTAL = NumberOfPunchesThrownTOTAL + 2;
            }else if(PBagGameContoller.tapsPerSecond > 20  && PBagGameContoller.tapsPerSecond <= 30){
                lvlCount = 3;
                NumberOfPunchesThrown = NumberOfPunchesThrown + 3;
                NumberOfPunchesThrownTOTAL = NumberOfPunchesThrownTOTAL + 3;
            }else if(PBagGameContoller.tapsPerSecond > 30  && PBagGameContoller.tapsPerSecond <= 40){
                lvlCount = 4;
                NumberOfPunchesThrown = NumberOfPunchesThrown + 4;
                NumberOfPunchesThrownTOTAL = NumberOfPunchesThrownTOTAL + 4;
            }else if(PBagGameContoller.tapsPerSecond > 40 ){
                lvlCount = 5;
                NumberOfPunchesThrown = NumberOfPunchesThrown + 5;
                NumberOfPunchesThrownTOTAL = NumberOfPunchesThrownTOTAL + 5;
            }else if(PBagGameContoller.tapsPerSecond <= 10 ){
                lvlCount = 1;
                NumberOfPunchesThrown = NumberOfPunchesThrown + 1;
                NumberOfPunchesThrownTOTAL = NumberOfPunchesThrownTOTAL + 1;
            }
        }
        

        if (coolingDown == true)
        {
            //Reduce fill amount over 30 seconds
            InteractivebarInactive.fillAmount -= 0.1f / (LVLGameBar);
           
        }

        //print("lvlCount: "+ lvlCount);
        taps.Add(Time.timeSinceLevelLoad);
        CreateShowPoints();
       StartCoroutine(CreateShowPunch());
    }

    public void UpAnimation()
    {
        if(StoreController.CurrentEquipNow == 1){
            m_Image.sprite = PBRed_1;
        }else  if(StoreController.CurrentEquipNow == 2){
            m_Image.sprite = PBDeadLine_1;
        }else  if(StoreController.CurrentEquipNow == 3){
            m_Image.sprite = YourEx_1;
        }else  if(StoreController.CurrentEquipNow == 4){
            m_Image.sprite = ThatOne_1;
        }else  if(StoreController.CurrentEquipNow == 5){
            m_Image.sprite = OldDummy_1;
        }
        
    }

    void CreateShowPoints(){

        GameObject LocationLocal = SpawnLocation0;
        var RanNumber = Random.Range(0,14);
        if(RanNumber == 1){
             LocationLocal = SpawnLocation1;
        }else if(RanNumber == 2){
             LocationLocal = SpawnLocation2;
        }else if(RanNumber == 3){
             LocationLocal = SpawnLocation3;
        }else if(RanNumber == 4){
             LocationLocal = SpawnLocation4;
        }else if(RanNumber == 5){
             LocationLocal = SpawnLocation5;
        }else if(RanNumber == 6){
             LocationLocal = SpawnLocation6;
        }else if(RanNumber == 7){
             LocationLocal = SpawnLocation7;
        }else if(RanNumber == 8){
             LocationLocal = SpawnLocation8;
        }else if(RanNumber == 9){
             LocationLocal = SpawnLocation9;
        }else if(RanNumber == 10){
             LocationLocal = SpawnLocation10;
        }else if(RanNumber == 11){
             LocationLocal = SpawnLocation11;
        }else if(RanNumber == 12){
             LocationLocal = SpawnLocation12;
        }else if(RanNumber == 13){
             LocationLocal = SpawnLocation13;
        }else if(RanNumber == 14){
             LocationLocal = SpawnLocation14;
        }else {
             LocationLocal = SpawnLocation0;
        }

        GameObject instantiatedHint = Instantiate(prefab1, LocationLocal.transform.position, Quaternion.identity);
        
        float width = prefab1.transform.lossyScale.x;
		float height = prefab1.transform.lossyScale.y;

		instantiatedHint.transform.localScale = new Vector3(width, height, 0f);

		instantiatedHint.transform.parent = LocationLocal.transform;
    }

    IEnumerator CreateShowPunch()
    {
        GameObject LocationLocal = SpawnLocation0;
        var RanNumber = Random.Range(0,7);
        if(RanNumber == 1){
             LocationLocal = PunchLocation1;
        }else if(RanNumber == 2){
             LocationLocal = PunchLocation2;
        }else if(RanNumber == 3){
             LocationLocal = PunchLocation3;
        }else if(RanNumber == 4){
             LocationLocal = PunchLocation4;
        }else if(RanNumber == 5){
             LocationLocal = PunchLocation5;
        }else if(RanNumber == 6){
             LocationLocal = PunchLocation6;
        }else {
             LocationLocal = PunchLocation0;
        }

        GameObject instantiatedHint = Instantiate(prefabPunch, LocationLocal.transform.position, Quaternion.identity);
        
        float width = prefab1.transform.lossyScale.x;
		float height = prefab1.transform.lossyScale.y;

		instantiatedHint.transform.localScale = new Vector3(width, height, 0f);

		instantiatedHint.transform.parent = LocationLocal.transform;
        yield return new WaitForSeconds(0.5f);
        Destroy(instantiatedHint);
    }
}
