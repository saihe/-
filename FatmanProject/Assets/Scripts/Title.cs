using UnityEngine;
using System.Collections;
using GameSystems;

public class Title : MonoBehaviour {

    //シーンチェンジャー
    ScenChanger sc = new ScenChanger();

    //クリア情報
    ClearedStage cs = new ClearedStage();

    //オーディオ
    AudioSource audioSource;
    

    private int i = 0;

    void Start()
    {
        i = 0;
        cs.defaultData();
        cs.getCleared();
        foreach (var val in cs.getClearedStages())
        {
            print(val);
        }
        audioSource = GetComponent<AudioSource>();
    }
    void OnGUI()
    {
        if(i < 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                TapToStart();
                i++;
            }
        }
    }

    void TapToStart()
    {
        audioSource.PlayOneShot(audioSource.clip);
        while (i < 300)
        {
            i++;
            print("");
            if(i > 299)
            {
                i = 0;
                sc.toStageSelect();
                break;
            }
        }
    }
}
