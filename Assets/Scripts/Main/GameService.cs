using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ServiceLocator.Utilities;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;
public class GameService : GenericMonoSingleton<GameService>
{
    [SerializeField] private PlayerScriptableObject playerScriptableObject;
    [SerializeField] private SoundScriptableObject soundScriptableObject;
    [SerializeField] private AudioSource audioEffects;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private UIService uIService;

    public UIService UIService => uIService;
    public PlayerService playerService { get; private set; }
    public SoundService soundService { get; private set; }
    void Start()
    {
        playerService = new PlayerService(playerScriptableObject);
        soundService = new SoundService(soundScriptableObject, audioEffects, backgroundMusic);
    }

    // Update is called once per frame
    void Update()
    {
        playerService.Update();
    }
}
