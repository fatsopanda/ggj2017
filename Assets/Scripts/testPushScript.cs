using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPushScript : MonoBehaviour {

	[SerializeField] Rigidbody2D m_rb2d;
	[SerializeField] float jumpForce;
	[SerializeField] GamePhysics m_physics;

	void RandomizeJumpForce() {
		jumpForce = m_physics.jumpForce / Random.Range (1.2f, 3.5f);
	}


	void Start () {
		m_rb2d = GetComponent<Rigidbody2D>();
		m_physics = GameObject.Find ("GamePhysics").GetComponent<GamePhysics> ();
		RandomizeJumpForce ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A)) {
			m_rb2d.velocity = new Vector2 (0.0f, jumpForce);
			RandomizeJumpForce ();
		}
	}
}
