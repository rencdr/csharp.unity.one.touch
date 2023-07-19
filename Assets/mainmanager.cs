using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmanager : MonoBehaviour
{
	public GameObject RetryBut;
	public GameObject QuitBut;

	public void OnRetryButtonClicked()
	{
		SceneManager.LoadScene("SampleScene");
	}
	public void OnQuitButtonClicked()
	{
		Application.Quit();

	}
}
