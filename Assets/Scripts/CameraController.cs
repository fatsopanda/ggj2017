using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	[SerializeField] float m_shakeAmount;
	[SerializeField] float m_smallShakeAmount;
	[SerializeField] float m_bigShakeAmount;

	[SerializeField] Vector3 _origin;

	void Start () {
		_origin = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
	}

	void Update () {
		transform.position = Vector3.Lerp(transform.position, _origin, Time.deltaTime*10f);
	}

	public void ScreenShake(int shake) {
		if (shake == 1)
		{
			InvokeRepeating("StartSmallShake", 0, .0005f);
			Invoke("StopSmallShake", 0.1f);
		}

		if (shake == 2)
		{
			StopSmallShake();
			InvokeRepeating("StartShaking", 0, .005f);
			Invoke("StopShaking", 0.3f);
		}

		if (shake == 3)
		{
			InvokeRepeating("StartBigShake", 0, .005f);
			Invoke("StopBigShake", 0.5f);
		}

	}

	public void FreezeFrame() {
		StartCoroutine ("FreezeFrame");
	}

	void StartShaking() {
		transform.position = transform.position + Random.insideUnitSphere * m_shakeAmount;
	}

	void StopShaking() {
		CancelInvoke("StartShaking");
	}

	void StartSmallShake() {
		transform.position = transform.position + Random.insideUnitSphere * m_smallShakeAmount;
	}

	void StopSmallShake() {
		CancelInvoke("StartSmallShake");
	}

	void StartBigShake() {
		transform.position = transform.position + Random.insideUnitSphere * m_bigShakeAmount;
	}

	void StopBigShake() {
		CancelInvoke("StartBigShake");
	}
}