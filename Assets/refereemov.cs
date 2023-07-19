using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class refereemov : MonoBehaviour
{
	public float initialSpeed = 10f; 
	private float currentSpeed; 
	public float zMinLimit = -3.5f;
	public float zMaxLimit = 3f;

	private bool isMovingForward = true; 

	void Start()
	{
		currentSpeed = initialSpeed;

		
		StartCoroutine(WaitForDirectionChange(1f));
	}

	void Update()
	{
		
		float vMovement = isMovingForward ? currentSpeed : -currentSpeed;

		transform.Translate(new Vector3(0, 0, vMovement) * Time.deltaTime);

		
		float clampedZ = Mathf.Clamp(transform.position.z, zMinLimit, zMaxLimit);
		transform.position = new Vector3(transform.position.x, transform.position.y, clampedZ);
	}

	
	private void ChangeDirection()
	{
		isMovingForward = !isMovingForward;
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
