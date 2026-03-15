using UnityEngine;

public class GizmoRotation : MonoBehaviour
{
	private Ray ray;

	private RaycastHit hit;

	private Vector2 initPosition;

	private Vector2 endPosition;

	private Vector2 resultMagnitude;

	private float angle;

	private bool rotationStarted;

	private Vector3 rotationModel;

	private Vector3 rotationGizmo;

	public float speedRotate;

	public Transform kerbalModel;

	private void Start()
	{
		rotationStarted = false;
	}

	private void Update()
	{
		if (Input.touchCount == 0)
		{
			return;
		}
		if (Input.GetTouch(0).phase == TouchPhase.Began)
		{
			ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			if (Physics.Raycast(ray, out hit, 50f) && hit.transform.name == "RotateGizmo")
			{
				rotationStarted = true;
				initPosition = Input.GetTouch(0).position;
			}
		}
		if (!rotationStarted)
		{
			return;
		}
		if (Input.GetTouch(0).phase == TouchPhase.Moved)
		{
			endPosition = Input.GetTouch(0).position;
			angle = Vector2.Angle(initPosition, endPosition);
			if (endPosition.x > initPosition.x)
			{
				angle *= -1f;
			}
			initPosition = endPosition;
			if (base.transform.rotation.eulerAngles.y <= 90f || base.transform.rotation.eulerAngles.y >= 270f)
			{
				base.transform.Rotate(0f, angle * speedRotate, 0f);
				kerbalModel.Rotate(0f, angle * speedRotate, 0f);
			}
			rotationGizmo = base.transform.eulerAngles;
			if (rotationGizmo.y > 90f && rotationGizmo.y < 180f)
			{
				kerbalModel.rotation = Quaternion.Euler(0f, 89f, 0f);
				base.transform.rotation = Quaternion.Euler(0f, 89f, 0f);
			}
			if (rotationGizmo.y < 270f && rotationGizmo.y > 180f)
			{
				kerbalModel.rotation = Quaternion.Euler(0f, -89f, 0f);
				base.transform.rotation = Quaternion.Euler(0f, -89f, 0f);
			}
		}
		if (Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended)
		{
			rotationStarted = false;
		}
	}
}
