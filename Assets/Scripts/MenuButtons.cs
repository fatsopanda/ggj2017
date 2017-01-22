using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

	[SerializeField] GameObject m_menuPanel;
	[SerializeField] GameObject m_controlsPanel;
	[SerializeField] GameManager m_gameManager;
	[SerializeField] bool m_howto;
	[SerializeField] bool m_quit;
	public bool m_menuActive;

	void Start() {
		m_menuPanel = GameObject.Find("StartMenuPanel");
		m_controlsPanel = GameObject.Find("ControlsPanel");
		m_gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		m_controlsPanel.SetActive(false);
		m_quit = true;
		m_menuActive = true;
	}

	public void HowButton() {
		m_menuPanel.SetActive(false);
		m_controlsPanel.SetActive(true);
		m_howto = true;
		m_quit = false;
	}

	IEnumerator QuitDelay() {
		yield return new WaitForSeconds (2);
		m_quit = true;
	}

	public void Back() {
		if (m_howto)
		{
			m_controlsPanel.SetActive(false);
			m_menuPanel.SetActive(true);
			m_howto = false;
		}
		StartCoroutine("QuitDelay");
	}

	public void PlayButton() {
		m_controlsPanel.SetActive (false);
		m_menuPanel.SetActive (false);
		m_menuActive = false;
		m_gameManager.StartGame ();
	}

	public void QuitButton() {
		Application.Quit();
	}

	void Update () {
		if (Input.GetKeyDown("escape") && (m_howto))
			Back();

		if (Input.GetKeyDown("escape") && !m_howto && m_quit)
			Application.Quit();
	}
}