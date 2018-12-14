using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reticulescritprjfjgjgrgjogrenjgrjngfnjdgfnjdfknjdgf : MonoBehaviour {
    GameObject myCanvas;
    GameManager theBoss;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, Camera.main, out pos);
        transform.position = myCanvas.transform.TransformPoint(pos);
    }
}
