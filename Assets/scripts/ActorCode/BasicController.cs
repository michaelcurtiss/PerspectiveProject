using UnityEngine;
using System.Collections;

public class BasicController : MonoBehaviour {


	public float moveSpeed = 5;
	
	private Rigidbody2D rb2D;
	private Vector2 moveVector;

	// Use this for initialization
	void Awake () {
		rb2D = transform.GetComponent<Rigidbody2D>();
	}
	
	// called once per physics step
	void FixedUpdate(){
		Vector2 desiredPosition = (moveVector*Time.fixedDeltaTime)*moveSpeed;
		rb2D.MovePosition( rb2D.position + desiredPosition);
	}

	// Update is called once per frame
	void Update () {
		CheckInput();
	}

	public void Stop(){
		rb2D.velocity = Vector2.zero;
	}

	void CheckInput(){

		moveVector = Vector2.zero;

	    if(Input.GetKey(KeyCode.W))
	    {
	       	moveVector.y = 1;
	    }
	    if(Input.GetKey(KeyCode.S))
	    {
			moveVector.y = -1;	       
	    }
	     if(Input.GetKey(KeyCode.A))
	    {
	        moveVector.x = -1;
	    }
	     if(Input.GetKey(KeyCode.D))
	    {
	        moveVector.x = 1;
	    }
	}
}
