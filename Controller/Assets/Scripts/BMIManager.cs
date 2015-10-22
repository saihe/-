using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BMIManager : MonoBehaviour {

    //BMIゲージ(slider)
    private Slider BMIgauge;

    //BMIゲージ色変更用
    private Image BMIImage;
    /*  緑#06FF83FF
        R = 6
        G = 255
        B = 131
        A = 255
    */
    /*
        黄#FFCD00FF
        R = 255
        G = 206
        B = 0
        A = 255
    */
    /*
        赤#FF0505FF
        R = 255
        G = 6
        B = 6
        A = 255
    */

        //Tゲージ(slider)
    private Slider Tgauge;

    //Tゲージレベル
    public GameObject tLevel2;
    public GameObject tLevel3;

    /*
        オレンジ#FFBA05FF
        R = 255
        G = 186
        B = 6
        A = 255
    */

    private int t = 33;

    private float bmi = 0;

    // Use this for initialization
    void Start () {
        //BMIゲージ(slider)を取得する
        BMIgauge = GameObject.Find("BMI").GetComponent<Slider>();

        //BMIゲージにあるFill(BMI)を取得する→バーの色を変えるため
        BMIImage = GameObject.Find("Fill(BMI)").GetComponent<Image>();

        //Tゲージ(slider)を取得する
        Tgauge = GameObject.Find("T").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update () {
        changeBMIgauge();
        changeTgauge();
	}

    //BMIゲージの色変更
    public void changeBMIgauge()
    {
        //デバッグ用ゲージ上昇・200で0になる
        bmi += 1.0f;
        if (bmi > 200)
        {
            bmi = 0;
        }

        //色変化
        if (bmi > 150)
        {
            //print("BMI > 150");
            //BMIImage.color = new Color(6, 255, 131, 255);
            BMIImage.color = Color.green;
        }
        else if (bmi > 18)
        {
            //print("BMI > 18");
            //BMIImage.color = new Color(255, 206, 0, 255);
            BMIImage.color = Color.yellow;
        }
        else if (bmi >= 0)
        {
            //print("BMI >= 0");
            //BMIImage.color = new Color(255, 6, 6, 255);
            BMIImage.color = Color.red;
        }

        //Valueにbmiをいれる
        BMIgauge.value = bmi;
    }

    //Tゲージ
    public void changeTgauge()
    {
        //デバッグ用Tゲージ上昇
        /*if (Input.GetMouseButton(0))
        {
            t++;
            //print("t: " + t);
        }
        if (Input.GetMouseButtonUp(0))
        {
            t = 33;
        }*/

        //Tゲージ量によりTレベルの表示非表示
        if(t > 65)
        {
            tLevel2.SetActive(true);
        }
        if(t > 98)
        {
            tLevel2.SetActive(true);
            tLevel3.SetActive(true);
        }
        if( t < 34)
        {
            tLevel2.SetActive(false);
            tLevel3.SetActive(false);
        }
        Tgauge.value = t;
    }
}
