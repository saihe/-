using UnityEngine;
using System.Collections;
using GameSystems;

public class FollowPlayer : MonoBehaviour
{
	private GameObject target;    // ターゲットへの参照
	private Vector3 offset;     // 相対座標
    State state = new State();

    void Start ()
	{
        target = GameObject.FindGameObjectWithTag("Player");
		//自分自身とtargetとの相対距離を求める
		offset = transform.position - target.transform.position;
	}
	
	void Update ()
	{
        if(state.getState() == GameState.Playing)
		// 自分自身の座標に、targetの座標に相対座標を足した値を設定する
		transform.position = (target.transform.position + offset);
	}
}