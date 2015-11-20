using UnityEngine;
using System.Collections;
using GameSystems;

public class Title : MonoBehaviour {

    //シーンチェンジャー
    ScenChanger sc = new ScenChanger();

    //クリア情報
    ClearedStage cs = new ClearedStage();

    //オーディオ
    AudioSource audio;

    void Start()
    {
        i = 0;
        cs.defaultData();
        cs.getCleared();
        foreach(var val in cs.getClearedStages())
        {
            print(val);
        }
        audio = GetComponent<AudioSource>();
    }

    private int i = 0;
    void OnGUI()
    {
        if(i < 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                print(i);
                print("Touch");
                TapToStart();
                i++;
            }
        }
    }

    void TapToStart()
    {
        print(i);
        while (i < 300)
        {
            i++;
            if(i > 299)
            {
                break;
            }
        }
        print("End of Wait");
        i = 0;
        sc.toStageSelect();
        print("Break");
    }
}
