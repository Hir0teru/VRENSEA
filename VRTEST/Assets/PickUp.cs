namespace GoogleVR.GVRDemo
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {


		[RequireComponent(typeof(Collider))]
		public class Teleport : MonoBehaviour
		{
			private Vector3 startingPosition;

			public Material inactiveMaterial;
			public Material gazedAtMaterial;

			public float gazeTime = 2f;
			private float timer;
			private bool gazedAt;

			void Start()
			{
				startingPosition = transform.localPosition;
				gazedAt = false;
				SetGazedAt(false);
			}

			private void Update()
			{
				if (gazedAt)
				{
					timer += Time.deltaTime;
				}
				else
				{
					timer = 0f;
				}

				if (timer >= gazeTime)
				{
					Destroy(gameObject);
				}
			}

			public void PointerEnter()
			{

			}

			public void SetGazedAt(bool gazedAt1)
			{
				gazedAt = gazedAt1;
				if (inactiveMaterial != null && gazedAtMaterial != null)
				{
					GetComponent<Renderer>().material = gazedAt ? gazedAtMaterial : inactiveMaterial;
					return;
				}
				GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
			}

			public void Reset()
			{
				transform.localPosition = startingPosition;
			}

			public void Recenter()
			{
				#if !UNITY_EDITOR
				GvrCardboardHelpers.Recenter();
				#else
				if (GvrEditorEmulator.Instance != null)
				{
					GvrEditorEmulator.Instance.Recenter();
				}
				#endif  // !UNITY_EDITOR
			}

			public void TeleportRandomly()
			{
				Vector3 direction = Random.onUnitSphere;
				direction.y = Mathf.Clamp(direction.y, 0.5f, 1f);
				float distance = 2 * Random.value + 1.5f;
				transform.localPosition = direction * distance;
			}
		}
	}

}
