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
		[SerializeField]
		private float targetHeightOffset = 0.0f;

		private float shakeStrength;
		private Vector3 shakePosOffset;
		private Quaternion shakeRotationOffset;


		public void ShakeScreen(float strength)
		{
			shakeStrength += strength;
		}

		private void Update()
		{
			Transform transform = this.transform;

			Vector3 targetPos = followTarget.position + new Vector3(
				0.0f,
				this.targetHeightOffset,
				-this.targetDistance);
			Vector3 currentPos = transform.position;
			Vector3 posDiff = targetPos - currentPos;

			transform.position -= shakePosOffset;
			transform.rotation *= Quaternion.Inverse(shakeRotationOffset);

			transform.position = Vector3.MoveTowards(
				currentPos,
				targetPos,
				posDiff.magnitude * Mathf.Pow(2.0f, -this.smoothness) * 10.0f * Time.deltaTime);

			shakeStrength = Mathf.MoveTowards(
				shakeStrength,
				0.0f,
				Mathf.Max(shakeStrength * 5.0f, 0.1f) * Time.deltaTime);
			shakePosOffset = Random.onUnitSphere * 0.1f * shakeStrength;
			shakeRotationOffset = Quaternion.Lerp(Quaternion.identity, Random.rotation, 0.1f * 0.25f * shakeStrength);

			transform.position += shakePosOffset;
			transform.rotation *= shakeRotationOffset;
		}
	}
}
