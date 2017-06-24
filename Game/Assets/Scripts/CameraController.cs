using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public class CameraController : MonoBehaviour
	{
		[SerializeField]
		private Transform followTarget;
		[SerializeField]
		private float smoothness = 1.0f;
		[SerializeField]
		private float targetDistance = 1.0f;


		private void Update()
		{
			Transform transform = this.transform;

			Vector3 targetPos = followTarget.position + Vector3.back * this.targetDistance;
			Vector3 currentPos = transform.position;
			Vector3 posDiff = targetPos - currentPos;

			transform.position = Vector3.MoveTowards(
				currentPos,
				targetPos,
				posDiff.magnitude * Mathf.Pow(2.0f, -this.smoothness) * 10.0f * Time.deltaTime);
		}
	}
}
