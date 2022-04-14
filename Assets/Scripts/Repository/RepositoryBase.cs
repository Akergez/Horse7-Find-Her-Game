using System;
using System.Collections.Generic;
using Interactors;

namespace Repository
{
    public class RepositoryBase
    {
        private Dictionary<Type, Repository> RepositoryMap;

        public void SendInitializeToAllRepositories()
        {
            foreach (var interactor in RepositoryMap)
            {
                interactor.Value.Initialize();
            }
        }

        public T GetRepository<T>() where T : Repository
        {
            return (T)RepositoryMap[typeof(T)];
        }
        public T CreateRepository<T>() where T: Repository, new ()
        {
            RepositoryMap[typeof(T)] = new T();
            return GetRepository<T>();
        }
    }
}