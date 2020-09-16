using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
   public UIController _controller;

   public void OnCollisionEnter(Collision other)
   {
      _controller.Popup();
   }
}