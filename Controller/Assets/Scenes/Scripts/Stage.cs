using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour {

    //ポーズ中かどうか
    private bool pause;

    //ボス
    public GameObject Boss;

    //クリアかゲームオーバーか
    private bool clear;

    //プレイヤーBMI
    private float bmi;

    //BMIManagerコンポーネント
    private BMIManager bmiManager;

    public bool setPause(bool p)
    {
        pause = p;
        return pause;
    }

    public bool getPause()
    {
        return pause;
    }

	// Use this for initialization
	void Start () {
        bmiManager = FindObjectOfType<BMIManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        bmi = bmiManager.getBMI();
        toResult();
	}

    //リザルトシーンへ遷移
    void toResult()
    {
        //ボスを倒したら
        if (Boss.activeSelf == false)
        {
            clear = true;
            Application.LoadLevel("Result");
        }

        //BMIが0になったら
        if (bmi <= 0)
        {
            clear = false;
            Application.LoadLevel("Result");
        }
        else { }
    }

    public bool getResult()
    {
        return clear;
    }
}
