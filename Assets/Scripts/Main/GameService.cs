using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ServiceLocator.Utilities;
using ServiceLocator.Player;
public class GameService : GenericMonoSingleton<GameService>
{
    [SerializeField] private PlayerScriptableObject playerScriptableObject;
    public PlayerService playerService { get; private set; }
    void Start()
    {
        playerService = new PlayerService(playerScriptableObject);
    }

    // Update is called once per frame
    void Update()
    {
        playerService.Update();
    }
}
