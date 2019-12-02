using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Create_Trail : MonoBehaviour {
   
    public GameObject target;
 
    // Use this for initialization
    void Start () {
   
    }
   
    // Update is called once per frame
    void Update () {
       
        if(Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began)
        {
            print("Hello");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
           
            if(Physics.Raycast(ray,out hit))
                if(hit.collider != null)
                               
            Instantiate(target,hit.point,transform.rotation);
        }
   
    }
}
