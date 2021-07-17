using UnityEngine;
using UnityEngine.UI;

namespace UnitySampleGames.Sample001
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Text timeText;
        [SerializeField] private GameObject PopupItem;
        [SerializeField] private StageController _controller;

        private float time; //時間
        private bool isGoal; //ゴールしているどうかのフラグ

        
        /// <summary>
        /// 開始とともにゲームをリセットする
        /// </summary>
        private void Start() => GameReset();
        

        
        /// <summary>
        /// ゲームをリセットする
        /// </summary>
        private void GameReset()
        {
            //フラグの変更
            isGoal = false;

            //UIの非表示
            PopupItem.SetActive(false);

            //ゲームのコンティニュー
            _controller.Generate();

            //時間の初期化
            time = 0f;
        }

        
        /// <summary>
        /// ゲームがクリアされた時
        /// </summary>
        public void OnSuccess()
        {
            //フラグの変更
            isGoal = true;
            
            //UIの表示
            PopupItem.SetActive(true);
            
            //ボタンへのイベント登録
            PopupItem.GetComponentInChildren<Button>().onClick.AddListener(GameReset);
        }

        
        /// <summary>
        /// 毎フレーム呼ばれる
        /// </summary>
        private void Update()
        {
            //ゲーム中は時間を計測する
            if (!isGoal) time += Time.deltaTime;
            
            //時間を表示
            timeText.text = $"Time : {time}";
        }
    }
}