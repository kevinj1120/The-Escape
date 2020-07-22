using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherMovementScript : MonoBehaviour
{
    public float speed;
    public bool playerIsOnTheGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && gameObject.transform.position.x > -4)
        {
            float horizontal = transform.position.x -speed * Time.deltaTime; 
            Mathf.Clamp(horizontal, -4, 0);
            GetComponent<Transform>().position = new Vector3(horizontal, transform.position.y, transform.position.z);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && gameObject.transform.position.x < 0)
        {
            float horizontal = transform.position.x + speed * Time.deltaTime;
            Mathf.Clamp(horizontal, -4, 0);
            GetComponent<Transform>().position = new Vector3(horizontal, transform.position.y, transform.position.z);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            GetComponent<Transform>().position += new Vector3(0, 0, speed) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<Transform>().position -= new Vector3(0, 0, speed) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space) && playerIsOnTheGround)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            playerIsOnTheGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            playerIsOnTheGround = false;
    }
}

