using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    Animator anima;
    int isWalkingHash = Animator.StringToHash("isWalking");
    int isRunningHash = Animator.StringToHash("isRunning");

    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = anima.GetBool(isWalkingHash);
        bool isRunning = anima.GetBool(isRunningHash);
        bool forWardPressed = Input.GetKey("w");
        bool runningPressed = Input.GetKey("left shift");

        //W key pressed start walk
        if (!isWalking && forWardPressed)
        {
            anima.SetBool(isWalkingHash,true);
        }

        //W Key relesed stop walk
        if (isWalking && !forWardPressed)
        {
            anima.SetBool(isWalkingHash ,false);
        }

        if (!isRunning && (forWardPressed && runningPressed))
        {
            anima.SetBool (isRunningHash,true);
        }

        if (isRunning && (!forWardPressed || !runningPressed))
        {
            anima.SetBool(isRunningHash ,false);
        }
    }
}
