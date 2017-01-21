using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField] GameObject m_player1;
	[SerializeField] GameObject m_player2;
	[SerializeField] PlayerController m_p1Controller;
	[SerializeField] PlayerController m_p2Controller;

	public bool m_player1Hit;
	public bool m_player2Hit;
	public bool m_gameOver;
	public int m_player1Hp;
	public int m_player2Hp;

	void Start () {
		m_player1 = GameObject.Find ("Player1");
		m_player2 = GameObject.Find ("Player2");
		m_p1Controller = m_player1.GetComponent<PlayerController> ();
		m_p2Controller = m_player2.GetComponent<PlayerController> ();
		m_player1Hp = 3;
		m_player2Hp = 3;
		m_gameOver = false;
	}
	
	void Update () {
		if (m_player1Hp <= 0)
			StartCoroutine (EndGame (2));
		if (m_player1Hp <= 0)
			StartCoroutine (EndGame (1));
	}

	public void PlayerHit(int player) {
		if (player == 1) {
			m_player1Hit = true;
			m_player1Hp--;
		}
		if (player == 2) {
			m_player2Hit = true;
			m_player2Hp--;
		}
		StartCoroutine (PlayerHitEvent(player));
	}

	IEnumerator PlayerHitEvent(int player) {
		yield return new WaitForSeconds (1.0f);
		if (player == 1)
			m_player1Hit = false;
		if (player == 2)
			m_player2Hit = false;
	}

	IEnumerator EndGame(int player) {
		m_gameOver = true;

		if (player == 1) {
			Debug.Log ("Player 1 won!");
			
		}
		if (player == 2) {
			Debug.Log ("Player 2 won!");
		}

		yield return new WaitForSeconds (5.0f);
	}
}
