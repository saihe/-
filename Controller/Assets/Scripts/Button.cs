using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Button : MonoBehaviour {

    
    public void OnGUI()
    {
        StartCoroutine(clickButton());
    }

    IEnumerator clickButton()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                print("hoge");
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
