using UnityEngine;

public class proceduralGeneration : MonoBehaviour
{
    public GameObject[] roomPrefabs; // Mảng chứa các Prefabs của các phòng
    public int numberOfRooms = 10; // Số lượng phòng cần tạo
    public float roomSpacing = 0f; // Khoảng cách giữa các phòng

    void Start()
    {
        GenerateRooms();
    }

    void GenerateRooms()
    {
        Vector3 spawnPosition = Vector3.zero;
        float totalRoomWidth = 0f; // Tổng độ rộng của tất cả các phòng và khoảng trống giữa chúng

        for (int i = 0; i < numberOfRooms; i++)
        {
            // Chọn một prefab phòng ngẫu nhiên từ mảng
            GameObject roomPrefab = roomPrefabs[Random.Range(0, roomPrefabs.Length)];

            // Tạo một instance của prefab và đặt nó vào vị trí tiếp theo
            GameObject roomInstance = Instantiate(roomPrefab, spawnPosition, Quaternion.identity);

            // Cập nhật độ rộng tổng của các phòng và khoảng cách giữa chúng
            RoomDimensions roomDimensions = roomInstance.GetComponent<RoomDimensions>();
            totalRoomWidth += roomDimensions.width;

            // Chúng ta cần cộng thêm một khoảng trống giữa các phòng (nếu muốn)
            if (i < numberOfRooms - 1) // Chỉ cộng thêm khoảng trống nếu không phải là phòng cuối cùng
                totalRoomWidth += roomSpacing;

            // Cập nhật vị trí spawn cho phòng tiếp theo dựa trên tổng độ rộng tích lũy
            spawnPosition.x = totalRoomWidth;
        }
    }

}
