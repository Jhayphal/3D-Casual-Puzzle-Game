using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateActivator : MonoBehaviour
{
	public bool CanPush = true;

	[SerializeField] bool hide;
	[SerializeField] GameObject[] objects;
	[SerializeField] Material active;
	[SerializeField] Material disabled;
	[SerializeField] GateActivator toggleButton;

	public void OnTriggerEnter(Collider other)
	{
		if (!CanPush)
			return;

		if (!other.CompareTag("Cube") 
			&& !other.CompareTag("Player"))
			return;

		var color = hide 
			? disabled 
			: active;

		var enabled = hide;

		foreach (var obj in objects)
		{
			obj.GetComponent<Renderer>().material = color;
			obj.GetComponent<Collider>().isTrigger = enabled;
		}

		gameObject.GetComponent<Renderer>().material = disabled;

		if (toggleButton != null)
		{
			toggleButton.gameObject.GetComponent<Renderer>().material = active;
			toggleButton.CanPush = true;
		}
	}
}
