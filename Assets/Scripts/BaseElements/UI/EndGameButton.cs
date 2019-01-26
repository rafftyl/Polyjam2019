﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;


public class EndGameButton : MonoBehaviour
{
	private void Awake()
	{
		Button button = GetComponent<Button>();
		Assert.IsNotNull(button, "Missing button");
		button.onClick.AddListener(OnClicked);
	}

	private void OnClicked()
	{
		Application.LoadLevel("BaseTest");
	}
}
