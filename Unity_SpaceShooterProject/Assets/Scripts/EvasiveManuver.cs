using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
	public class EvasiveManuver : MonoBehaviour
	{
		public Boundary Boundary;

		public float tilt;
		public float dodge;
		public float smoothing;

		public Vector2 startWait;
		public Vector2 maneuverTime;
		public Vector2 maneuverWait;

		private Rigidbody _rigidBody;
		private float _targetManuver;
		private float _currentSpeed;

		void Start ()
		{
			_rigidBody = GetComponent<Rigidbody>();
			_currentSpeed = _rigidBody.velocity.z;
			StartCoroutine(Evade());
		}

		IEnumerator Evade()
		{
			yield return new WaitForSeconds(Random.Range(startWait.x,startWait.y));

			while (true)
			{
				_targetManuver = Random.Range(1,dodge) * -Mathf.Sign(transform.position.x);
				yield return new WaitForSeconds(Random.Range(maneuverTime.x,maneuverTime.y));

				_targetManuver = 0;
				yield return new WaitForSeconds(Random.Range(maneuverWait.x,maneuverWait.y));
			}
		}

		void FixedUpdate ()
		{
			float newManuver = Mathf.MoveTowards(_rigidBody.velocity.x,_targetManuver,Time.deltaTime*smoothing);
			_rigidBody.velocity=new Vector3(newManuver,0.0f,_currentSpeed);
			_rigidBody.position=new Vector3
								(
									Mathf.Clamp(_rigidBody.position.x, Boundary.xMin,Boundary.xMax),
									0.0f,
									Mathf.Clamp(_rigidBody.position.z,Boundary.zMin,Boundary.zMax)
								);

			_rigidBody.rotation = Quaternion.Euler(0.0f,0.0f,_rigidBody.velocity.x * -tilt);
		}
	}
}
