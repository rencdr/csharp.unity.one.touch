using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ballcontroller : MonoBehaviour
{
	public Rigidbody rb;
	public float speed = 2f;
	public float accelerationAmount = 1f;
	public GameObject ballPrefab;
	public Transform spawnPoint;
	public Text scoreText;
	public Text scoreTextPL;
	public string GameOverScene = "GameOverScene";
	public string GameOverScene2 = "GameOverScene2";

	private static int score = 0;
	private static int scorePL = 0;

	private Vector3 startingPosition;

	void Start()
	{
		StartCoroutine(StartDelay());
	}

	private IEnumerator StartDelay()
	{
		yield return new WaitForSeconds(1f);

		float x = Random.Range(0, 2) == 0 ? -1 : 1;
		float z = Random.Range(0, 2) == 0 ? -1 : 1;
		rb.velocity = new Vector3(x * speed, 0, z * speed);
		rb = GetComponent<Rigidbody>();

		startingPosition = transform.position;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("side"))
		{
			Vector3 contactNormal = collision.contacts[0].normal;
			Vector3 newDirection = Vector3.Reflect(rb.velocity.normalized, contactNormal);
			float newSpeed = rb.velocity.magnitude + accelerationAmount;
			rb.velocity = newDirection.normalized * newSpeed;
		}
		if (collision.gameObject.CompareTag("Player"))
		{
			Vector3 contactNormal = collision.contacts[0].normal;
			Vector3 newDirection = Vector3.Reflect(rb.velocity.normalized, contactNormal);
			float newSpeed = rb.velocity.magnitude + accelerationAmount;
			rb.velocity = newDirection.normalized * newSpeed;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("goal"))
		{
			Score();
		}

		if (other.gameObject.CompareTag("goalPL"))
		{
			ScorePL();
		}
	}

	private void Score()
	{
		score++;
		scoreText.text = score.ToString();

		if (score == 5)
		{
			score = 0;
			SceneManager.LoadScene(GameOverScene2);
			//Debug.Log("gameover");
			return;
		}

		Destroy(gameObject); 

		
		GameObject newBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);

		
		float x = Random.Range(0, 2) == 0 ? -1 : 1;
		float z = Random.Range(0, 2) == 0 ? -1 : 1;
		newBall.GetComponent<Rigidbody>().velocity = new Vector3(x * speed, 0, z * speed);
	}
	private void ScorePL()
	{
		scorePL++;
		scoreTextPL.text = scorePL.ToString();
		if (scorePL == 5)
		{
			scorePL = 0;
			SceneManager.LoadScene(GameOverScene);
			//Debug.Log("gameover");
			return;
		}
		Destroy(gameObject); 

		
		GameObject newBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);

		
		float x = Random.Range(0, 2) == 0 ? -1 : 1;
		float z = Random.Range(0, 2) == 0 ? -1 : 1;
		newBall.GetComponent<Rigidbody>().velocity = new Vector3(x * speed, 0, z * speed);
	}
}




