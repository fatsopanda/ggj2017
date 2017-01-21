using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField] GameObject m_player1;
	[SerializeField] GameObject m_player2;
	[SerializeField] PlayerController m_p1Controller;
	[SerializeField] PlayerController m_p2Controller;

	void Start () {
		m_player1 = GameObject.Find ("Player1");
		m_player2 = GameObject.Find ("Player2");
		m_p1Controller = m_player1.GetComponent<PlayerController> ();
		m_p2Controller = m_player2.GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
