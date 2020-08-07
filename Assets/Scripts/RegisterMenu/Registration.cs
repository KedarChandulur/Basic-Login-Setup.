﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Registration : MonoBehaviour
{
	[SerializeField] private InputField emailField, passwordField;
	[SerializeField] private Button registerButton, loginButton;
	[SerializeField]private string path;

	private void Start()
	{
		loginButton.onClick.AddListener(GoToLoginMenu);
		registerButton.onClick.AddListener(CallRegister);
	}

	private void GoToLoginMenu()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("LoginMenu");
	}

	private void CallRegister()
	{
		StartCoroutine(Register());
	}

	IEnumerator Register()
	{
		WWWForm form = new WWWForm();
		form.AddField("email", emailField.text);
		form.AddField("password", passwordField.text);

		WWW www = new WWW(path, form);
		yield return www;

		if(www.text == "0")
		{
			Debug.Log("User created sucessfully.");
			UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
		}
		else
		{
			Debug.Log("User creation failed. Error # ." + www.text);
		}
	}

	public void VerifyInputs()
	{
		registerButton.interactable = (emailField.text.Contains("@") && emailField.text.Contains(".") && emailField.text.Length >= 12 && passwordField.text.Length >= 8);
	}
}
