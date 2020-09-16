using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
   public float limit_h = -20f;
   public GameObject template;
   public Transform regeneratePoint;
   
   private GameObject currentCharacter;

   private void Update()
   {
       if (!currentCharacter) return;
       Vector3 ex = Vector3.forward;
       Vector3 ey = Vector3.left;
       float h = Input.GetAxis("Horizontal");
      float v = Input.GetAxis("Vertical");

     
      var newRotation = this.transform.rotation;
      newRotation *= Quaternion.AngleAxis(h, ex);
      newRotation *= Quaternion.AngleAxis(v, ey);
      this.transform.rotation = newRotation;
      
      if (currentCharacter.transform.position.y < limit_h)
      {
          Generate();
      }   
   }
   

   public void Generate()
   {
       if(currentCharacter) Destroy(currentCharacter);
       currentCharacter = Instantiate(template, regeneratePoint.position, Quaternion.identity);
   }
}
