using Unity.Mathematics;
using UnityEngine;

public class CannonRotator : MonoBehaviour
{
    [Header("Rotator params")]
    [Tooltip("GameObject that we will spin by lifting the cannon")]
    [SerializeField] private Transform _rotator;
    [SerializeField] private float _topAngle;
    [SerializeField] private float _downAngle;
    [SerializeField] private float _timeToRotate;

    private float _timer;
    private bool _isRaising;

    public float _currentAngle; 
    
    private void Update()
    {
        if (_timer >= _timeToRotate)
        {
            _timer = 0f;
            _isRaising = !_isRaising;
        }
        else
        {
            float angle = Mathf.Lerp(_isRaising ? _downAngle : _topAngle, _isRaising ? _topAngle : _downAngle,
                _timer / _timeToRotate);
            _currentAngle = angle;
            _rotator.localRotation = Quaternion.Euler(0f, 0f, angle);
            _timer += Time.deltaTime;
        }
    }
}
