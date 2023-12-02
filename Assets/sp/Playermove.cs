using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Playermove : MonoBehaviour
{
    public float speed = 5;
    public float jumphigh = 5;
    public Rigidbody rd;
    public bool isground = true;
    public Slider s;

    public Animator ani;


    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    void Update() 
    {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        
        if(isground == false) 
        {
            ani.SetInteger("Status", 2);
        }
        else if (h != 0 || v != 0)
        {
            ani.SetInteger("Status", 1);
        }
        else
        {
            ani.SetInteger("Status", 0);
        }

        if (h>0)
        {
            ani.SetInteger("facing", 1);
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (h<0)
        {
            ani.SetInteger("facing", 3);
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (v>0)
        {
            ani.SetInteger("facing", 0);
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if (v<0)
        {
            ani.SetInteger("facing", 2);
            transform.position += Vector3.back * speed * Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && isground ==true) {
            rd.AddForce(new Vector3(0,jumphigh,0), ForceMode.Impulse);
            isground = false;
        }

        if (Input.GetKey("r"))
        {
            transform.position = new Vector3(7.17f, 12.79f,12.7f);
        }

        if (Input.GetKey("v"))
        {
            //.gameObject.setActive(false);
        }

        if (Input.GetKey("b"))
        {
            //FollowTarget_j.gameObject.setActive(false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isground = true;
        }
        
    }

    public void ChangeSpeed(float CSpeed)
    {
        this.speed = CSpeed;
        s.value = CSpeed;
        this.jumphigh = CSpeed;
    }

    public void ChangeJump(float CJump)
    {
        this.jumphigh = CJump;
    }
}

