using System.Collections;
using UnityEngine;

public class tempMusicPlayer : MonoBehaviour
{
    public string musicPath = "Musics"; // Musics�t�H���_�̃p�X

    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(PlayMusic());
        }
    }

    IEnumerator PlayMusic()
    {
        // Resources�t�H���_���特�y�t�@�C�������[�h
        AudioClip musicClip = Resources.Load<AudioClip>(musicPath + "/Danger"); // musicFileName�͎��ۂ̃t�@�C�����ɒu��������

        if (musicClip != null)
        {
            // AudioSource�R���|�[�l���g���擾�܂��͒ǉ�
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }

            // ���y���Đ�
            audioSource.clip = musicClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Failed to load music file.");
        }

        yield return null;
    }
}