using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    //プレイヤーの移動スピード調整用変数
    public float speed = 1;

    //タッチされた座標
    private Vector2 touch;

    //タッチ後移動した座標
    private Vector2 dragPoint;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        move();
    }

    public void move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //タッチされた座標を取得
            touch = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButton(0))
        {
            //タッチ後移動した座標
            dragPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //プレイヤーが移動するベクトル
            float x = dragPoint.x - touch.x;
            float y = 0;
            float z = dragPoint.y - touch.y;

            if (dragPoint != touch)
            {
                Vector3 direction = new Vector3(x, y, z) / 1000;
                print("direction: " + direction);
                transform.Translate(direction * speed);
            }
        }
    }
}
