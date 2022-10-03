using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCasting : MonoBehaviour
{
    public static float DistanceFromTarget;
    public float ToTarget; //how far it is to the target
    Transform gun;
    void Start(){
        gun = FindObjectOfType<GunFire>().transform;
        gun.parent = transform;
        gun.localPosition = new Vector3(0.57f,-0.45f,0.88f);
        gun.localRotation =Quaternion.Euler( new Vector3(1,0,0));
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward),out hit)) {
            ToTarget = hit.distance;
			DistanceFromTarget = ToTarget;
            PlayerPrefs.SetFloat("TheCasting", DistanceFromTarget);
    }
}
}
