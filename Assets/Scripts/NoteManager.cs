using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NoteManager : MonoBehaviour
{
    private static Dictionary<string, Queue<GameObject>> notes = new Dictionary<string, Queue<GameObject>>();

    public TextMeshProUGUI scoreTextInstance; // กำหนดตัวแปร instance ไว้ใน Inspector
    public static int score;
    public static TextMeshProUGUI scoreText;

    void Start()
    {
        notes.Clear(); // ล้าง Queue ทั้งหมดใน notes
        scoreText = scoreTextInstance; // กำหนดค่า instance ให้กับตัวแปร static
    }

    public static void AddNote(string key, GameObject note)
    {
        if (!notes.ContainsKey(key))
        {
            notes[key] = new Queue<GameObject>();
        }
        notes[key].Enqueue(note); // เพิ่มโน้ตเข้าไปใน Queue
        
    }

    public static void RemoveNote(string key, GameObject note)
    {
        if (notes.ContainsKey(key))
        {
            // ใช้การลบโน้ตจาก Queue ที่มีอยู่แล้ว
            // จะต้องใช้วิธีการแบบที่คุณจะจัดการกับการลบโน้ตอย่างระมัดระวัง
            // เนื่องจาก Queue ไม่มีการเข้าถึงตามดัชนีโดยตรง
            if (notes[key].Count > 0 && notes[key].Peek() == note)
            {
                notes[key].Dequeue(); // ลบโน้ตตัวแรกออกจาก Queue

                switch(PlayerInfo.stage)
                {
                    case 1:
                        PlayerInfo.current_score_song1 += 500;
                        scoreText.text = PlayerInfo.current_score_song1.ToString();
                        break;
                    case 2:
                        PlayerInfo.current_score_song2 += 500;
                        scoreText.text = PlayerInfo.current_score_song2.ToString();
                        break;
                }
                
            }
        }
    }

    public static void DestroyNote(string key, GameObject note)
    {
        if (notes.ContainsKey(key))
        {
            // ใช้การลบโน้ตจาก Queue ที่มีอยู่แล้ว
            // จะต้องใช้วิธีการแบบที่คุณจะจัดการกับการลบโน้ตอย่างระมัดระวัง
            // เนื่องจาก Queue ไม่มีการเข้าถึงตามดัชนีโดยตรง
            if (notes[key].Count > 0 && notes[key].Peek() == note)
            {
                notes[key].Dequeue(); // ลบโน้ตตัวแรกออกจาก Queue
            }
        }
    }

    public static int GetNoteCount(string key)
    {
        return notes.ContainsKey(key) ? notes[key].Count : 0; // คืนค่าจำนวนโน้ต
    }

    public static GameObject GetFirstNote(string key)
    {
        if (notes.ContainsKey(key) && notes[key].Count > 0)
        {
            return notes[key].Peek(); // คืนค่าโน้ตตัวแรกใน Queue
        }
        return null; // คืนค่า null ถ้าไม่มีโน้ต
    }

    public static GameObject GetLastNote(string key)
    {
        if (notes.ContainsKey(key) && notes[key].Count > 0)
        {
            // สร้าง Queue ชั่วคราวเพื่อเก็บโน้ตทั้งหมด
            Queue<GameObject> tempQueue = new Queue<GameObject>(notes[key]);
            GameObject lastNote = null;

            // วนลูปเพื่อดึงโน้ตตัวสุดท้าย
            while (tempQueue.Count > 0)
            {
                lastNote = tempQueue.Dequeue(); // ค่าของ lastNote จะเป็นโน้ตตัวสุดท้ายที่ถูกจัดเก็บไว้
            }
            return lastNote;
        }
        return null; // คืนค่า null ถ้าไม่มีโน้ต
    }

}
