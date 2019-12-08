using System;
using UnityEngine;

namespace SpriteUI
{
    [ExecuteAlways]
    [RequireComponent(typeof(RectTransform))]
    public class UI : MonoBehaviour
    {
        public float DefaultSize = 5f;
        
        private Camera _camera;
        private RectTransform _rect;

        private float _size;
        private float _scale;
        
        private float _width;
        private float _height;
        
        private float _x;
        private float _y;
        
        private void OnDisable()
        {
            
        }

        private void OnEnable()
        {
            _camera = Camera.main;
            _rect = GetComponent<RectTransform>();
        }

        private void Update()
        {
            float size = _camera.orthographicSize;
            if (!Mathf.Approximately(_size, size))
            {
                _size = size;
                _scale = _size / DefaultSize;
                
                // Prevent NaN
                if (_scale <= 0.0001f)
                {
                    _scale = 0.0001f;
                }
                
                _rect.localScale = new Vector3(_scale, _scale, 1f);
            }
            
            float height = size * 2f / _scale;
            float width = height * _camera.aspect;

            if (!Mathf.Approximately(_width, width) || !Mathf.Approximately(_height, height))
            {
                _width = width;
                _height = height;
                _rect.sizeDelta = new Vector2(_width, _height);
            }

            Vector2 pos = _camera.transform.position;
            if (!Mathf.Approximately(pos.x, _x) || !Mathf.Approximately(pos.y, _y))
            {
                _x = pos.x;
                _y = pos.y;
                _rect.anchoredPosition3D = new Vector3(_x, _y, 0f);
            }
        }
    }
}
