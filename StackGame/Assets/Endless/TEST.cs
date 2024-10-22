using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    public GameObject prefab; // Prefab của GameObject bạn muốn sinh ra
    public float offsetY = 2f; // Khoảng cách chồng giữa các GameObject theo trục Y
    private Stack<GameObject> objectStack = new Stack<GameObject>(); // Stack để lưu trữ các GameObject

    void Update()
    {
        // Nhấn phím Space để sinh ra GameObject mới chồng lên cái cũ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnNewObject();
        }
    }

    void SpawnNewObject()
    {
        Vector3 newPosition;

        // Nếu Stack có GameObject, đặt cái mới chồng lên cái cũ
        if (objectStack.Count > 0)
        {
            GameObject topObject = objectStack.Peek(); // Lấy GameObject ở đỉnh Stack
            newPosition = new Vector3(topObject.transform.position.x, topObject.transform.position.y + offsetY, topObject.transform.position.z);
        }
        else
        {
            // Nếu Stack rỗng, đặt GameObject mới ở vị trí gốc
            newPosition = new Vector3(0, 0, 0);
        }

        // Sinh ra GameObject mới tại vị trí được tính toán
        GameObject newObject = Instantiate(prefab, newPosition, Quaternion.identity);

        // Đưa GameObject mới vào Stack
        objectStack.Push(newObject);
    }
}
