using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public class CharController : MonoBehaviour
	{
		[SerializeField]
		private float moveSpeed = 5.0f;
		[SerializeField]
		private float jumpStrength = 1.0f;

		private float targetMovement = 0.0f;
		private Rigidbody2D body;


		public float TargetMovement
		{
			get { return this.targetMovement; }
			set { this.targetMovement = value; }
		}


		public void Jump()
		{
			this.body.AddForce(
				new Vector2(0.0f, this.jumpStrength), 
				ForceMode2D.Impulse);
		}

		private void Awake()
		{
			this.body = this.GetComponent<Rigidbody2D>();
		}
		private void Update()
		{
			this.body.velocity = new Vector2(
				this.targetMovement * this.moveSpeed, 
				this.body.velocity.y);
		}
	}
}
