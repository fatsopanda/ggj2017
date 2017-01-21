using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] Rigidbody2D m_rb2d;
	[SerializeField] GameManager m_gameManager;
	[SerializeField] float m_movSpeed;
	[SerializeField] float m_acc;
	[SerializeField] float m_jumpSpeed;
	[SerializeField] float m_rotation;
	[SerializeField] bool m_jumped;
	[SerializeField] int m_playerNumber;

	void Start () {
		m_rb2d = GetComponent<Rigidbody2D> ();
		m_gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		m_jumped = false;
	}

	void Update () {

		if (m_playerNumber == 1 && !m_gameManager.m_gameOver) {
			m_movSpeed = Input.GetAxisRaw ("Player1_Horizontal") * m_acc;

			if (Input.GetAxisRaw ("Player1_Horizontal") < 0) {
				m_rotation -= 0.25f;
				gameObject.transform.Rotate (0.0f, 0.0f, m_rotation);
			}

			if (Input.GetAxisRaw ("Player1_Horizontal") > 0) {
				m_rotation += 0.25f;
				gameObject.transform.Rotate (0.0f, 0.0f, m_rotation);
			}

			if (Input.GetAxisRaw ("Player1_Horizontal") == 0)
				m_rotation = 0.0f;

			if (m_rotation >= 1.0f)
				m_rotation = 1.0f;

			if (m_rotation <= -1.0f)
				m_rotation = -1.0f;


			if (Input.GetKeyDown (KeyCode.UpArrow) && !m_jumped) {
				m_rb2d.velocity = new Vector2 (m_rb2d.velocity.x, m_jumpSpeed);
				m_jumped = true;
			}
		}

		if (m_playerNumber == 2 && !m_gameManager.m_gameOver) {
			m_movSpeed = Input.GetAxisRaw ("Player2_Horizontal") * m_acc;

			if (Input.GetAxisRaw ("Player2_Horizontal") < 0) {
				m_rotation -= 0.25f;
				gameObject.transform.Rotate (0.0f, 0.0f, m_rotation);
			}

			if (Input.GetAxisRaw ("Player2_Horizontal") > 0) {
				m_rotation += 0.25f;
				gameObject.transform.Rotate (0.0f, 0.0f, m_rotation);
			}

			if (Input.GetAxisRaw ("Player2_Horizontal") == 0)
				m_rotation = 0.0f;

			if (m_rotation >= 1.0f)
				m_rotation = 1.0f;

			if (m_rotation <= -1.0f)
				m_rotation = -1.0f;


			if (Input.GetKeyDown (KeyCode.W) && !m_jumped) {
				m_rb2d.velocity = new Vector2 (m_rb2d.velocity.x, m_jumpSpeed);
				m_jumped = true;
			}
		}

		m_rb2d.velocity = new Vector2 (m_movSpeed, m_rb2d.velocity.y);

	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "crowd")
			m_jumped = false;
	}


}