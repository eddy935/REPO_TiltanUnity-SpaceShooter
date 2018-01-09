using UnityEngine;

namespace Assets.Scripts
{
	public class DestroyByTime : MonoBehaviour
	{
		public float lifeTime;

		// Use this for initialization
		void Start ()
		{
			Destroy(gameObject,lifeTime);
		}
	
	}
}
