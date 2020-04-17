using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [SerializeField]
    private Player playerRef;

    [SerializeField]
    private Image[] lifeImages;

    [SerializeField]
    private Text scoreLabel;

    [SerializeField]
    private Button restartBtn;

    [SerializeField]
    private float tickRate = 0.2F;

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called before the first frame update
    private void Start()
    {
        


        if (playerRef != null)
        {
            playerRef.onPlayerDied += new Player.OnPlayerDied(OnplayerDie);
            playerRef.onPlayerHit += new Player.OnPlayerHit(OnPlayerhitten);
            playerRef.onPlayerScoreChanged += new Player.OnPlayerScoreChanged(OnPlayerScoreChange);
        }


        ToggleRestartButton(false);

        playerRef = FindObjectOfType<Player>();

        if (playerRef != null && lifeImages.Length == Player.PLAYER_LIVES)
        {
            InvokeRepeating("UpdateUI", 0F, tickRate);
        }
    }

    private void OnPlayerhitten(int delta)
    {

        for (int i = 0; i < lifeImages.Length; i ++)
        {
            if (lifeImages[i] != null && lifeImages[i].enabled)
            {
                lifeImages[i].gameObject.SetActive(playerRef.Lives >= i+1);
            }
        }

    }
    private void OnplayerDie()
    {
        if (scoreLabel != null)
            {
                scoreLabel.text = "Game Over";
            }


            ToggleRestartButton(true);
        
    }

    private void OnPlayerScoreChange(int score)
    {
        
        if (scoreLabel != null)
        {
            scoreLabel.text = playerRef.Score.ToString();
            
        }
    }


    private void ToggleRestartButton(bool val)
    {
        if (restartBtn != null)
        {
            restartBtn.gameObject.SetActive(val);
        }
    }


    
}