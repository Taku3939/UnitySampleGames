using UnityEngine;

namespace UnitySampleGames.Sample001
{
    /// <summary>
    /// ステージを操作するためのクラス
    /// </summary>
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
            
            //キーボードの入力の取得
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            //回転の計算
            var newRotation = this.transform.rotation;
            newRotation *= Quaternion.AngleAxis(h, ex);
            newRotation *= Quaternion.AngleAxis(v, ey);

            //ステージを回転させる
            this.transform.rotation = newRotation;

            //ある一定の高さを下回った時に再生成を行う
            if (currentCharacter.transform.position.y < limit_h) Generate();
        }

        //玉の生成
        public void Generate()
        {
            //現在の玉の破壊
            if (currentCharacter) Destroy(currentCharacter);

            //新しい玉の生成
            currentCharacter = Instantiate(template, regeneratePoint.position, Quaternion.identity);
        }
    }
}