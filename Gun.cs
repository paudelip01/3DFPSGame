using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Gun 
{
   bool isLocked;

   public Gun(bool isLock){
isLocked = isLock;
   }

   public bool IsLocked(){
       return isLocked;
   }
}
