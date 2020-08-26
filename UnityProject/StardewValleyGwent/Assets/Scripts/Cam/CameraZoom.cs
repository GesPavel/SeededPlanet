using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameResources.Scripts.Cam
{
    [RequireComponent(typeof(Camera))]
    public class CameraZoom : MonoBehaviour
    {
        [SerializeField]
        private List<int> _sizes = null;

        [SerializeField]
        private float _zoomSpeed = 5f;

        private Camera _cam = null;

        private int _currentSizeIndex = 0;

        private bool _zoomingEnable = true;

        private void Awake()
        {
            _cam = GetComponent<Camera>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                DecreaseSize();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                IncreaseSize();
            }

            var _targetSize = _sizes[_currentSizeIndex];
            _cam.orthographicSize = Mathf.Lerp(_cam.orthographicSize, _targetSize, _zoomSpeed * Time.deltaTime);
        }

        private void IncreaseSize()
        {
            if (CheckZoomEnable(+1) == false)
            {
                return;
            }

            _currentSizeIndex += 1;
        }

        private void DecreaseSize()
        {
            if (CheckZoomEnable(-1) == false)
            {
                return;
            }

            _currentSizeIndex -= 1;
        }

        private bool CheckZoomEnable(int sign)
        {
            if (_zoomingEnable == false)
            {
                return false;
            }

            if (_currentSizeIndex + sign < 0 || _currentSizeIndex + sign >= _sizes.Count)
            {
                return false;
            }

            return true;
        }
    }
}
