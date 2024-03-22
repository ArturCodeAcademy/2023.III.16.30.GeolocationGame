using System;
using UnityEngine;

public class CityEnumerator : MonoBehaviour
{
    public int CityCount => _cities.Length;
    public int CurrentCityNumber => _currentCityIndex + 1;
    public GeoCoord CurrentCity => _cities[_currentCityIndex];

    public event Action<GeoCoord> OnCityChanged;

    private GeoCoord[] _cities;
    private int _currentCityIndex;

    public void StartGame(int count)
    {
        _cities = CitiesContainer.GetRandomCities(count);
        _currentCityIndex = 0;

        OnCityChanged?.Invoke(_cities[_currentCityIndex]);
    }

    public void SetNextCity()
    {
        if (_currentCityIndex < _cities.Length - 1)
        {
			_currentCityIndex++;
            OnCityChanged?.Invoke(_cities[_currentCityIndex]);
		}
    }
}
