using UnityEngine;
using System.Collections;

public class Hitefect : MonoBehaviour {
	private GameObject playerattackHit;
	private GameObject enemyAttackHit;
	private GameObject hitTmp;

	public void PlayerattackHit ()
	{
		Vector3 hit = new Vector3 (transform.position.x, -0.8f, transform.position.z-0.5f);
		Instantiate (playerattackHit, hit, playerattackHit.transform.rotation);
	}

	public void EnemyattackHit ()
	{
		Vector3 enemyHitPos = new Vector3 (transform.position.x, -0.8f, transform.position.z-0.5f);
		hitTmp = Instantiate (enemyAttackHit, enemyHitPos, enemyAttackHit.transform.rotation)as GameObject;
		Destroy (hitTmp,.3f);
	}
	// Use this for initialization
	void Start () {
        playerattackHit = Resources.Load<GameObject>("Effects/playerattackHit");
		enemyAttackHit = Resources.Load<GameObject>("Effects/enemyattackHit");
	}
}
