using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public class Player : MonoBehaviour
	{
		[SerializeField] private CharController character;
		[SerializeField] private CameraController camera;


		private void Update()
		{
			this.character.TargetMovement = Input.GetAxis("Horizontal");
			if (Input.GetButtonDown("Jump"))
			{
				this.character.Jump();
				this.camera.ShakeScreen();
			}
		}
	}
}
