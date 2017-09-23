using UnityEngine;
using System.Collections;

public class DismissParent : MonoBehaviour 
{
	void OnMouseDown()
	{
		Destroy(transform.parent.gameObject);
	}
}