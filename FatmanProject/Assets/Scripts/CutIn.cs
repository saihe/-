using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CutIn : MonoBehaviour {

    public Sprite[] cutIn1 = new Sprite[4];

    public GameObject player;

    public GameObject camera;
	// Use this for initialization
	void Start () {
        transform.Rotate(new Vector3(45f, 0, 0));
        foreach (var val in cutIn1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = val;
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 5f, player.transform.position.z);
        //transform.LookAt(camera.transform);
	}
}
