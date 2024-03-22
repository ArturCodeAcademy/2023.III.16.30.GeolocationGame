using TMPro;
using UnityEngine;

public class LocationTag : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Transform _canvas;
    [SerializeField, Range(0, 1)] private float _canvasOffset = 0.1f;

    private Location _location;

    public void SetLocation(Location location)
    {
        _location = location;

        transform.position = _location.ToVector3() * Earth.Instance.Radius;

        transform.LookAt(Vector3.zero);
        _canvas.localPosition = Vector3.back * _canvasOffset;
        _text.text = _location.LocationName;
    }
}
