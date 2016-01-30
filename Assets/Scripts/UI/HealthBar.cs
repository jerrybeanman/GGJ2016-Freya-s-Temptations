﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {
	public static HealthBar Instance { get; private set; }
	// Max hunger point.
	public float maxHunger;
	// How fast the hunger bar goes up.
	public float recoveryRate;
	// Healthbar image.
	[HideInInspector]
	public Image image; 
	//public GameObject player;

	void Start()
	{
		image = GetComponent<Image> ();
		if (Instance != null) {
			DestroyImmediate(gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad(gameObject);
	}

	// Update is called once per frame
	void Update () 
	{
		// Fills the health bar getting the current position and moves it up using the recoveryRate up to maxHunger point.
		image.fillAmount = Mathf.MoveTowards(image.fillAmount, maxHunger, Time.deltaTime * recoveryRate);
		if (image.fillAmount == 1.0f) {
			Debug.Log ("game Over");
		}
	}

	void OnTriggerEnter(Collider2D other)
	{
		if (other.gameObject.tag == "Food")
		{
			Image image = HealthBar.Instance.image;
			HealthBar.Instance.image.fillAmount = 
				Mathf.MoveTowards(image.fillAmount, image.fillAmount - 0.2f, Time.deltaTime);
		}
	}
}
