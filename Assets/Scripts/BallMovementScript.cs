using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementScript : MonoBehaviour {

	[SerializeField] float m_speed;
	[SerializeField] float m_rightLimit = 10.50f;
	[SerializeField] float m_leftLimit = -10.50f;

	void Start () {
		m_rightLimit = 11.0f;
		m_leftLimit = -11.0f;
	}
	
	// Update is called once per frame
	void Update () {
		//if (gameObject.transform.position.x >= m_rightLimit)

		gameObject.transform.position = new Vector3 (Mathf.Lerp(gameObject.transform.position.x, m_leftLimit, 0.75f * Time.deltaTime), transform.position.y, 0.0f);

		/*if (gameObject.transform.position.x <= m_leftLimit)
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x + m_speed, transform.position.y, 0.0f);
		*/
	}
}
