using UnityEngine;
using System.Collections;

public class Motion : MonoBehaviour {

    private GameObject skillHundred;
    private GameObject skillHundredRound;
    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        //skillHundred = GameObject.Find("sibo_1/SkillHundred");
        //skillHundredRound = GameObject.Find("sibo_1/SkillHundred/SkillHundredRound");
        //print(skillHundredRound);
        //skillHundred.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("1"))
        {
            //StartCoroutine(SkillHundred());
        }
    }

    void OnGUI()
    {
    }
    public IEnumerator SkillHundred()
    {
        Vector3 shPos = skillHundredRound.transform.position;
        int i = 0;
        while (true)
        {
            i++;
            if (anim.GetBool("Skill") == false)
            {
                anim.SetBool("Skill", true);
                anim.SetTrigger("OnSkill");
            }
            skillHundred.SetActive(true);
            if(shPos.y > 0f && shPos.x < 2.5f)
            {
                print("true");
                skillHundredRound.SetActive(true);
            }
            else if(shPos.y < 0f)
            {
                print("false");
                skillHundredRound.SetActive(false);
            }
            skillHundredRound.transform.RotateAround(transform.position, new Vector3(0f, 10f, 0f), 5f);
            yield return new WaitForFixedUpdate();
            if (i >= 200)
            {
                print("i >= 50");
                anim.SetBool("Skill", false);
                anim.SetTrigger("OffSkill");
                skillHundred.SetActive(false);
                StopCoroutine(SkillHundred());
                yield break;
            }
        }
    }

}
