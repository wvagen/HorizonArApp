using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lean.Touch
{
	// This script allows you to scale the current GameObject
	public class LeanScale : MonoBehaviour
	{

        public TrailRenderer[] trails;

		[Tooltip("Ignore fingers with StartedOverGui?")]
		public bool IgnoreStartedOverGui = true;

		[Tooltip("Ignore fingers with IsOverGui?")]
		public bool IgnoreIsOverGui;

		[Tooltip("Allows you to force rotation with a specific amount of fingers (0 = any)")]
		public int RequiredFingerCount;

		[Tooltip("Does scaling require an object to be selected?")]
		public LeanSelectable RequiredSelectable;

		[Tooltip("The camera that will be used to calculate the zoom (None = MainCamera)")]
		public Camera Camera;

		[Tooltip("If you want the mouse wheel to simulate pinching then set the strength of it here")]
		[Range(-1.0f, 1.0f)]
		public float WheelSensitivity;

		[Tooltip("Should the scaling be performanced relative to the finger center?")]
		public bool Relative;

		[Tooltip("Should the scale value be clamped?")]
		public bool ScaleClamp;

		[Tooltip("The minimum scale value on all axes")]
		public Vector3 ScaleMin;

		[Tooltip("The maximum scale value on all axes")]
		public Vector3 ScaleMax;

        bool canResetTrail = false;

#if UNITY_EDITOR
		protected virtual void Reset()
		{
			Start();
		}
#endif

		protected virtual void Start()
		{
			if (RequiredSelectable == null)
			{
				RequiredSelectable = GetComponent<LeanSelectable>();
			}
		}

        IEnumerator enableAndReanbleTrails()
        {
            foreach (TrailRenderer trail in trails)
            {
                trail.time = 0;
            }
            yield return new WaitForSeconds(2);
            foreach (TrailRenderer trail in trails)
            {
                trail.time = 20;
            }
        }

		protected virtual void Update()
		{
			// Get the fingers we want to use
			var fingers = LeanSelectable.GetFingersOrClear(IgnoreStartedOverGui, IgnoreIsOverGui, RequiredFingerCount, RequiredSelectable);

			// Calculate pinch scale, and make sure it's valid
			var pinchScale = LeanGesture.GetPinchScale(fingers, WheelSensitivity);


            if (pinchScale == 1) Debug.Log("pinch = 1");
            else{
                canResetTrail = false;
                if (!canResetTrail)
                {
                    canResetTrail = true;
                    StartCoroutine(enableAndReanbleTrails());

                }
            }

			if (pinchScale > 0.0f)
			{
                canResetTrail = false;
				// Perform the translation if this is a relative scale
				if (Relative == true)
				{
					var pinchScreenCenter = LeanGesture.GetScreenCenter(fingers);

					if (transform is RectTransform)
					{
						TranslateUI(pinchScale, pinchScreenCenter);
					}
					else
					{
						Translate(pinchScale, pinchScreenCenter);
					}
				}

				// Perform the scaling
				Scale(transform.localScale * pinchScale);
            }
		}

		protected virtual void TranslateUI(float pinchScale, Vector2 pinchScreenCenter)
		{
			// Screen position of the transform
			var screenPoint = RectTransformUtility.WorldToScreenPoint(Camera, transform.position);

			// Push the screen position away from the reference point based on the scale
			screenPoint.x = pinchScreenCenter.x + (screenPoint.x - pinchScreenCenter.x) * pinchScale;
			screenPoint.y = pinchScreenCenter.y + (screenPoint.y - pinchScreenCenter.y) * pinchScale;

			// Convert back to world space
			var worldPoint = default(Vector3);

			if (RectTransformUtility.ScreenPointToWorldPointInRectangle(transform.parent as RectTransform, screenPoint, Camera, out worldPoint) == true)
			{
				transform.position = worldPoint;
			}
		}

		protected virtual void Translate(float pinchScale, Vector2 screenCenter)
		{
			// Make sure the camera exists
			var camera = LeanTouch.GetCamera(Camera, gameObject);

			if (camera != null)
			{
				// Screen position of the transform
				var screenPosition = camera.WorldToScreenPoint(transform.position);

				// Push the screen position away from the reference point based on the scale
				screenPosition.x = screenCenter.x + (screenPosition.x - screenCenter.x) * pinchScale;
				screenPosition.y = screenCenter.y + (screenPosition.y - screenCenter.y) * pinchScale;

				// Convert back to world space
				transform.position = camera.ScreenToWorldPoint(screenPosition);
			}
			else
			{
				Debug.LogError("Failed to find camera. Either tag your cameras MainCamera, or set one in this component.", this);
			}
		}

		protected virtual void Scale(Vector3 scale)
		{
			if (ScaleClamp == true)
			{
				scale.x = Mathf.Clamp(scale.x, ScaleMin.x, ScaleMax.x);
				scale.y = Mathf.Clamp(scale.y, ScaleMin.y, ScaleMax.y);
				scale.z = Mathf.Clamp(scale.z, ScaleMin.z, ScaleMax.z);
			}

			transform.localScale = scale;
		}
	}
}