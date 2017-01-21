using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollision : MonoBehaviour {

	/* 
		Hit Detection script on head. Player hands have triggers and in case the head's collider enter's the hands trigger
		Do a Hit event on player to reduce HP etc.
	*/

	[SerializeField] int m_playerNumber;
	[SerializeField] GameManager m_gameManager;

	void Start() {
		m_gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		// If we're player 1 and get hit by player2's hand
		if (m_playerNumber == 1 && col.tag == "player2_hand") {
			if (!m_gameManager.m_player1Hit) {
				m_gameManager.PlayerHit (1);
				Debug.Log ("Player1 got hit!");
			}
		}
		
		// If we're player 2 and get hit by player1's hand
		if (m_playerNumber == 2 && col.tag == "player2_hand") {
			if (col.tag == "player1_hand") {
				if (!m_gameManager.m_player2Hit) {
					m_gameManager.PlayerHit (2);
					Debug.Log ("Player2 got hit!");
				}
			}
		}
	}
}