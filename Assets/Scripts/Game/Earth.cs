using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SphereCollider))]
public class Earth : MonoBehaviour, IPointerClickHandler
{
	public static Earth Instance { get; private set; }

	public Action<Vector3> Click;

	[field:SerializeField] public float Radius { get; private set; }

	private SphereCollider _collider;

	private void Awake()
	{
		Instance = this;
		_collider = GetComponent<SphereCollider>();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
			Click?.Invoke(eventData.pointerCurrentRaycast.worldPosition);
	}
}