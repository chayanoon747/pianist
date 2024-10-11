using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoteHandler : MonoBehaviour
{
    public string assignedKey; // คีย์ที่จับคู่กับโน้ตนี้ เช่น "A", "S", "J", "K"

    void Update()
    {
        // ตรวจสอบว่ามีการกดปุ่ม
        if (Input.GetKeyDown(GetKeyCodeFromAssignedKey(assignedKey)))
        {
            if (NoteManager.GetNoteCount(assignedKey) > 0)
            {
                GameObject firstNote = NoteManager.GetFirstNote(assignedKey); // เก็บโน้ตตัวแรกใน Queue

                // ตรวจสอบว่าตำแหน่ง z ของโน้ตอยู่ในช่วง NoteZone หรือไม่
                if (firstNote != null) // เช็คว่ามีโน้ตอยู่
                {
                    NoteController noteController = firstNote.GetComponent<NoteController>();
                    if (noteController != null && noteController.isInsideTrigger) // ใช้ isInsideTrigger จาก NoteController
                    {
                        Debug.Log("Triggering");
                        NoteManager.RemoveNote(assignedKey, firstNote); // ลบโน้ตจาก NoteManager
                        Destroy(firstNote); // ทำลายโน้ต
                    }
                    else if (!noteController.isInsideTrigger)
                    {
                        Debug.Log(firstNote.transform.position.z);
                        SceneManager.LoadScene("EndScene"); // ถ้าไม่อยู่ในโซน ให้เปลี่ยนฉาก
                    }
                }
            }
        }
    }

    public void HandleNoteForKey(string key)
    {
        // เปลี่ยนค่า assignedKey เป็น key ที่ถูกส่งเข้ามา
        assignedKey = key;
    }

    KeyCode GetKeyCodeFromAssignedKey(string key)
    {
        switch (key.ToUpper())
        {
            case "A":
                return KeyCode.A;
            case "S":
                return KeyCode.S;
            case "J":
                return KeyCode.J;
            case "K":
                return KeyCode.K;
            default:
                Debug.LogWarning("Unknown key: " + key);
                return KeyCode.None;
        }
    }
}
