using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public void OnGUI()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("pause");
            Time.timeScale = 0;
        }
        if (Input.GetMouseButtonUp(0))
        {
            print("start");
            Time.timeScale = 0;
        }
    }

}
