using UnityEngine;

public class TileGetInput : MonoBehaviour 
{
    private TileController tile;

    void Start() {
        tile = GetComponent<TileController>();
    }
    void OnMouseDown() {
        tile.MoveTile();
    }
}