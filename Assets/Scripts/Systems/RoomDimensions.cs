using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomDimensions : MonoBehaviour
{
    public float width; // Độ rộng của phòng
    public float height; // Chiều cao của phòng

    void Awake()
    {
        // Lấy các Tilemap từ Grid
        Tilemap[] tilemaps = GetComponentsInChildren<Tilemap>();

        float minX = Mathf.Infinity;
        float minY = Mathf.Infinity;
        float maxX = Mathf.NegativeInfinity;
        float maxY = Mathf.NegativeInfinity;

        // Duyệt qua từng Tilemap để xác định kích thước của phòng
        foreach (Tilemap tilemap in tilemaps)
        {
            BoundsInt bounds = tilemap.cellBounds;
            Vector3Int position = tilemap.origin;

            // Tính toán kích thước của phòng từ cạnh trái và cạnh phải của Tilemap
            minX = Mathf.Min(minX, position.x);
            minY = Mathf.Min(minY, position.y);
            maxX = Mathf.Max(maxX, position.x + bounds.size.x);
            maxY = Mathf.Max(maxY, position.y + bounds.size.y);
        }

        // Tính toán kích thước thực tế của phòng
        width = maxX - minX;
        height = maxY - minY;
    }
}
