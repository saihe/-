using UnityEngine;

public class LastShibo : MonoBehaviour
{
    Animator anim;

    // Update is called once per frame
    void Update()
    {
        anim = GetComponent<Animator>();
        anim.SetLayerWeight(5, 1);
    }
}
