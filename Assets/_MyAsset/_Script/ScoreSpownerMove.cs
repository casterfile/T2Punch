using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSpownerMove : MonoBehaviour
{
    private Vector3 myTarget;
    private Vector3 direction;
    private float speed = 300.0f;

    public Sprite LableX1,LableX2,LableX3,LableX4,LableX5;
    private Image ScoreBackground; 
    // Start is called before the first frame update
    void Start()
    {
        ScoreBackground = GetComponent<Image>();

        // if(PBagGameContoller.tapsPerSecond > 10 && PBagGameContoller.tapsPerSecond <= 20){
        //     ScoreBackground.sprite = LableX2;
        //     ScoreBackground.enabled = true;
        // }else if(PBagGameContoller.tapsPerSecond > 20  && PBagGameContoller.tapsPerSecond <= 30){
        //     ScoreBackground.sprite = LableX3;
        //     ScoreBackground.enabled = true;
        // }else if(PBagGameContoller.tapsPerSecond > 30  && PBagGameContoller.tapsPerSecond <= 40){
        //     ScoreBackground.sprite = LableX4;
        //     ScoreBackground.enabled = true;
        // }else if(PBagGameContoller.tapsPerSecond > 40 ){
        //     ScoreBackground.sprite = LableX5;
        //     ScoreBackground.enabled = true;
        // }else if(PBagGameContoller.tapsPerSecond <= 10 ){
        //     ScoreBackground.sprite = LableX1;
        //     ScoreBackground.enabled = true;
        // }
        int PowerUp2X =  PlayerPrefs.GetInt("PowerUp2X");
        if(PowerUp2X == 1){
             if(GameController.PunchLvl == 2 || GameController.PunchLvl == 1){
                ScoreBackground.sprite = LableX2;
                ScoreBackground.enabled = true;
            }else if(GameController.PunchLvl == 3){
                ScoreBackground.sprite = LableX3;
                ScoreBackground.enabled = true;
            }else if(GameController.PunchLvl == 4){
                ScoreBackground.sprite = LableX4;
                ScoreBackground.enabled = true;
            }else if(GameController.PunchLvl == 5){
                ScoreBackground.sprite = LableX5;
                ScoreBackground.enabled = true;
            }
        }
       else{
            if(GameController.PunchLvl == 1){
                ScoreBackground.sprite = LableX1;
                ScoreBackground.enabled = true;
            }else if(GameController.PunchLvl == 2){
                ScoreBackground.sprite = LableX2;
                ScoreBackground.enabled = true;
            }else if(GameController.PunchLvl == 3){
                ScoreBackground.sprite = LableX3;
                ScoreBackground.enabled = true;
            }else if(GameController.PunchLvl == 4){
                ScoreBackground.sprite = LableX4;
                ScoreBackground.enabled = true;
            }else if(GameController.PunchLvl == 5){
                ScoreBackground.sprite = LableX5;
                ScoreBackground.enabled = true;
            }
       }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, speed * 1);
    }

    void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.name == "BorderRemoveScore")
		{
			Destroy(gameObject);
		}
	}
}
