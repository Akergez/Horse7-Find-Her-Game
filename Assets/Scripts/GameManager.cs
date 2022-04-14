using System;
using Interactors;
using Repository;
using UnityEngine;

public static class GameManager
{
    public static RepositoryBase RepositoryBase;
    public static InteractorsBase InteractorsBase;
    public static PlayerInteractor PlayerInteractor;
    public static PlayerRepository PlayerRepository;
    public static void Initialize()
    {
        InteractorsBase = new InteractorsBase();
        RepositoryBase = new RepositoryBase();
        PlayerInteractor = InteractorsBase.CreateInteractor<PlayerInteractor>();
        PlayerRepository = RepositoryBase.CreateRepository<PlayerRepository>();
        InteractorsBase.SendInitializeToAllInteractors();
        RepositoryBase.SendInitializeToAllRepositories();
    }
}