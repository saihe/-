using UnityEngine;
using System.Collections;

public class TouchPoint : MonoBehaviour {

    //タッチパッド
    public GameObject touchPad;

    private Vector2 point;
    

	// Use this for initialization
	void Start () {
        //タッチパッド非表示
        touchPad.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        createPad();
	}

    public void createPad()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //タッチ地点の取得
            point = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //タッチパッドをタッチ地点に移動
            touchPad.transform.position = point;

            //タッチパッド表示
            touchPad.SetActive(true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            touchPad.SetActive(false);
        }
    } 
}
