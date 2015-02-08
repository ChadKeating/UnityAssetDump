using UnityEngine;
using System.Collections;

public class SendToBack : MonoBehaviour
{
	void OnEnable()
	{
		transform.SetAsFirstSibling();
	}
}
