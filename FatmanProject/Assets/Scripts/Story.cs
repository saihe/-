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
        text = storyText.GetComponent<Text>();
        story[0] = "いじめを受けていた四坊英雄は不思議なベルトを拾うことによりヒーローへと変身した。\n自分を苦しめたいじめをなくすため、いじめっこたちを更正させる戦いが今始まる。	";
        story[1] = "いじめっこの取り巻きたちを倒した四坊英雄は、各クラスでいじめを発生させている主犯を更正させようと次の戦いに挑むのであった。";
        story[2] = "各クラスに配備されていたいじめっこ委員会メンバーを更生させ、残すは委員会本部のみとなった。\nついにいじめの確信へと迫る四坊英雄。いじめをめぐる四坊英雄の戦いが終焉を迎える。";

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
