using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public Sprite LableX2,LableX3,LableX4,LableX5;
    public static int PunchLvl = 1;
    private Image ScoreBackground; 
    // Start is called before the first frame update
    void Start()
    {
        PunchLvl = 1;
        ScoreBackground = GameObject.Find("ScoreBackground").GetComponent<Image>();

        ScoreBackground.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        int PowerUp2X =  PlayerPrefs.GetInt("PowerUp2X");
        if(PowerUp2X == 1){
            if(PBagGameContoller.tapsPerSecond > 1  && PBagGameContoller.tapsPerSecond < 20 ){
                PunchLvl = 2;
                ScoreBackground.sprite = LableX2;
                ScoreBackground.enabled = true;
            }else if(PBagGameContoller.tapsPerSecond > 20 && PBagGameContoller.tapsPerSecond < 30 ){
                PunchLvl = 3;
                ScoreBackground.sprite = LableX3;
                ScoreBackground.enabled = true;
            }else if(PBagGameContoller.tapsPerSecond > 30 && PBagGameContoller.tapsPerSecond < 40 ){
                PunchLvl = 4;
                ScoreBackground.sprite = LableX4;
                ScoreBackground.enabled = true;
            }else if(PBagGameContoller.tapsPerSecond > 40 ){
                PunchLvl = 5;
                ScoreBackground.sprite = LableX5;
                ScoreBackground.enabled = true;
            }else if(PBagGameContoller.tapsPerSecond < 0 ){
                PunchLvl = 1;
                ScoreBackground.sprite = LableX2;
                ScoreBackground.enabled = false;
            }
        }else{
            if(PBagGameContoller.tapsPerSecond > 10 && PBagGameContoller.tapsPerSecond < 20 ){
                PunchLvl = 2;
                ScoreBackground.sprite = LableX2;
                ScoreBackground.enabled = true;
            }else if(PBagGameContoller.tapsPerSecond > 20 && PBagGameContoller.tapsPerSecond < 30 ){
                PunchLvl = 3;
                ScoreBackground.sprite = LableX3;
                ScoreBackground.enabled = true;
            }else if(PBagGameContoller.tapsPerSecond > 30 && PBagGameContoller.tapsPerSecond < 40 ){
                PunchLvl = 4;
                ScoreBackground.sprite = LableX4;
                ScoreBackground.enabled = true;
            }else if(PBagGameContoller.tapsPerSecond > 40 ){
                PunchLvl = 5;
                ScoreBackground.sprite = LableX5;
                ScoreBackground.enabled = true;
            }else if(PBagGameContoller.tapsPerSecond < 10 ){
                PunchLvl = 1;
                ScoreBackground.sprite = LableX2;
                ScoreBackground.enabled = false;
            }
        }
        
    }
}
