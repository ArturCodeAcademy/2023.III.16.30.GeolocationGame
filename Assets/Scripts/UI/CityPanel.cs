using TMPro;
using UnityEngine;

public class CityPanel : MonoBehaviour
{
	[SerializeField] private CityEnumerator _cityEnumerator;

	[Header("UI")]
	[SerializeField] private TMP_Text _cityNameText;
	[SerializeField] private TMP_Text _cityNumberText;

	private void OnEnable()
	{
		_cityEnumerator.OnCityChanged += OnCityChanged;
	}

	private void OnDisable()
	{
		_cityEnumerator.OnCityChanged -= OnCityChanged;
	}

	private void OnCityChanged(GeoCoord city)
	{
		_cityNameText.text = city.Label;
		_cityNumberText.text = $"{_cityEnumerator.CurrentCityNumber} / {_cityEnumerator.CityCount}";
	}
}
