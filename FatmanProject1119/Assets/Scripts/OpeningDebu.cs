using UnityEngine;
using System.Collections;

public class OpeningDebu : MonoBehaviour {

    Vector3 standUp;

    Vector3 turn;

    Vector3 goHome;

    public GameObject target;

    // Use this for initialization
    IEnumerator Start () {
        standUp = new Vector3(0, 0, -10);
        while (true)
        {
            transform.Rotate(standUp * Time.deltaTime * 17, Space.World);
            yield return new WaitForSeconds(0.1f);
            if (transform.eulerAngles.x > 356f)
            {
                transform.eulerAngles = new Vector3(0, 90, 0);
                yield return new WaitForSeconds(1.0f);
                transform.eulerAngles = new Vector3(0, 250, 0);
                StartCoroutine(hoge());
                yield break;
            }

        }
    }

    IEnumerator hoge()
    {
        turn = new Vector3(0, 10, 0);
        while (true)
        {
            if (transform.eulerAngles.y < 280f)
            {
                transform.Rotate(turn * Time.deltaTime * 30, Space.World);
            yield return new WaitForSeconds(0.1f);
            }
            else if(transform.eulerAngles.y > 280f)
            {
                transform.eulerAngles = new Vector3(0, 280, 0);
                goHome = target.transform.position - transform.position;
                StartCoroutine(GoHome());
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator GoHome()
    {
        while (true)
        {
            transform.Translate(goHome * Time.deltaTime / 5);
            yield return new WaitForSeconds(0.1f);
        }
    }

    // Update is called once per frame
    void Update () {

    }
}
