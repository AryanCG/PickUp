using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycasthittimg : MonoBehaviour {

	float Range = 100f;
	public Camera camera;
	private Rigidbody rb;
	private Collider c;
	public LayerMask mask;

	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.E))
        {
			position();
        }

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
