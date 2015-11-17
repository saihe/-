using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GameSystems;

public class Story : MonoBehaviour {

    ScenChanger sc = new ScenChanger();

    private GameObject storyPanel;

    private GameObject storyText;

    Text text;

    string[] story = new string[3];

	// Use this for initialization
	void Start () {
        storyPanel = transform.GetChild(1).gameObject;
        storyText = storyPanel.transform.GetChild(0).gameObject;
        print(storyPanel);
        text = storyText.GetComponent<Text>();
        story[0] = "いじめを受けていた四坊英雄は不思議なベルトを拾うことによりヒーローへと変身した。\n自分を苦しめたいじめをなくすため、いじめっこたちを更正させる戦いが今始まる。	";
        story[1] = "いじめっこの取り巻きたちを倒した四坊英雄は、いじめの主犯である大将を更正させようと次の戦いに挑むのであった。";
        story[2] = "いじめっこの主犯を更正させた。これでいじめはなくなる。\nはずであったが、四坊の周りで起こっているいじめには黒幕がいた、その名もいじめっこ委員会。\n四坊英雄は真にいじめをなくすため、いじめっこ委員会へと乗り込むのであった。";

        switch (sc.getStageName())
        {
            case StageName.Stage1:
                text.text = story[0];
                break;
            case StageName.Stage2:
                text.text = story[1];
                break;
            case StageName.Stage3:
                text.text = story[2];
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
