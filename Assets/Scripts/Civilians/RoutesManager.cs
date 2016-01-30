﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoutesManager : MonoBehaviour {
	public static RoutesManager Instance { get; private set; }
	public List<Route> Routes;
	private void Awake() 
	{
		if (Instance != null) {
			DestroyImmediate(gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad(gameObject);
		GetChild();
	}

	void GetChild()
	{
		foreach(Transform child in transform)
		{
			Route route = child.gameObject.GetComponent<Route>();
			Routes.Add(route);
		}
	}
}
