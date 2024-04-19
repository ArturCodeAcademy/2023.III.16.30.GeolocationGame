using UnityEngine;

public static class LocationExtentions
{
	public static Vector3 ToVector3(this Location location)
	{
		return Quaternion.Euler(0, -location.Longitude, 0) * (Quaternion.Euler(-location.Latitude, 0, 0) * Vector3.forward);
	}

	public static GeoCoord ToGeoCoord(this Vector3 position)
	{
		position.Normalize();
		float latitude = Mathf.Asin(position.y) * Mathf.Rad2Deg;
		float longitude = Mathf.Atan2(position.z, position.x) * Mathf.Rad2Deg;

		longitude -= 90;
		if (longitude < -180)
			longitude += 360;

		return new GeoCoord
		{
			Label = string.Empty,
			Latitude = latitude,
			Longitude = longitude
		};
	}

	public static float DistanceTo(this Location location, Location to)
	{
		const float RADIUS = 6371;
		float lat1 = location.Latitude * Mathf.Deg2Rad;
		float lat2 = to.Latitude * Mathf.Deg2Rad;
		float lon1 = location.Longitude * Mathf.Deg2Rad;
		float lon2 = to.Longitude * Mathf.Deg2Rad;

		float dlat = lat2 - lat1;
		float dlon = lon2 - lon1;

		float a = Mathf.Sin(dlat / 2) * Mathf.Sin(dlat / 2) +
			Mathf.Cos(lat1) * Mathf.Cos(lat2) *
			Mathf.Sin(dlon / 2) * Mathf.Sin(dlon / 2);

		float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));

		return RADIUS * c;
	}
}
