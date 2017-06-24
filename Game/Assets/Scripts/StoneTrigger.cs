using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public class StoneTrigger : MonoBehaviour
	{
		[SerializeField]
		private GameObject[] activateObj;

		private IEnumerable LateStuff()
		{
			yield return new WaitForSeconds(1.75f);
			foreach (GameObject obj in activateObj)
			{
				obj.SetActive(true);
			}
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.gameObject.GetComponent<CharController>() == null)
				return;

			Rigidbody2D body = this.GetComponent<Rigidbody2D>();
			if (body.constraints != RigidbodyConstraints2D.None)
			{
				body.constraints = RigidbodyConstraints2D.None;
				body.gameObject.layer = 10;

				StartCoroutine(LateStuff().GetEnumerator());
			}
		}
	}
}
