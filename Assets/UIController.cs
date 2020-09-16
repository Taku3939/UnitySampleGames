using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
   public Text timeText;
   public GameObject PopupItem;
   public StageController _controller;
   public float time;
   private bool isGoal;
   private void Start()
   {
      GameReset();
   }

   public void GameReset()
   {
      isGoal = false;
      PopupItem.SetActive(false);
      _controller.Generate();
      time = 0f;
   }
   public void Popup()
   {
      isGoal = true;
      PopupItem.SetActive(true);
      PopupItem.GetComponentInChildren<Button>().onClick.AddListener(GameReset);
   }
   private void Update()
   {
      
      if(!isGoal) time += Time.deltaTime;
      timeText.text = "Time : " + time.ToString();
   }
}
