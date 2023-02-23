using TMPro;
using UnityEngine;

public class TileController : MonoBehaviour {
    public int tileNumber;
    private Transform _transform;

    private void Awake() {
        _transform = GetComponent<Transform>();
    }
    void Start() {
        TextMeshPro textMesh = GetComponentInChildren<TextMeshPro>();
        textMesh.text = tileNumber.ToString();
    }

    public void MoveTile() {
            GameObject emptyTile = GameManager.Instance.EmptyTile;
            if (Vector2.Distance(emptyTile.transform.position, _transform.position) < 1) {
                Vector3 temp = emptyTile.transform.position;
                emptyTile.transform.position = _transform.position;
                _transform.position = temp;
                SoundManager.Instance.TileSound.Play();
                UIManager.Instance.DisplayAttempt();
                GameManager.Instance.CheckWin();
            }
    }
}