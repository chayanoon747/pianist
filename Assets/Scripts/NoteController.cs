using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoteController : MonoBehaviour
{
    public string assignedKey; // คีย์ที่จับคู่กับโน้ตนี้ เช่น "A", "S", "J", "K"
    public float zoneStartZ = -412.56f; // จุดเริ่มต้นของ NoteZone ตามแกน Z
    public float zoneEndZ = -417.79f; // จุดสิ้นสุดของ NoteZone ตามแกน Z

    public float speed = 20f; // ความเร็วในการเลื่อนลง
    public bool isInsideTrigger = false; // ตัวแปรสำหรับเช็คว่าโน้ตอยู่ในช่องที่ถูกต้องหรือไม่

    void Awake()
    {
        NoteManager.AddNote(assignedKey, gameObject); // เพิ่มโน้ตที่สร้างใหม่เข้าไปใน NoteManager
    }

    void Update()
    {
        Vector3 direction = new Vector3(0f, -0.05f, -10f); // ค่า x, y, z ที่กำหนดทิศทาง (y: ลง, z: เข้ามาหาผู้เล่น)
        transform.Translate(direction.normalized * speed * Time.deltaTime);

        if (transform.position.z < -422f)
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NoteZone"))
        {
            Debug.Log("NoteZone");
            isInsideTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NoteZone"))
        {
            isInsideTrigger = false;
        }
    }

    void OnDestroy()
    {
        NoteManager.DestroyNote(assignedKey, gameObject); // ลบโน้ตออกจาก NoteManager เมื่อทำลาย
    }
}
