using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    //プレイヤーの移動スピード調整用変数
    public float speed = 1;

    //フリック判定用
    public float jump = 1;

    //タッチされた座標
    private Vector2 touch;

    //フリック判定用タッチ判定時間
    public double touchJdg = 0.05;

    //フリック判定用タッチ移動量
    public double flickJdg = 30;

    //タッチ後移動した座標
    private Vector2 dragPoint;

    //フリック用タッチしている時間
    private double touchTime;

    private bool flickOk;

    private Vector3 direction;

    private double x;
    private double y;
    private double z;
    

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
            touchTime = 0;
            flickOk = false;
        }

        if (Input.GetMouseButton(0))
        {
            //タッチ後移動した座標
            dragPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //プレイヤーが移動するベクトル
            x = dragPoint.x - touch.x;
            y = 0;
            z = dragPoint.y - touch.y;
            //print("x: " + x + " y: " + y + " z: " + z);
            touchTime += Time.deltaTime;
            //print("touchTime: " + touchTime);

            //フリック判定
            //時間
            if (touchTime < touchJdg)
            {
                print("touchTime is short");
                print("x: " + Mathf.Abs((float)x) + " z: " + Mathf.Abs((float)z));
                //指移動量
                if (Mathf.Abs((float)x) > flickJdg || Mathf.Abs((float)z) > flickJdg)
                {
                    print("Flick stanby OK");
                    flickOk = true;
                }
                else
                {
                    return;
                }
            }

            //タッチ位置と移動位置が同じなら移動
            else if (dragPoint != touch)
            {
                //入力をVector3に変換移動量を制限
                direction = new Vector3((float)x, (float)y, (float)z) / 1000;
                //print("direction: " + direction);

                //入力ベクトルをQuaternionに変換
                Quaternion to = Quaternion.LookRotation(direction);

                //キャラクターを向かせる
                transform.rotation = Quaternion.RotateTowards(transform.rotation, to, rotationSpeed * Time.deltaTime);

                //タッチされた座標を画面上の座標に変換
                Vector3 cm = Camera.main.ScreenToWorldPoint(direction);
                Vector3 moveTo = new Vector3(cm.x * -1, 0, cm.z * -1) / 100;
                //print("direction: " + direction);

                //移動
                transform.Translate(moveTo * speed);
            }
        }

        if (flickOk == true)
        {

            if (Input.GetMouseButtonUp(0))
            {
                direction = new Vector3((float)x, 50f, (float)z) / 10;
                print(direction);
                print("Jump");
                transform.rotation = Quaternion.LookRotation(new Vector3(0f, 0f, 0f));
                transform.Translate(direction);
            }

        }


    }
}
