using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementScript : MonoBehaviour {

	[SerializeField] float m_speed;
	[SerializeField] float m_rightLimit;
	[SerializeField] float m_leftLimit;
	[SerializeField] bool m_movingLeft;

	void Start () {
		m_rightLimit = 20.0f;
		m_leftLimit = -20.0f;
		if (gameObject.name == "BigAssBall1")
			m_movingLeft = true;
		else
			m_movingLeft = false;
	}
	
	void Update () {
		if (m_movingLeft)
			gameObject.transform.position = new Vector3 (Mathf.Lerp(gameObject.transform.position.x, m_leftLimit, 0.75f * Time.deltaTime), transform.position.y, 0.0f);

		if (!m_movingLeft)
			gameObject.transform.position = new Vector3 (Mathf.Lerp(gameObject.transform.position.x, m_rightLimit, 0.75f * Time.deltaTime), transform.position.y, 0.0f);

		if (gameObject.transform.position.x <= m_leftLimit + 2.0f)
			m_movingLeft = false;

		if (gameObject.transform.position.x >= m_rightLimit - 2.0f)
			m_movingLeft = true;
	}
}
