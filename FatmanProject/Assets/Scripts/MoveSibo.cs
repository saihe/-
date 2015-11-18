using UnityEngine;
using System.Collections;

public class MoveSibo : MonoBehaviour {
	private Vector3 startPos;
	private Quaternion startRot;
	public GameObject camera ;
	Animator anim;
	private int rndNum ;
	
	void Start () {
		anim = GetComponent<Animator>();
		anim.SetLayerWeight(6, 1);

		startPos = transform.position;
		startRot = transform.rotation;

		StartCoroutine ("SiboPattern");
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	private IEnumerator SiboPattern(){
		while (true) {
			transform.position += new Vector3 (0.015f, 0.0f, 0.0f);

			if (transform.position.x > 3.5f) {
				transform.position = startPos;	
			}

			if (transform.position.x >= -0.01f && transform.position.x <= 0.01f) {
				transform.LookAt (camera.transform);

				anim.SetBool("Move", false);
				anim.SetBool("TFiP" , true);
				yield return new WaitForSeconds(1f);

				//ランダムでアクション変化
				rndNum = Random.Range (1, 3 + 1);
				switch (rndNum) {
				case 1:
					anim.SetInteger("StateNum",1);
					break;
				case 2:
					anim.SetInteger("StateNum",2);
					break;
				case 3:
					anim.SetInteger("StateNum",3);		
					break;
				}
				anim.SetBool("TFiP" , false);
				yield return new WaitForSeconds(1f);
				anim.SetTrigger("OffSkill");
				yield return new WaitForSeconds(0.8f);
				transform.rotation = startRot;
				anim.SetBool("Move", true);
				anim.SetInteger("StateNum",0);
			}
			yield return new WaitForEndOfFrame();
		}
		yield break;
	}
}