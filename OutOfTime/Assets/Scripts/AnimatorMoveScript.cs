using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorMoveScript : MonoBehaviour
{
    Animator anim;
    int kickHash = Animator.StringToHash("RoundKick");

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void OnAnimatorMove()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", move);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger(kickHash);
        } 
    }
}
