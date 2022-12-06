using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header ("Opciones del juego")]
    [SerializeField]
    [Tooltip ("Cantidad de pickables que el jugador ha recogido")]
    public int playerScore;
    [SerializeField]
    [Tooltip("Cantidad de pickables que le quedan por recoger al jugador")]
    public int pickableNumber;
    [SerializeField]
    [Tooltip("Panel que se muestra cuando se pausa el juego")]
    public GameObject pausePanel;
    [SerializeField]
    [Tooltip("Panel que se muestra cuando se acaba el juego tras recoger todos los pickables")]
    public GameObject victoryPanel;
    [SerializeField]
    [Tooltip("Panel que se muestra cuando se acaba el juego porque muera el jugador")]
    public GameObject defeatPanel;
    [SerializeField]
    [Tooltip("Jugador")]
    public GameObject player;
    [SerializeField]
    [Tooltip("Audio que se reproduce cuando se acaba el juego tras recoger todos los pickables")]
    public AudioSource victoryMusic;
    [SerializeField]
    [Tooltip("Audio de fondo durante el juego")]
    public AudioSource backgroundMusic;

    private bool musicHasPlayed = false;
    private bool gamePaused = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        if (defeatPanel.activeSelf)
        {
            defeatPanel.SetActive(false);
        }
        Cursor.visible = false;
    }

    private void Update()
    {
        pauseGame();
        checkConditionVictory();
        checkDefeatVictory();
    }

    //Code to pause the game
    private void pauseGame()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!gamePaused)
            {
                gamePaused = true;
                Time.timeScale = 0;
                pausePanel.SetActive(true);
                Cursor.visible = true;
            } else
            {
                gamePaused = false;
                Time.timeScale = 1;
                pausePanel.SetActive(false);
                Cursor.visible = false;
            }
        }
    }

    //Code to win the game
    private void checkConditionVictory()
    {
        if (pickableNumber == 0)
        {
            Destroy(backgroundMusic);
            Time.timeScale = 0;
            victoryPanel.SetActive(true);
            if (!victoryMusic.isPlaying && !musicHasPlayed)
            {
                victoryMusic.Play();
                musicHasPlayed = true;
            }
            
        }
    }

    //Code to lose the game and restart
    private void checkDefeatVictory()
    {
        if (player.transform.position.y < -50)
        {
            defeatPanel.SetActive(true);
        }
    }

    //Code to close the game
    public void CloseGame()
    {
        Application.Quit();
    }
}
