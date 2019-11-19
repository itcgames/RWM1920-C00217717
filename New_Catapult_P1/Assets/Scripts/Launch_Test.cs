using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch_Test : MonoBehaviour
{

    private Rigidbody2D armRB;
    private Vector2 initialPos;
    private SpringJoint2D springArm;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        armRB = GetComponent<Rigidbody2D>();
        springArm = GetComponent<SpringJoint2D>();
    }

    void FixedUpdate()
    {
        transform.position = initialPos;
        if(Input.GetKey(KeyCode.RightArrow))
        {
            armRB.transform.Rotate(0.0f,0.0f, -2.0f);
        }
    }

    void OnTriggerEnter2D(Collider2D t_other)
    {
        Debug.Log("entered Collision");
        Destroy(springArm);
    
    }

}
