using UnityEngine;
using System.Collections;

public class OpeningEnemy : MonoBehaviour {

    private GameObject debu;

    private Vector3 debuPos;

    private Vector3 distance;

    public float speed;

    Animator anim;

	// Use this for initialization
	IEnumerator Start () {
        debu = GameObject.Find("OpeningDebu");
        anim = GetComponent<Animator>();
        while (true)
        {
            debuPos = debu.transform.position;
            transform.LookAt(debuPos);
            distance = debuPos - transform.position;
            if (Vector3.Distance(transform.position, debuPos) > 3)
            {
                anim.SetBool("Move", true);
                transform.Translate(distance * Time.deltaTime * speed, Space.World);
            }
            else
            {
                anim.SetBool("Move", false);
                anim.SetTrigger("Attack");
                yield return new WaitForSeconds(1.5f);
            }
            yield return null;
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	
	}
}
