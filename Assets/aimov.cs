using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimov : MonoBehaviour
{
	public float initialSpeed = 10f; 
	private float currentSpeed; 
	public float xMinLimit = -1.5f;
	public float xMaxLimit = 1.5f;

	private bool isMovingRight = true; 

	void Start()
	{
		currentSpeed = initialSpeed;

		
		StartCoroutine(WaitForDirectionChange(0.5f));
	}

	void Update()
	{
		
		float hMovement = isMovingRight ? currentSpeed : -currentSpeed;

		transform.Translate(new Vector3(hMovement, 0, 0) * Time.deltaTime);

		
		float clampedX = Mathf.Clamp(transform.position.x, xMinLimit, xMaxLimit);
		transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
	}

	
	private void ChangeDirection()
	{
		isMovingRight = !isMovingRight;
	}

	
	private IEnumerator WaitForDirectionChange(float seconds)
	{
		while (true)
		{
			yield return new WaitForSeconds(seconds);
			ChangeDirection();
		}
	}
}
