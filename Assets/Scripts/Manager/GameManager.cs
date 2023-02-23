using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour 
{
    public static GameManager Instance;
    public GameObject[] tilePlaceholders;
    public GameObject tilePrefab;
    public TileController[] tiles;
    [SerializeField] private GameObject _emptyTile = null;
    public GameObject EmptyTile => _emptyTile;
    private bool IsGameComplete = false;

    void Awake() {
        if(Instance == null)
            Instance = this;
    }
    void Start() {
        int tileCount = tilePlaceholders.Length;
        tiles = new TileController[tileCount];
        for (int i = 0; i < tileCount; i++) {
            GameObject newTile = Instantiate(tilePrefab, tilePlaceholders[i].transform);
            tiles[i] = newTile.GetComponent<TileController>();
            tiles[i].tileNumber = i+1;
        }
        ShuffleTiles();
    }

    void ShuffleTiles() {
        int tileCount = tiles.Length;
        for (int i = 0; i < tileCount; i++) {
            int randomIndex = Random.Range(i, tileCount);
            TileController temp = tiles[i];
            tiles[i] = tiles[randomIndex];
            tiles[randomIndex] = temp;
        }
        for (int i = 0; i < tileCount; i++) {
            tiles[i].transform.position = tilePlaceholders[i].transform.position;
        }
    }


    public void CheckWin() {
        int tileCount = tiles.Length;
        for (int i = 0; i < tileCount; i++) {
            if (tiles[i].tileNumber != i+1) {
                return;
            }
        }
        UIManager.Instance.WinPanel.SetActive(true);
        IsGameComplete = true;
        Debug.Log("You win!");
    }

    public void RestartGame() {
        SceneManager.LoadScene("Game");
    }

    public void TimeEnd()
    {
        if(!IsGameComplete)
        {
            UIManager.Instance.FailPanel.SetActive(true);
        }
        else
        {
            UIManager.Instance.WinPanel.SetActive(true);
        }
    }

    public void AttemptsEnd()
    {
        if(!IsGameComplete)
        {
            UIManager.Instance.FailPanel.SetActive(true);
        }
        else
        {
            UIManager.Instance.WinPanel.SetActive(true);
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }
}