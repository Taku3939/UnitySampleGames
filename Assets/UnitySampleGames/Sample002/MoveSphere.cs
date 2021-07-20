using System;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleGames.Util;

namespace UnitySampleGames.Sample002
{
    public class MoveSphere : MonoBehaviour, IObservable<int>
    {
        [SerializeField] private float speed = 1.0f;
        [SerializeField] private GameObject target;
        [SerializeField] private GameObject prefab;
        [SerializeField] private Vector3 vec = new Vector3(1, 0, 0);
        private readonly List<IObserver<int>> _observers = new List<IObserver<int>>();

        [SerializeField] private Rigidbody rigidbody;
        private int Count => target.transform.childCount;

        private void Start()
        {
            rigidbody = this.GetComponent<Rigidbody>();
            rigidbody.velocity = new Vector3(vec.x, vec.y, 0f) * speed;
        }

        public void GameStart()
        {
            var parent = target.transform.parent;
            var pos = target.transform.position;
            Destroy(target);

            //生成
            var g = Instantiate(prefab, parent, true);
            g.transform.position = pos;
            target = g;
        }

        void OnCollisionEnter(Collision collision)
        {
            //衝突したとき、反射方向のベクトルを計算する
            foreach (var contact in collision.contacts)
            {
                var v = Vector3.Reflect(vec, contact.normal);
                vec = new Vector3(v.x, v.y, 0);
                rigidbody.velocity = new Vector3(vec.x, vec.y, 0f) * speed;
            }

            //Cubeタグが付いたオブジェクトに衝突したとき
            if (collision.gameObject.CompareTag("Cube"))
            {
                //破壊
                Destroy(collision.gameObject);

                if (Count == 0)
                    foreach (var observer in _observers)
                        observer.OnNext(Count);
            }
            //場外エリアに入った時
            else if (collision.gameObject.CompareTag("OutArea"))
            {
                //失敗
                foreach (var observer in _observers)
                    observer.OnNext(Count);
            }
        }

        public IDisposable Subscribe(IObserver<int> observer)
        {
            if (!_observers.Contains(observer)) _observers.Add(observer);
            return new UnSubscriber<int>(_observers, observer);
        }
    }
}