using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

	[SerializeField] GameObject m_bigAssBall1;
	[SerializeField] GameObject m_bigAssBall2;

	// UI stuff
	[SerializeField] GameObject m_gamePanel;
	[SerializeField] Image[] m_P1HP;
	[SerializeField] Image[] m_P2HP;

	[SerializeField] Vector3 m_p1StartPos;
	[SerializeField] Vector3 m_p2StartPos;

	public bool m_player1Hit;
	public bool m_player2Hit;
	public bool m_gameOver;
	public bool m_moshPitMode;
	public int m_player1Hp;
	public int m_player2Hp;

	void Start () {
		// Players and camera objects
		m_player1 = GameObject.Find ("Player1");
		m_player2 = GameObject.Find ("Player2");
		//m_p1Controller = m_player1.GetComponent<PlayerController> ();
		//m_p2Controller = m_player2.GetComponent<PlayerController> ();
		m_cameraController = Camera.main.GetComponent<CameraController> ();

		// Flashing head sprite
		m_p1spriteRenderer = GameObject.Find("player 1 head").GetComponent<SpriteRenderer> ();
		m_p2spriteRenderer = GameObject.Find("player 2 head").GetComponent<SpriteRenderer> ();
		m_p1currentSprite = m_p1spriteRenderer.sprite;
		m_p2currentSprite = m_p2spriteRenderer.sprite;

		// Some basic stuff
		m_player1Hp = 3;
		m_player2Hp = 3;
		m_gameOver = false;
		m_moshPitMode = false;

		// GameObjects
		m_bigAssBall1 = GameObject.Find("BigAssBall1");
		m_bigAssBall2 = GameObject.Find ("BigAssBall2");

		// UI
		m_gamePanel = GameObject.Find ("GamePanel");
		m_P1HP = new Image[m_player1Hp];
		m_P2HP = new Image[m_player2Hp];

		m_P1HP [0] = GameObject.Find ("P1HP1").GetComponent<Image>();
		m_P1HP [1] = GameObject.Find ("P1HP2").GetComponent<Image>();
		m_P1HP [2] = GameObject.Find ("P1HP3").GetComponent<Image>();

		m_P2HP [0] = GameObject.Find ("P2HP1").GetComponent<Image>();
		m_P2HP [1] = GameObject.Find ("P2HP2").GetComponent<Image>();
		m_P2HP [2] = GameObject.Find ("P2HP3").GetComponent<Image>();

		m_p1StartPos = m_player1.transform.position;
		m_p2StartPos = m_player2.transform.position;

		// The beginning situation
		m_gamePanel.SetActive (false);
		m_bigAssBall1.SetActive (false);
		m_bigAssBall2.SetActive (false);
		m_player1.SetActive (false);
		m_player2.SetActive (false);
	}
	
	void Update () {
		if (m_player1Hp <= 0)
			StartCoroutine (EndGame (2));
		if (m_player2Hp <= 0)
			StartCoroutine (EndGame (1));
	}

	public void StartGame() {
		m_player1Hp = 3;
		m_player2Hp = 3;

		// Enable game play stuff
		m_gamePanel.SetActive (true);
		for (int i = 0; i < m_P1HP.Length; i++) {
			m_P1HP [i].enabled = true;
			m_P2HP [i].enabled = true;
		}
		m_bigAssBall1.SetActive (true);
		m_bigAssBall2.SetActive (true);

		if (!m_player1.activeInHierarchy)
			m_player1.SetActive (true);
		if(!m_player2.activeInHierarchy)
			m_player2.SetActive (true);

		if (m_gameOver)
			m_gameOver = false;

		m_player1.transform.position = m_p1StartPos;
		m_player2.transform.position = m_p2StartPos;
	}

	public void PlayerHit(int player) {
		if (!m_gameOver) {
			if (player == 1) {
				m_player1Hit = true;
				m_player1Hp--;
			}
			if (player == 2) {
				m_player2Hit = true;
				m_player2Hp--;
			}

			if (m_player2Hp == 2)
				m_P2HP[2].enabled = false;

			if (m_player2Hp == 1)
				m_P2HP[1].enabled = false;

			if (m_player2Hp <= 0)
				m_P2HP[0].enabled = false;

			if (m_player1Hp == 2)
				m_P1HP[2].enabled = false;

			if (m_player1Hp == 1)
				m_P1HP[1].enabled = false;

			if (m_player1Hp <= 0)
				m_P1HP[0].enabled = false;

			StartCoroutine (PlayerHitEvent (player));
		}
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
		m_bigAssBall1.SetActive (false);
		m_bigAssBall2.SetActive (false);
		if (player == 1) {
			Debug.Log ("Player 1 won!");
			
		}
		if (player == 2) {
			Debug.Log ("Player 2 won!");
		}

		yield return new WaitForSeconds (1.0f);

		if (Input.GetKey (KeyCode.R))
			StartGame ();
	}

}
