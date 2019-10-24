using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getAudio : MonoBehaviour
{
    public string url = "https://naturealizor.github.io/Naturealizor/Long%20Lost%20Love.wav";
    public AudioClip webClip;
    public Slider progressBar;

    AudioSource aud;
    
    IEnumerator GetAudioFromWeb() {
        using (WWW www = new WWW(url)) {
            while(www.progress != 1) {
                Debug.Log(www.progress);
                progressBar.value = www.progress;
                yield return new WaitForEndOfFrame();
            }
            Debug.Log("Audio Loaded!");
            progressBar.gameObject.SetActive(false);
            // yield return www;
            webClip = www.GetAudioClip();
            aud.clip = webClip;
            aud.Play();
            Debug.Log("Audio has been played.");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        aud = this.GetComponent<AudioSource>();
        StartCoroutine(GetAudioFromWeb());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}