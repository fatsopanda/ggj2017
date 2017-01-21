using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	[SerializeField] GameObject m_player1;
	[SerializeField] GameObject m_player2;
	//[SerializeField] PlayerController m_p1Controller;
	//[SerializeField] PlayerController m_p2Controller;
	[SerializeField] CameraController m_cameraController;
	[SerializeField] SpriteRenderer m_p1spriteRenderer;
	[SerializeField] Sprite m_p1currentSprite;
	[SerializeField] Sprite m_p1hitSprite;
	[SerializeField] SpriteRenderer m_p2spriteRenderer;
	[SerializeField] Sprite m_p2currentSprite;
	[SerializeField] Sprite m_p2hitSprite;

	public bool m_player1Hit;
	public bool m_player2Hit;
	public bool m_gameOver;
	public bool m_moshPitMode;
	public int m_player1Hp;
	public int m_player2Hp;

	void Start () {
		m_player1 = GameObject.Find ("Player1");
		m_player2 = GameObject.Find ("Player2");
		//m_p1Controller = m_player1.GetComponent<PlayerController> ();
		//m_p2Controller = m_player2.GetComponent<PlayerController> ();
		m_cameraController = Camera.main.GetComponent<CameraController> ();
		m_p1spriteRenderer = GameObject.Find("player 1 head").GetComponent<SpriteRenderer> ();
		m_p2spriteRenderer = GameObject.Find("player 2 head").GetComponent<SpriteRenderer> ();
		m_p1currentSprite = m_p1spriteRenderer.sprite;
		m_p2currentSprite = m_p2spriteRenderer.sprite;
		m_player1Hp = 3;
		m_player2Hp = 3;
		m_gameOver = false;
		m_moshPitMode = false;
	}
	
	void Update () {
		if (m_player1Hp <= 0)
			StartCoroutine (EndGame (2));
		if (m_player2Hp <= 0)
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

	IEnumerator FlashSprite(int player) {
		if (player == 1) {
			m_p1spriteRenderer.sprite = m_p1hitSprite;
			yield return new WaitForSeconds (0.5f);
			m_p1spriteRenderer.sprite = m_p1currentSprite;
			yield return new WaitForSeconds (0.5f);
			m_p1spriteRenderer.sprite = m_p1hitSprite;
			yield return new WaitForSeconds (0.5f);
			m_p1spriteRenderer.sprite = m_p1currentSprite;
			yield return new WaitForSeconds (0.5f);
			m_p1spriteRenderer.sprite = m_p1hitSprite;
			yield return new WaitForSeconds (0.5f);
			m_p1spriteRenderer.sprite = m_p1currentSprite;

		}

		if (player == 2) {
			m_p2spriteRenderer.sprite = m_p2hitSprite;
			yield return new WaitForSeconds (0.5f);
			m_p2spriteRenderer.sprite = m_p2currentSprite;
			yield return new WaitForSeconds (0.5f);
			m_p2spriteRenderer.sprite = m_p2hitSprite;
			yield return new WaitForSeconds (0.5f);
			m_p2spriteRenderer.sprite = m_p2currentSprite;
			yield return new WaitForSeconds (0.5f);
			m_p2spriteRenderer.sprite = m_p2hitSprite;
			yield return new WaitForSeconds (0.5f);
			m_p2spriteRenderer.sprite = m_p2currentSprite;
		}
	}

	IEnumerator PlayerHitEvent(int player) {
		m_cameraController.ScreenShake (2);
		StartCoroutine (FlashSprite(player));
		yield return new WaitForSeconds (2.0f);
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

		yield return new WaitForSeconds (1.0f);
		if (Input.GetKey (KeyCode.R))
			SceneManager.LoadScene (0);
			
	}

}
