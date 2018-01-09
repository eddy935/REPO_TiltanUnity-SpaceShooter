using UnityEngine;

namespace Assets.Scripts
{
	public class RandomRotator : MonoBehaviour
	{

		public float tumble;

		private Rigidbody _rigidBody;

		// Use this for initialization
		void Start ()
		{
			_rigidBody = GetComponent<Rigidbody>();
			_rigidBody.angularVelocity = Random.insideUnitSphere * tumble;
		}
	
		// Update is called once per frame
		void Update () {
		
		}
	}
}
