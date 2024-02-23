using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField] private Transform _spaceObject;
    [SerializeField] private Quaternion _rotation;
    [SerializeField] private float _distance = 100f;
    [SerializeField] private float _speed = 10f;

	private void Update()
	{
		_rotation *= Quaternion.Euler(0, _speed * Time.deltaTime, 0);
		_spaceObject.localPosition = _rotation * Vector3.forward * _distance;
		_spaceObject.localRotation = _rotation;
	}

#if UNITY_EDITOR

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, _distance);

		Vector3 pos = _rotation * Vector3.forward * _distance;
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, transform.position + pos);
		Gizmos.DrawLine(transform.position, transform.position - pos);
		Quaternion rotation = _rotation * Quaternion.Euler(0, 90, 0);
		pos = rotation * Vector3.forward * _distance;
		Gizmos.DrawLine(transform.position, transform.position + pos);
		Gizmos.DrawLine(transform.position, transform.position - pos);
	}

	private void OnValidate()
	{
		if (_spaceObject is not null)
		{
			_spaceObject.localPosition = _rotation * Vector3.forward * _distance;
		}
	}

#endif
}
