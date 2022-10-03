using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyRotation : MonoBehaviour {

    public float RotateSpeed = 0.5f;

	void Update () {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * RotateSpeed);
	}
}
