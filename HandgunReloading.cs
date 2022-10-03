using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandgunReloading : MonoBehaviour
{
    // Start is called before the first frame update

public AudioSource ReloadSound;
public GameObject CrossObject;
public GameObject MechanicsObject;
public int ClipCount;
public int ReserveCount;
public int ReloadAvailable;
public GunFire GunComponent;

void Start () 
{
 GunComponent = GetComponent<GunFire>();
}

void Update () 
{
    ClipCount = GlobalAmmo.LoadedAmmo;
    ReserveCount = GlobalAmmo.CurrentAmmo;

 if (ReserveCount == 0) 
 {
  ReloadAvailable = 0;
 }
 
 else 
 {
  ReloadAvailable = 20 - ClipCount;
 }

 if(Input.GetButtonDown("Reload")) 
 {
  
  if (ReloadAvailable >= 1) {
   if (ReserveCount <= ReloadAvailable)
    {
        GlobalAmmo.LoadedAmmo += ReserveCount;
        GlobalAmmo.CurrentAmmo -= ReserveCount;
        ActionReload();
   }

   else 
   {
        GlobalAmmo.LoadedAmmo += ReloadAvailable;
        GlobalAmmo.CurrentAmmo -= ReloadAvailable;
        ActionReload();
   }
  }
  
 StartCoroutine(EnableScripts());

 }
}

IEnumerator EnableScripts () 
{
    yield return new WaitForSeconds (1.1f);
    GetComponent<GunFire>().enabled=true;
    CrossObject.SetActive(true);
    MechanicsObject.SetActive(true);
}

void ActionReload () 
{
    GetComponent<GunFire>().enabled=false;
    CrossObject.SetActive(false);
    MechanicsObject.SetActive(false);
    ReloadSound.Play();
    GetComponent<Animation>().Play("HandgunReload");
}
}
