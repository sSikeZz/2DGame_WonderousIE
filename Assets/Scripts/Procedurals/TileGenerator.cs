using UnityEngine;
using UnityEngine.Tilemaps;

public class TileGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile tilePrefab;
    public int gridSize = 10;

    public float tileWidth;   
    public float tileHeight;

    void Start()
    {
        GenerateTiles();
    }

    void GenerateTiles()
    {

        for (int x = -10; x < gridSize; x++)
        {
            for (int y = -10; y <= gridSize; y++)
            {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);
                tilePosition.x = Mathf.FloorToInt(tilePosition.x * tileWidth);
                tilePosition.y = Mathf.FloorToInt(tilePosition.y * tileHeight);
                tilemap.SetTile(tilePosition, tilePrefab);

            }
        }
    }
}