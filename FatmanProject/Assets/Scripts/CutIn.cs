using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class CutIn : MonoBehaviour {

    List<Sprite[]> list = new List<Sprite[]>();
    private Sprite[] cutIn1 = new Sprite[4];
    private Sprite[] cutIn2 = new Sprite[4];
    private Sprite[] cutIn3 = new Sprite[4];
    private Texture2D[] hoge3 = new Texture2D[4];

    private bool b;

    int cut = 0;

    // Use this for initialization
    void Start () {

        for (int j = 0; j < 4; j++)
        {
            cutIn1 = Resources.LoadAll<Sprite>("CutIn/Skill1");
            cutIn2 = Resources.LoadAll<Sprite>("CutIn/Skill2");
            cutIn3 = Resources.LoadAll<Sprite>("CutIn/Skill3");
            list.Add(cutIn1);
            list.Add(cutIn2);
            list.Add(cutIn3);
        }
        //StartCoroutine(CutInAnimatation(transform.gameObject.name));
        foreach (var val in list[0])
        {
            print(val);
        } 
    }

    // Update is called once per frame
    void Update () {
        StartCoroutine(CutInAnimatation(transform.gameObject.name));
        print(transform.gameObject.name);
    }

    IEnumerator CutInAnimatation(string name)
    {
        b = true;
        print("CutInAnimation");

        switch (name)
        {
            case "CutIn1":
                cut = 0;
                break;
            case "CutIn2":
                cut = 1;
                break;
            case "CutIn3":
                cut = 2;
                break;
        }

        while (true)
        {
            foreach (var val in list[cut])
            {
                yield return new WaitForSeconds(1.0f);
                gameObject.GetComponent<Image>().sprite = val;
                print("Sprite: " + val);
                if (b == false)
                {
                    print("Col b == false");
                    yield break;
                }
            }
            yield return new WaitForSeconds(3.0f);
        }
        //yield return null;
    }

    void OnDisable()
    {
        b = false;
        //print("b == false");
    }
}
