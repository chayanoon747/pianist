using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // นำเข้าตัวจัดการ Scene

public class PianoGameController : MonoBehaviour
{
    public GameObject[] notePrefabs; // Prefab ของโน้ต
    public Transform[] spawnPositions; // ตำแหน่งที่โน้ตจะเริ่มเลื่อนลง (4 ช่องสำหรับ A, S, J, K)
    private List<(string noteKey, float timeToSpawn, float speed)> noteSequence = new List<(string, float, float)>{};
    
    // ลำดับโน้ตที่ต้องการสร้างตามเวลา
    private List<(string noteKey, float timeToSpawn, float speed)> noteSequence1 = new List<(string, float, float)>
    {
        ("J", 5.5f, 25f),
        ("K", 6.2f, 25f),   
        ("S", 6.3f, 25f),
        ("A", 7.0f, 25f), 
        ("A", 7.4f, 25f), 
        ("J", 7.7f, 25f),
        ("A", 8.2f, 25f),
        ("S", 9.5f, 25f),
        ("J", 9.9f, 25f),
        ("S", 10.2f, 25f),
        ("A", 10.7f, 25f),
        ("S", 11.2f, 25f),

        ("J", 13.5f, 25f),
        ("K", 14.2f, 25f), 
        ("J", 14.1f, 25f),
        ("S", 15.1f, 25f),
        ("S", 15.5f, 25f),
        ("A", 15.8f, 25f),
        ("S", 16.3f, 25f),
        ("J", 17.5f, 25f),
        ("K", 17.8f, 25f),
        ("J", 18.1f, 25f),
        ("S", 18.7f, 25f),
        ("S", 19.4f, 25f),

        ("A", 21.4f, 25f),
        ("A", 21.7f, 25f),
        ("A", 22.0f, 25f),

        ("J", 22.2f, 25f),
        ("J", 22.7f, 25f),
        ("J", 23.0f, 25f),

        ("A", 23.4f, 25f),
        ("A", 23.7f, 25f),
        ("A", 24.0f, 25f),

        ("J", 24.2f, 25f),
        ("J", 24.55f, 25f),
        ("J", 24.8f, 25f),
        ("J", 25.05f, 25f),

        ("A", 25.45f, 25f),
        ("S", 25.70f, 25f),
        ("A", 25.95f, 25f),
        ("S", 26.20f, 25f),
        ("A", 26.45f, 25f),
        ("S", 26.70f, 25f),
        ("A", 26.95f, 25f),

        ("J", 27.30f, 25f),
        ("K", 27.70f, 25f),
        ("J", 28.20f, 25f),
        ("S", 28.70f, 25f),

        ("A", 29.50f, 25f),
        ("S", 29.75f, 25f),
        ("S", 30.00f, 25f),
        ("A", 30.25f, 25f),
        ("A", 30.50f, 25f),
        ("J", 30.75f, 25f),

        ("A", 31.50f, 25f),
        ("S", 31.75f, 25f),
        ("A", 32.00f, 25f),
        ("S", 32.25f, 25f),
        ("A", 32.50f, 25f),
        ("S", 32.75f, 25f),

        ("K", 33.30f, 25f),
        ("S", 33.75f, 25f),
        ("J", 34.20f, 25f),
        ("K", 34.65f, 25f),
        ("A", 35.10f, 25f),

        ("A", 36.60f, 25f),
        ("A", 36.85f, 25f),
        ("A", 37.10f, 25f),
        ("A", 37.35f, 25f),

        ("K", 37.80f, 25f),
        ("J", 38.25f, 25f),

        ("A", 39.20f, 25f),
        ("K", 39.70f, 25f),
        ("J", 40.15f, 25f),

        ("A", 40.60f, 25f),
        ("J", 41.20f, 25f),
        ("K", 41.65f, 25f),
        ("S", 42.15f, 25f),
        ("A", 42.65f, 25f),
        ("A", 43.10f, 25f),

        ("A", 44.60f, 25f),
        ("A", 44.85f, 25f),
        ("A", 45.10f, 25f),
        ("A", 45.35f, 25f),

        ("K", 45.80f, 25f), 
        ("J", 46.25f, 25f),
 
        ("J", 47.20f, 25f), 
        ("K", 47.70f, 25f),
        ("S", 48.15f, 25f),

        ("A", 48.60f, 25f),
        ("J", 49.20f, 25f),
        ("K", 49.70f, 25f),
        ("S", 50.20f, 25f),
        ("A", 50.70f, 25f),
        ("A", 51.20f, 25f),

        ("J", 53.40f, 25f), 
        ("K", 54.10f, 25f),
        ("S", 54.25f, 25f),
        ("A", 54.95f, 25f), 
        ("A", 55.35f, 25f),
        ("J", 55.65f, 25f),
        ("A", 56.15f, 25f),
        ("S", 57.45f, 25f),
        ("J", 57.85f, 25f),
        ("S", 58.15f, 25f),
        ("A", 58.65f, 25f),
        ("S", 59.15f, 25f),

        ("J", 61.35f, 25f),
        ("K", 62.05f, 25f), 
        ("J", 62.20f, 25f),
        ("S", 63.20f, 25f),
        ("S", 63.40f, 25f),
        ("A", 63.90f, 25f),
        ("S", 64.40f, 25f),
        ("J", 65.50f, 25f),
        ("K", 65.80f, 25f),
        ("J", 66.10f, 25f),
        ("S", 66.80f, 25f),
        ("S", 67.30f, 25f),

        ("A", 68.50f, 25f),
        ("A", 68.80f, 25f),

        ("J", 69.20f, 25f),
        ("K", 69.60f, 25f),
        ("S", 70.10f, 25f),
        ("A", 70.60f, 25f),
        ("A", 71.10f, 25f),
        ("J", 72.30f, 25f),

        ("S", 73.20f, 25f),
        ("A", 73.80f, 25f),
        ("S", 74.40f, 25f),
        ("J", 74.80f, 25f),
        ("K", 75.30f, 25f),

        ("S", 76.30f, 25f),
        ("A", 77.20f, 25f),
        ("S", 77.45f, 25f),
        ("S", 77.85f, 25f),
        ("S", 78.35f, 25f),
        ("A", 78.55f, 25f),
        ("S", 78.80f, 25f),
        ("A", 79.00f, 25f),
        ("A", 79.65f, 25f),
        ("S", 79.85f, 25f),
        ("S", 80.35f, 25f),
        ("A", 80.65f, 25f),
        ("S", 80.90f, 25f),
        ("A", 81.15f, 25f),
        ("A", 81.65f, 25f),
        ("S", 81.90f, 25f),
        ("A", 82.15f, 25f),
        ("S", 82.40f, 25f),
        ("A", 82.65f, 25f),
        ("S", 82.90f, 25f),
        ("A", 83.15f, 25f),

        ("J", 83.55f, 25f),
        ("A", 83.95f, 25f),
        ("S", 84.35f, 25f),

    };

    private List<(string noteKey, float timeToSpawn, float speed)> noteSequence2 = new List<(string, float, float)>
    {
        ("J", 5.5f, 25f),
        ("K", 6.2f, 25f),   
        ("S", 6.3f, 25f),
        ("A", 7.0f, 25f), 
        ("A", 7.4f, 25f), 
        ("J", 7.7f, 25f),
        ("A", 8.2f, 25f),
        ("S", 9.5f, 25f),
        ("J", 9.9f, 25f),
        ("S", 10.2f, 25f),
        ("A", 10.7f, 25f),
        ("S", 11.2f, 25f),
    };

    void Start()
    {
        // สร้าง AudioSource และกำหนด AudioClip
        musicSource = gameObject.AddComponent<AudioSource>();
        StartCoroutine(SpawnNotesSequence());
        StartCoroutine(WaitForEndSceneTime());
    }

    public AudioClip musicClip1; // เปลี่ยนเป็น AudioClip
    public AudioClip musicClip2; // เปลี่ยนเป็น AudioClip
    private AudioSource musicSource; // อ้างอิงไปยัง AudioSource ที่เล่นเพลง
    
    public float endSceneTime1 = 87.00f;
    public float endSceneTime2 = 40.00f;

    IEnumerator SpawnNotesSequence()
    {
        switch(PlayerInfo.stage)
        {
            case 1:
                noteSequence = noteSequence1;
                musicSource.clip = musicClip1; // กำหนด AudioClip ที่ 1
                break;
            case 2:
                noteSequence = noteSequence2;
                musicSource.clip = musicClip2; // กำหนด AudioClip ที่ 2
                break;
        }

        musicSource.Play(); // เล่นเพลง

        while (noteSequence.Count > 0)
        {
            float musicTime = musicSource.time; // ใช้เวลาในเพลงแทน currentTime

            // คัดกรองโน้ตที่ควรสร้างตามเวลาในเพลง
            List<(string noteKey, float timeToSpawn, float speed)> notesToSpawn = noteSequence.FindAll(note => note.timeToSpawn <= musicTime);

            foreach (var (noteKey, timeToSpawn, speed) in notesToSpawn)
            {
                int noteIndex = GetNoteIndexFromKey(noteKey);
                if (noteIndex != -1)
                {
                    GameObject selectedNotePrefab = notePrefabs[noteIndex];
                    GameObject note = Instantiate(selectedNotePrefab, spawnPositions[noteIndex].position, Quaternion.Euler(-11f, 0f, 0f));

                    // ปรับความเร็วของโน้ต
                    NoteController noteController = note.GetComponent<NoteController>();
                    if (noteController != null)
                    {
                        noteController.speed = speed;
                    }
                }
            }

            // ลบโน้ตที่ถูกสร้างแล้ว
            noteSequence.RemoveAll(note => note.timeToSpawn <= musicTime);

            // รอเล็กน้อยก่อนสร้างโน้ตถัดไป
            yield return new WaitForSeconds(0.01f);
        }

        
    }

    IEnumerator WaitForEndSceneTime()
    {
        float endSceneTime = 0.00f;
        switch(PlayerInfo.stage)
        {
            case 1:
                endSceneTime = endSceneTime1;
                break;
            case 2:
                endSceneTime = endSceneTime2;
                break;
        }

        while (musicSource.time < endSceneTime)
        {
            yield return null; // รอจนถึงเฟรมถัดไป
        }
        SceneManager.LoadScene("EndScene"); // เปลี่ยน Scene เมื่อถึงเวลา
    }
    



    int GetNoteIndexFromKey(string key)
    {
        switch (key)
        {
            case "A": return 0;
            case "S": return 1;
            case "J": return 2;
            case "K": return 3;
            default: return -1;
        }
    }
}
