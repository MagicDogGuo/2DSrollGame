using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float JumpForce = 10;//insprctor出現欄位講解
    public float RayLength = 2;

    float speed = 20;
    Rigidbody rigidbody = null; //rigid參數講解
    bool isTouchGround = false;

    void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 180, 0.0f);
            this.transform.Translate(1 * speed * Time.deltaTime, 0.0f, 0.0f, Space.Self); //Time.deltaTime講解
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 0, 0.0f);
            this.transform.Translate(1 * speed * Time.deltaTime, 0.0f, 0.0f, Space.Self);

        }
        if (Input.GetKeyDown(KeyCode.W)&& isTouchGround)
        {
            rigidbody.AddForce(0, JumpForce, 0); //加入rigid compontent
        }

        RayHit(RayLength);
    }

    void RayHit(float rayLength)
    {
        Vector3 selfPos = this.transform.position;
        Vector3 rayDict = (new Vector3(0,-1, 0)); //Ray長度單位講解

        RaycastHit[] raycastHit = Physics.RaycastAll(selfPos, rayDict, rayLength); 
        Debug.DrawRay(selfPos, rayDict* rayLength, Color.red);

        isTouchGround = false;
        foreach (var item in raycastHit)
        {
            if (item.collider.tag == "ground")
            {
                isTouchGround = true;
            }
                   }
        Debug.Log(isTouchGround);

    }
}
