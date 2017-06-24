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
		[SerializeField]
		private MeshRenderer sprite = null;

		private Vector3 baseScale = Vector3.one;
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
			this.baseScale = this.sprite.transform.localScale;
		}
		private void Update()
		{
			if (Mathf.Abs(this.targetMovement) > 0.1f)
			{
				this.sprite.transform.localScale = new Vector3(
					Mathf.MoveTowards(
						this.sprite.transform.localScale.x,
						this.baseScale.x * Mathf.Sign(this.targetMovement),
						Mathf.Abs(this.baseScale.x) * Time.deltaTime),
					this.baseScale.y,
					this.baseScale.z);
			}
			this.sprite.transform.rotation = Quaternion.AngleAxis(
				Mathf.Sin(Time.time * 3.0f) * 2.0f * Mathf.Abs(this.targetMovement), 
				Vector3.back);
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
				heroBody.AddForce(impactImpulse * 0.5f * (new Vector2(0.0f, 1.0f) + Random.insideUnitCircle), ForceMode2D.Impulse);
			}
		}
	}
}
