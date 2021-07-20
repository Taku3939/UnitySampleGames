using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnitySampleGames.Sample002;

namespace UnitySampleGames.Sample002
{
    public class UIController : MonoBehaviour, IObserver<int>
    {
        [SerializeField] private CanvasGroup UIPanel; //UI用のパネル
        [SerializeField] private Text text;
        [SerializeField] private Button button;


        [SerializeField] private MoveSphere moveSphere;

        private void Start()
        {
            moveSphere.Subscribe(this);
            button.onClick.AddListener(() => moveSphere.GameStart());
            button.onClick.AddListener(() => ShowUI(false));
        }


        /// <summary>
        /// UIを表示、非表示する
        /// </summary>
        /// <param name="isShow"></param>
        private void ShowUI(bool isShow)
        {
            UIPanel.alpha = Convert.ToInt32(isShow);
            UIPanel.interactable = isShow;
            UIPanel.blocksRaycasts = isShow;
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }


        /// <summary>
        /// 成功したときに呼ばれる
        /// </summary>
        /// <param name="count"></param>
        public void OnNext(int count)
        {
            //UIを表示
            ShowUI(true);

            var t = count == 0 ? "成功" : "失敗";
            text.text = $"残り{count.ToString()}個\n{t}";
        }
    }
}