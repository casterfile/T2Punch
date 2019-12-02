using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TouchPositionExample : MonoBehaviour
{
    public Text m_Text;
    public GameObject prefab1;
    Transform LocationLocal;
    void Update()
    {
        

        if(Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);

            //Update the Text on the screen depending on current position of the touch each frame
            m_Text.text = "Touch Position : " + touch.position;

            LocationLocal.transform.position = touch.position;
            GameObject instantiatedHint = Instantiate(prefab1, LocationLocal.localPosition, Quaternion.identity);
        
            float width = prefab1.transform.lossyScale.x;
            float height = prefab1.transform.lossyScale.y;

            instantiatedHint.transform.localScale = new Vector3(width, height, 0f);

            instantiatedHint.transform.parent = LocationLocal.transform;
        }
    }
}