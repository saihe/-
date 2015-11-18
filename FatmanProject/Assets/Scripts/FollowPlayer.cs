using UnityEngine;
using System.Collections;
using GameSystems;

public class FollowPlayer : MonoBehaviour
{
	private GameObject target;    // ターゲットへの参照
    private Vector3 defaultPosition;
	private Vector3 offset;     // 相対座標
    State state = new State();

    IEnumerator Start ()
	{
        defaultPosition = transform.position;
        while (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            //自分自身とtargetとの相対距離を求める
            if (target != null)
            {
                offset = defaultPosition - target.transform.position;
                yield break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
	
	void Update ()
	{
        if(target != null)
        {
            if (state.getState() == GameState.Playing)
            {
                // 自分自身の座標に、targetの座標に相対座標を足した値を設定する
                transform.position = (target.transform.position + offset);
            }
        }
    }
}