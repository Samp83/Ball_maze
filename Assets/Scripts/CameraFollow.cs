using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform ball;

	void Update()
	{
		if (ball != null)
		{
			transform.LookAt(ball);
		}
	}
}
