using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GoogleVR.GVRDemo
{
	using UnityEngine;

	[RequireComponent(typeof(Collider))]
public class Musique : MonoBehaviour {

		private Vector3 startingPosition;

		public Material inactiveMaterial;
		public Material gazedAtMaterial;

		private bool gazedAt;

		void Start()
		{
			startingPosition = transform.localPosition;
			gazedAt = false;
			SetGazedAt(false);
		}

		private void Update()
		{
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
	}
}






		
		

		
		