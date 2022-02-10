using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendTree : MonoBehaviour
{

    Animator anima;
    float velocity = 0.0f;
    [SerializeField] float acceleration = 0.1f;
    [SerializeField] float deceleration = 0.5f;
    int VelocityHash;

    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
        VelocityHash = Animator.StringToHash("Velocity");
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPress = Input.GetKey("w");
        bool runningPress = Input.GetKey("left shift");

        if (forwardPress && velocity < 1.0f)
        {
            velocity += Time.deltaTime * acceleration;
        }

        if (!forwardPress && velocity > 0.0f)
        {
            velocity -= Time.deltaTime * deceleration;
        }

        if (!forwardPress && velocity < 0.0f)
        {
            velocity = 0.0f;
        }

        anima.SetFloat(VelocityHash, velocity);

        if (forwardPress)
        {
            this.transform.Translate(new Vector3(0f, 0f, 4f) * velocity * Time.deltaTime);
        }
    }
}
