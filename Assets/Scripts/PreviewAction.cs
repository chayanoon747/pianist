using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewAction : MonoBehaviour
{
    public AudioClip audioClip; // ไฟล์เสียงที่คุณต้องการเล่น
    public Button playPauseButton;
    public Sprite playIcon; // ไอคอน play
    public Sprite pauseIcon; // ไอคอน pause

    private AudioSource audioSource; // ตัวควบคุมการเล่นเพลง
    private bool isPlaying = false; // สถานะการเล่นเพลง

    void Start()
    {
         // สร้าง AudioSource และตั้งค่าให้กับ audioClip
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip; // ตั้งค่า AudioSource ให้เล่นไฟล์เสียง

        // ตั้งค่าเริ่มต้นให้ปุ่มแสดงไอคอน play
        playPauseButton.image.sprite = playIcon;

        // ตั้งค่าเมื่อปุ่มถูกกดให้เรียกฟังก์ชัน TogglePlayPause
        playPauseButton.onClick.AddListener(TogglePlayPause);
    }

    void TogglePlayPause()
    {
        
        if (isPlaying)
        {
            // ถ้ากำลังเล่นเพลงอยู่ ให้หยุดเพลงและเปลี่ยนเป็นไอคอน play
            audioSource.Pause();
            playPauseButton.image.sprite = playIcon;
        }
        else
        {
            // ถ้ายังไม่ได้เล่นเพลง ให้เริ่มเล่นเพลงและเปลี่ยนเป็นไอคอน pause
            audioSource.Play();
            playPauseButton.image.sprite = pauseIcon;
        }

        // สลับสถานะการเล่นเพลง
        isPlaying = !isPlaying;
    }
}
