using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private CharacterController characterController;
	private Animator animator;

	[SerializeField]
	private float moveSpeed = 8f;
	[SerializeField]
	private float turnSpeed = 100f;

	private void Awake()
	{
		characterController = GetComponent<CharacterController>();
		animator = GetComponentInChildren<Animator>();
	}

	private void Update()
	{
		//set movement
		float hor = Input.GetAxis("Horizontal");
		float ver = Input.GetAxis("Vertical");

		var movement = new Vector3(hor, 0, ver);

		animator.SetFloat("Speed", ver);

		transform.Rotate(Vector3.up, hor * turnSpeed * Time.deltaTime);

		if(ver != 0)
		{
			characterController.SimpleMove(transform.forward * moveSpeed * ver);
		}

		//movement
		characterController.SimpleMove(movement * Time.deltaTime * moveSpeed);

		//set Speed for animator
		animator.SetFloat("Speed", movement.magnitude);

/*		//face the moveement direction
		if (movement.magnitude > 0)
		{
			Quaternion newDirection = Quaternion.LookRotation(movement);

			transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * turnSpeed);
		}*/
	}
}