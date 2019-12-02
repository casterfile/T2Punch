using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDown : MonoBehaviour
{
     void OnMouseDown()
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(p);
        print("Print: "+p);
    }
}
