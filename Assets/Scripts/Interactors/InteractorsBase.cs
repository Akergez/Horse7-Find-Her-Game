using System;
using System.Collections.Generic;

namespace Interactors
{
    public class InteractorsBase
    {
        private Dictionary<Type, Interactor> InteractorsMap;

        public void SendInitializeToAllInteractors()
        {
            foreach (var interactor in InteractorsMap)
            {
                interactor.Value.Initialize();
            }
        }

        public T GetInteractor<T>() where T : Interactor
        {
            return (T)InteractorsMap[typeof(T)];
        }
        public T CreateInteractor<T>() where T: Interactor, new ()
        {
            InteractorsMap[typeof(T)] = new T();
            return GetInteractor<T>();
        }
    }
}