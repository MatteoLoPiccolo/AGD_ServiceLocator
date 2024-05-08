using ServiceLocator.Map;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;
using ServiceLocator.Utilities;
using ServiceLocator.Wave;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    [SerializeField] private UIService uiService;
    public UIService UIService => uiService;

    [SerializeField] private PlayerScriptableObject playerScriptableObject;
    [SerializeField] private MapScriptableObject mapScriptableObject;
    [SerializeField] private SoundScriptableObject soundScriptableObject;
    [SerializeField] private WaveScriptableObject waveScriptableObject;
    [SerializeField] private AudioSource audioEffects;
    [SerializeField] private AudioSource backgroundMusic;

    public PlayerService playerService {  get; private set; }
    public SoundService soundService {  get; private set; }
    public MapService mapService {  get; private set; }
    public WaveService waveService {  get; private set; }

    private void Start()
    {
        playerService = new PlayerService(playerScriptableObject);
        soundService = new SoundService(soundScriptableObject, audioEffects, backgroundMusic);
        mapService = new MapService(mapScriptableObject);
        waveService = new WaveService(waveScriptableObject);
    }

    private void Update()
    {
        playerService.Update();
    }
}