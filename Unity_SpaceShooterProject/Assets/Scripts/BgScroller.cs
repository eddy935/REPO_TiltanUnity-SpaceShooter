﻿using UnityEngine;

namespace Assets.Scripts
{
    public class BgScroller : MonoBehaviour
    {

        public float scrollSpeed;

        public float tileSizeZ;

        private Vector3 _startPosition;

        // Use this for initialization
        void Start()
        {
            _startPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
            transform.position = _startPosition + Vector3.forward * newPosition;
        }
    }
}
