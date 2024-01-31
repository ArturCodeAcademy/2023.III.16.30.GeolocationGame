using UnityEngine;

public static class LocationExtentions
{
	public static Vector3 ToVector3(this Location location)
	{
		return Quaternion.Euler(0, -location.Longitude, 0) * (Quaternion.Euler(-location.Latitude, 0, 0) * Vector3.forward);
	}
}
