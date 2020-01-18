using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LaunchControls : MonoBehaviour
{
    public GameObject fullTreb;
    private Rigidbody2D armRB;
    private Vector2 initialPos;
    public Joint2D breakableJoint;

    public AudioSource creakSound;
    public AudioSource launchSound;
    

    public Text m_infoText;
    public Text instructions;

    public GameObject weight;

    bool isrotating = false;
    float rotation = 0;
    float WeigthForce = 0;


    //Setup variables For Trebuchet Reset;
    float resetWeight;
    Vector3 resetPosition;
    float resetRotation;
        

    // Start is called before the first frame update
    void Start()
    {
        initialPos = new Vector2(0, 4.5f);
        armRB = GetComponent<Rigidbody2D>();
        armRB.centerOfMass = new Vector2(0.7f, .3f);

        WeigthForce = weight.GetComponent<Rigidbody2D>().mass * 0.001f;

        resetPosition = fullTreb.transform.position;
        resetRotation = armRB.transform.localRotation.z;
        resetWeight = weight.GetComponent<Rigidbody2D>().mass;
        instructions.text = "";
        m_infoText.text = "";

    }

    private void Reset()
    {
        fullTreb.transform.position = resetPosition ;
        armRB.transform.localRotation = Quaternion.Euler(0,0,37f);
    }

    void ProcessEvents()
    {

         if (Input.GetKey(KeyCode.Period))
        {
            ChangeHeight(-2);
            Debug.Log("rotation: " +  armRB.transform.localRotation.z.ToString());
            creakSound.Play();
        }

         if (Input.GetKey(KeyCode.Comma))
        {
            
            ChangeHeight(2);
         Debug.Log("rotation: " +  armRB.transform.localRotation.z.ToString());
         creakSound.Play();
        }
        
        if (Input.GetKeyUp(KeyCode.PageUp))
        {
            ChangeWeight(1);
            
        }
       
        if (Input.GetKeyUp(KeyCode.PageDown))
        {
           ChangeWeight(-1);
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
           isrotating = true;
            
        }
    
    }
    

    void FixedUpdate()
    {
        transform.localPosition = initialPos;

        if (breakableJoint.connectedBody != null)
        {
            if (isrotating)
        {
            StartCoroutine(autoRotateArm());
        }
        ProcessEvents();
            m_infoText.text = "Launch Arm Angle: " + (armRB.transform.localRotation.z * 100).ToString() + "\nLaunch Force: " + weight.GetComponent<Rigidbody2D>().mass.ToString();
            instructions.text = "Lower Launch Height: ' , ' Key \nRaise Launch Height: '.' Key \nIncrease Launch Force: ' PG UP ' \nDecrease Launch Force: ' PG DN' \nLaunch Catapult : SPACE";
        }
        else
        {
            instructions.text = "";
            m_infoText.text = "";
        }
       
    }

    void ChangeWeight(int t_changeVal)
    {
        Debug.Log("change Weight");
        weight.GetComponent<Rigidbody2D>().mass += t_changeVal;
        WeigthForce = weight.GetComponent<Rigidbody2D>().mass * 0.001f;
    }

    void ChangeHeight(int t_changeVal)
    {
        Debug.Log("change Weight");

        if (armRB.transform.rotation.z >= 0f && armRB.transform.rotation.z <= 0.8f)
        {
            armRB.transform.Rotate(0.0f, 0.0f, t_changeVal);
             
             if(armRB.transform.rotation.z >= 0.7f)
             {
                 Debug.Log("Hit Limit");
                 armRB.transform.rotation = Quaternion.Euler( 0,0, 60f);
             }
             if(armRB.transform.rotation.z <= 0f)
             {
                 Debug.Log("Hit Limit");
                 armRB.transform.rotation = Quaternion.Euler( 0,0, 22f);
             }
        }
    }
    IEnumerator autoRotateArm()
    {

        rotation = armRB.transform.localRotation.z;

        while (armRB.transform.rotation.z >= -0.86f && isrotating)
        {
             armRB.transform.Rotate(0.0f, 0.0f, -WeigthForce);
            yield return null;
        }

        if (armRB.transform.rotation.z <= -0.86f)
        {
            Reset();
            isrotating = false;
            yield break;
        }
         
         //armRB.transform.rotation = Quaternion.Euler(0, 0, 180);
         yield return null;
}

    void OnTriggerEnter2D(Collider2D t_other)
    {
        //if (t_other.CompareTag("TrebArm"))
        {
            rotation = armRB.transform.localRotation.z;
            Debug.Log("rotation: " + rotation.ToString());
            Debug.Log("entered Collision");
            launchSound.Play();
            breakableJoint.connectedBody = null;
        }
    }


}
