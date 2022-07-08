using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {
	 //Note all these variables are explained
	float Range = 100f;
	//you have to drop you fps cam in the variable
	public Camera camera;
	private Rigidbody rb;
	private Collider c;
	//make a layer mask that is Pickup layer name it
	public LayerMask mask;
	//create the Hand GameObject in you fps player 
	//note Hand should be parent of fpsplayer
	//note GameObject that you have to pickup should be in PickUp layer that you created
	public GameObject hand;
	//note the gameobject you are going to pick up should have rigidbody

	
	// Update is called once per frame
	void Update () {

		//PickUp item with the E on keyboard
		
		if (Input.GetKeyDown(KeyCode.E))
        {
			position();
        }

		//to drop the game object
		if (Input.GetKeyDown(KeyCode.R))
        {
			rb.isKinematic = false;
			c.isTrigger = false;
			rb.transform.parent = null;
			
		}
		
	}

	void position()
    {
		RaycastHit hit;
		//ejecting ray from fps camera
		if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit , Range , mask ) )
        {
			rb = hit.rigidbody;
			c = hit.collider;

			rb.isKinematic = true;
			c.isTrigger = true;

			rb.transform.position = hand.transform.position;
			rb.transform.parent = hand.transform;

			
        }
	}
}
