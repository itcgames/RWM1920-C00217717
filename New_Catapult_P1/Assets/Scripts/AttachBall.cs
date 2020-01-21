using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachBall : MonoBehaviour
{
    public SpringJoint2D springJoint;

    private GameObject Wheel1;
    private GameObject Wheel2;
    
    public float rotationScalar = 2;

    private void Awake()
    {

        Wheel1 = GameObject.Find("Wheel1");
        Wheel2 = GameObject.Find("Wheel2");

    }

    private void Update() {
    
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 pos = transform.position;
            pos.x += rotationScalar* .1f;
            transform.position = pos;

            Wheel1.transform.Rotate(Wheel1.transform.localRotation.x,Wheel1.transform.localRotation.y, Wheel1.transform.localRotation.z - rotationScalar, Space.Self);
            Wheel2.transform.Rotate(Wheel2.transform.localRotation.x,Wheel2.transform.localRotation.y, Wheel2.transform.localRotation.z - rotationScalar, Space.Self);
            Debug.Log("Drive Right");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
           
            Vector3 pos = transform.position;
            pos.x -= rotationScalar* .1f;
            transform.position = pos;

            Wheel1.transform.Rotate(Wheel1.transform.localRotation.x,Wheel1.transform.localRotation.y, Wheel1.transform.localRotation.z + rotationScalar, Space.Self);
            Wheel2.transform.Rotate(Wheel2.transform.localRotation.x,Wheel2.transform.localRotation.y, Wheel2.transform.localRotation.z + rotationScalar, Space.Self);
            Debug.Log("Drive Left");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ball")) // check the collision between player and pickups
        {
            springJoint.connectedBody = collision.GetComponent<Rigidbody2D>();

            Debug.Log("OntriggerEnter");
        }
    }
}
