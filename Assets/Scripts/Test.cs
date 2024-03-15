using UnityEngine;

public class Test : MonoBehaviour
{
	[SerializeField, Min(1)] private int _count = 10;
	[SerializeField] private LocationTag _locationTagPrefab;

	void Start()
	{
		GeoCoord[] cities = CitiesContainer.GetRandomCities(_count);

		foreach (var city in cities)
		{
			var locationTag = Instantiate(_locationTagPrefab, transform);
			locationTag.SetLocation(new Location()
			{
				LocationName = city.Label,
				Latitude = city.Latitude,
				Longitude = city.Longitude
			});
		}
	}
}