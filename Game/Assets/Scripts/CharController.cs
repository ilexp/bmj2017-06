using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public class CharController : MonoBehaviour
	{
		private void Update()
		{
			Rigidbody2D body = GetComponent<Rigidbody2D>();

			float leftRight = Input.GetAxis("Horizontal");
			body.velocity = new Vector2(leftRight * 5.0f, body.velocity.y);
		}
	}
}
