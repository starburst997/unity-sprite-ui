using System;
using UnityEngine;

namespace SpriteUI
{
    [ExecuteAlways]
    [RequireComponent(typeof(RectTransform))]
    public class UI : MonoBehaviour
    {
        private Camera _camera;
        private RectTransform _rect;

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
            float height = _camera.orthographicSize * 2f;
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
