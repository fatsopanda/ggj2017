using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] Rigidbody2D m_rb2d;
	[SerializeField] float m_movSpeed;
	[SerializeField] float m_acc;
	[SerializeField] float m_jumpSpeed;
	[SerializeField] float m_rotation;
	[SerializeField] bool m_jumped;

	void Start () {
		m_rb2d = GetComponent<Rigidbody2D> ();
		m_jumped = false;
	}
	
	// Update is called once per frame
	void Update () {
		m_movSpeed = Input.GetAxisRaw ("Horizontal") * m_acc;

		if (Input.GetAxisRaw ("Horizontal") < 0) {
			m_rotation -= 0.25f;
			gameObject.transform.Rotate(0.0f, 0.0f, m_rotation);
		}

		if (Input.GetAxisRaw ("Horizontal") > 0) {
			m_rotation += 0.25f;
			gameObject.transform.Rotate(0.0f, 0.0f, m_rotation);
		}

		if (Input.GetAxisRaw ("Horizontal") == 0)
			m_rotation = 0.0f;

		if (m_rotation >= 1.0f)
			m_rotation = 1.0f;

		if (m_rotation <= -1.0f)
			m_rotation = -1.0f;

		m_rb2d.velocity = new Vector2 (m_movSpeed, m_rb2d.velocity.y);

		if (Input.GetKeyDown (KeyCode.Space) && !m_jumped) {
			m_rb2d.velocity = new Vector2 (m_rb2d.velocity.x, m_jumpSpeed);
			m_jumped = true;
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "crowd")
			m_jumped = false;
	}

}
