using UnityEngine;

namespace UnitySampleGames.Sample001
{
   public class Goal : MonoBehaviour
   {
      [SerializeField] private UIController controller;

      /// <summary>
      /// コライダーに何か当たった時に呼ばれる
      /// </summary>
      /// <param name="other"></param>
      public void OnCollisionEnter(Collision other)
      {
         //ゴールに何か当たった時に通知を送る
         controller.OnSuccess();
      }
   }
}