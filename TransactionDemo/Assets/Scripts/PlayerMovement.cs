using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    Rigidbody rb;
    float rot;
    public bool inTrade;
    public float forward;
    public float tradeDistance;
    float rotSpeed = 3;
    public float speed = 5;
    ConstantForce maxspeed;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        inTrade = false;
	}
	void CheckInput()
    {
        
        rot = Input.GetAxis("Horizontal") * rotSpeed;
        forward = Input.GetAxis("Vertical") * speed;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Tradable" && Vector3.Distance(transform.position, hit.transform.position) <= tradeDistance)
                {
                    inTrade = true;
                    GameObject.Find("TransactionScreen").GetComponent<TransactionHandler>().startTrade(hit.transform.gameObject);
                }
            }
            
        }
        
    }
    private void Move()
    {
        rb.velocity = (transform.forward * forward);
        transform.Rotate(0f, rot, 0f);
    }
    // Update is called once per frame
    void Update () {
        CheckInput();
        if (!inTrade)
        {
            Move();
            //rb.velocity = Vector3.zero;
        }
        maxspeed = (gameObject.GetComponent<ConstantForce>());
        //Debug.Log(maxspeed);

	}
}
