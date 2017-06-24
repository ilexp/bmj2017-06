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
				new Vector2(0.0f, this.jumpStrength) * this.body.mass, 
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
		private void OnCollisionEnter2D(Collision2D collision)
		{
			CameraController camController = FindObjectOfType<CameraController>();
			float impactImpulse = collision.relativeVelocity.y * 0.01f * this.body.mass;
			camController.ShakeScreen(impactImpulse * 0.1f);

			// Move the hero around randomly from the impact
			{
				Hero hero = FindObjectOfType<Hero>();
				Rigidbody2D heroBody = hero.GetComponent<Rigidbody2D>();
				heroBody.AddForce(impactImpulse * 0.25f * (new Vector2(0.0f, 2.0f) + Random.insideUnitCircle), ForceMode2D.Impulse);
			}
		}
	}
}
