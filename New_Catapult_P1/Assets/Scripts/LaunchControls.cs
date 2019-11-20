using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchControls : MonoBehaviour
{

    private Rigidbody2D armRB;
    private Vector2 initialPos;
    public Joint2D breakableJoint;

    public Joint2D editableJoint;
    public GameObject weight;



    // Start is called before the first frame update
    void Start()
    {
        initialPos = new Vector2(0, 4.5f);
        armRB = GetComponent<Rigidbody2D>();
        //armRB.centerOfMass = new Vector2(0.7f, .3f);

    }

    void ProcessEvents()
    {

    }

    void FixedUpdate()
    {
        transform.localPosition = initialPos;
        //armRB.centerOfMass = new Vector2(0.7f, .3f);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            armRB.transform.Rotate(0.0f, 0.0f, -2.0f);
        }

        ProcessEvents();
    }

    void OnTriggerEnter2D(Collider2D t_other)
    {
        if (t_other.CompareTag("TrebArm"))
        {
            Debug.Log("entered Collision");
            Destroy(breakableJoint);
        }
    }


}
