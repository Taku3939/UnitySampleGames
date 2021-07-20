using System;
using System.Collections.Generic;

namespace UnitySampleGames.Util
{
    public class UnSubscriber<T> : IDisposable
    {
        private readonly List<IObserver<T>> _observers;
        private readonly IObserver<T> _observer;

        public UnSubscriber(List<IObserver<T>> observables, IObserver<T> observer)
        {
            this._observer = observer;
            this._observers = observables;
        }

        public void Dispose() => _observers.Remove(_observer);
    }
}