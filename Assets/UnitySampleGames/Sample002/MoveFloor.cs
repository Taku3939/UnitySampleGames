using UnityEngine;

namespace UnitySampleGames.Sample002
{
    public class MoveFloor : MonoBehaviour
    {
        [SerializeField] private float speed = 1, min, max;

        private void Update()
        {
            //入力の取得
            var h = Input.GetAxis("Horizontal");

            //現在の位置座標の取得
            var pos = transform.position;

            //最小値、最大値の間で移動するように計算
            pos = new Vector3(
                Mathf.Clamp(pos.x + h * speed, min, max),
                pos.y,
                pos.z);

            //代入
            transform.position = pos;
        }
    }
}