using System.Collections;
using UnityEngine;

public class tempMusicPlayer : MonoBehaviour
{
    public string musicPath = "Musics"; // Musicsフォルダのパス

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
        // Resourcesフォルダから音楽ファイルをロード
        AudioClip musicClip = Resources.Load<AudioClip>(musicPath + "/Danger"); // musicFileNameは実際のファイル名に置き換える

        if (musicClip != null)
        {
            // AudioSourceコンポーネントを取得または追加
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }

            // 音楽を再生
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