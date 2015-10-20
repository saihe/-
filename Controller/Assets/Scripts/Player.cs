using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    //プレイヤーの移動スピード調整用変数
    public float speed = 1;

    //フリック判定用
    public float jump = 1;

    //タッチされた座標
    private Vector2 touch;

    //タッチ後移動した座標
    private Vector2 dragPoint;

    //回転速度
    private float rotationSpeed = 10000.0f;

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
            double x = dragPoint.x - touch.x;
            double y = 0;
            double z = dragPoint.y - touch.y;

            double touchTime = Time.deltaTime;
            if (touchTime < 0.05)
            {
                if (x < 0.05)
                {
                    print("Jump");
                    transform.Translate(new Vector3(0, jump, 0));
                }
                else
                {
                    return;
                }
            }


            //タッチ位置と移動位置が同じなら移動
            if (dragPoint != touch)
            {
                //入力をVector3に変換移動量を制限
                Vector3 direction = new Vector3((float)x, (float)y, (float)z) / 1000;
                //print("direction: " + direction);

                //入力ベクトルをQuaternionに変換
                Quaternion to = Quaternion.LookRotation(direction);

                //キャラクターを向かせる
                transform.rotation = Quaternion.RotateTowards(transform.rotation, to, rotationSpeed * Time.deltaTime);

                //タッチされた座標を画面上の座標に変換
                Vector3 cm = Camera.main.ScreenToWorldPoint(direction);
                Vector3 moveTo = new Vector3(cm.x * -1, 0, cm.z * -1) / 100;
                print("direction: " + direction);

                //移動
                transform.Translate(moveTo * speed);
            }
        }
    }
}
