using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// this script will be attached to non-fridge objects
public class NonFridgeOperation : MonoBehaviour
{
	// interactText variable that we assign in inspector
	// interactText = "Press 'E' to interact"
	public TextMeshProUGUI interactText;

	// variable that allows us to interact when set to true
	private bool interactAllowed;

	// variables for empty image that we assign in inspector
	public GameObject emptyImage;

	// when the game starts, we disable interactText
	// so it becomes invisible until infini collides with a non-fridge object
	private void Start()
	{
		interactText.gameObject.SetActive(false);
		emptyImage.gameObject.SetActive(false);
	}

	// we check if interactAllowed is true and E is pressed
	// then PickUp() function is invoked
	private void Update()
	{
		if (interactAllowed && Input.GetKeyDown(KeyCode.E))
			PickUp();
	}

	// invoked when infini collides with a non-fridge object
	// enable interactText and set interactAllowed to true
	private void OnCollisionEnter2D(Collision2D collision)
	{
		interactText.gameObject.SetActive(true);
		interactAllowed = true;
	}

	// invoked when infini un-collides with a non-fridge object
	// disable interactText and set interactAllowed to false
	private void OnCollisionExit2D(Collision2D collision)
	{
		interactText.gameObject.SetActive(false);
		interactAllowed = false;
		emptyImage.gameObject.SetActive(false);
	}

	// if PickUp is called, then show the empty image
	private void PickUp()
	{
		emptyImage.gameObject.SetActive(true);
	}
}