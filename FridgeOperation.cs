using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// this script will be attached to the fridge
public class FridgeOperation : MonoBehaviour
{
	// interactText is a variable that we assign to a TextMeshPro UI object
	// here, we specifically assign interactText to the TextMeshPro UI object that has text "Press 'E' to itneract"
	public TextMeshProUGUI interactText;

	// internal variable that allows us to pick up a key when set to true
	private bool pickUpAllowed;

	// variables for key image that we assign in inspector
	public GameObject keyImage;

	// variable for when player has key
	public bool hasKey;

	// when the game starts, we disable interactText
	// so it becomes invisible until infini collides with the fridge
	private void Start()
	{
		interactText.gameObject.SetActive(false);
		keyImage.gameObject.SetActive(false);
	}

	// we check if pickUpAllowed is true and E is pressed
	// then PickUp() function is invoked
	private void Update()
	{
		if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
			PickUp();
	}

	// invoked when infini collides with the fridge
	// enable interactText and set pickUpAllowed to true
	private void OnCollisionEnter2D(Collision2D collision)
	{
		interactText.gameObject.SetActive(true);
		pickUpAllowed = true;
	}

	// invoked when infini un-collides with the fridge
	// disable interactText and set pickUpAllowed to false
	private void OnCollisionExit2D(Collision2D collision)
	{
		interactText.gameObject.SetActive(false);
		pickUpAllowed = false;
	}

	// if PickUp is called, then show the key image
	private void PickUp()
	{
		keyImage.gameObject.SetActive(true);
		hasKey = true;
	}
}