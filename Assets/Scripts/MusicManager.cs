using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
	public GameObject m_music;
	[SerializeField] AudioSource m_musicSource;

	void Start() {
		m_music = GameObject.Find("MusicManager");
		m_musicSource = m_music.GetComponent<AudioSource>();
		PlayMusic();
	}

	public void PlayMusic() {
		m_musicSource.Play();
	}

	public void UnPauseMusic() {
		m_musicSource.UnPause();
	}

	public void PauseMusic() {
		m_musicSource.Pause();
	}
}