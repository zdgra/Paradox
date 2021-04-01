using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

// this script will be attached to the lock
public class LockOperations : MonoBehaviour
{
	// interactText variable that we assign in inspector
	// interactText = "Press 'E' to interact"
	public TextMeshProUGUI interactText;

	// variable that allows us to interact when set to true
	private bool interactAllowed;

	// variables for empty image that we assign in inspector
	public GameObject dialogueImage;

	// variable for whether the player has the key
	public GameObject fridge;

	// variable that tells whether the lock has been reached with the key
	public bool lockReachedWithKey = false;

	// when the game starts, we disable interactText
	// so it becomes invisible until infini collides with a non-fridge object
	private void Start()
	{
		interactText.gameObject.SetActive(false);
		dialogueImage.gameObject.SetActive(false);
	}

	// we check if interactAllowed is true and E is pressed
	// then DialogueOn() function is invoked
	private void Update()
	{
		if (interactAllowed && Input.GetKeyDown(KeyCode.E))
			DialogueOn();
	}

	// invoked when infini collides with a non-fridge object
	// enable interactText and set pickUpAllowed to true
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (fridge.GetComponent<FridgeOperation>().hasKey == true)
        {
			lockReachedWithKey = true;
			gameObject.SetActive(false);
			Invoke("ClosingNote", 2);
		}

		else
        {
			interactText.gameObject.SetActive(true);
			interactAllowed = true;
		}
	}

	// invoked when infini un-collides with a non-fridge object
	// disable interactText and set pickUpAllowed to false
	private void OnCollisionExit2D(Collision2D collision)
	{
		interactText.gameObject.SetActive(false);
		interactAllowed = false;
		dialogueImage.gameObject.SetActive(false);
	}

	// if DialogueOn is called, then show the empty image
	private void DialogueOn()
	{
		dialogueImage.gameObject.SetActive(true);
	}

	private void ClosingNote()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}