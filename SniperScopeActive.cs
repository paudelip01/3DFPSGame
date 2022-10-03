using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperScopeActive : MonoBehaviour
{
    public GameObject playerCam;
    public GameObject sniperScopeTex;
    public GameObject originalCursor;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            playerCam.GetComponent<Camera>().fieldOfView = 25;
            sniperScopeTex.SetActive(true);
            originalCursor.SetActive(false);
        }

        if (Input.GetMouseButtonDown(1))
        {
            playerCam.GetComponent<Camera>().fieldOfView = 60;
            sniperScopeTex.SetActive(false);
            originalCursor.SetActive(true);
        }
    }
}
