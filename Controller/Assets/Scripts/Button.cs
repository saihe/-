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
        int i = 0;
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                i++;
                if(i > 1)
                {
                    break;
                }
                print("hoge");
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
