using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MO : MonoBehaviour
{
    public Transform target;
    public float speed;
    private Rigidbody playerRb;
    public float force;
    public Text back;
    public Text front;

   // public CharacterController playerCon;

   
   



    // Start is called before the first frame update
    void Start()
    {
        playerRb = this.GetComponent<Rigidbody>();
       // playerCon = this.GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
       


        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if (Input.GetKey(KeyCode.Space))
        {
          
                Jump();
           
            

        }
    }
    private void Jump()
    {
        if (playerRb && Mathf.Abs(playerRb.velocity.y) < 0.05f)
            playerRb.AddForce(0, force, 0, ForceMode.Impulse);
         //transform.Rotate(new Vector3(0f, 0.0f, -90f)*Time.fixedTime*2);
           // playerRb.transform.Rotate(180 * Vector3.forward, Space.World);
       
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trampa"))
        {
            SceneManager.LoadScene("Lvl1");
        }
        /*  if (other.gameObject.CompareTag("Velocidad7.5"))
          {
              speed = 7.5;
          }*/
        if (other.gameObject.CompareTag("Velocidad8"))
        {
            speed = 8;

        }
        if (other.gameObject.CompareTag("Velocidad13"))
        {
            speed = 13;

        }
        if (other.gameObject.CompareTag("Velocidad15"))
        {
            speed = 15;
        }
        if (other.gameObject.CompareTag("Velocidad30"))
        {
            speed = 30;
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            front.text = "WIN!";
            back.text = "WIN!";

        }

    }

}

