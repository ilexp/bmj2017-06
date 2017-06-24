using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public class StoneTrigger : MonoBehaviour
	{
		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.gameObject.GetComponent<CharController>() == null)
				return;

			Debug.Log("Test");
			Rigidbody2D body = this.GetComponent<Rigidbody2D>();
			if (body.constraints != RigidbodyConstraints2D.None)
			{
				body.constraints = RigidbodyConstraints2D.None;
				body.gameObject.layer = 10;
			}
		}
	}
}
