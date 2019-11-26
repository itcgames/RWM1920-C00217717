using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachBall : MonoBehaviour
{
    public SpringJoint2D springJoint;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ball")) // check the collision between player and pickups
        {
            springJoint.connectedBody = collision.GetComponent<Rigidbody2D>();

            Debug.Log("OntriggerEnter");
        }
    }
}
