using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playermov : MonoBehaviour
{
	public float initialSpeed = 10f; 
	private float currentSpeed; 
	public float xMinLimit = -1.8f;
	public float xMaxLimit = 1.8f;
	private bool canQuit = true;

	void Start()
	{
		currentSpeed = initialSpeed;
	}

	void Update()
	{
		float hMovement = Input.GetAxisRaw("Horizontal") * currentSpeed; // Negatif deðer kullanarak yönü tersine çevir

		transform.Translate(new Vector3(hMovement, 0, 0) * Time.deltaTime);

		float clampedX = Mathf.Clamp(transform.position.x, xMinLimit, xMaxLimit);
		transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
	}

	void FixedUpdate()
	{
		if (Input.GetKeyDown(KeyCode.Escape) && canQuit)
		{
			QuitGame();
		}
	}
	public void Retry()
	{
		
		canQuit = true;

		
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void QuitGame()
	{
		Application.Quit();
	}
}
