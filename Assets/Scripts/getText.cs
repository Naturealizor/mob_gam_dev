using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class getText : MonoBehaviour
{
    public string url = "https://naturealizor.github.io/Naturealizor/hipster.txt";
    public string webText;
    public TextMeshProUGUI webTextUI;
    
    IEnumerator GetTextFromWeb() {
        using (WWW www = new WWW(url)) {
            yield return www;
            webText = www.text;
            Debug.Log(webText);
            webTextUI.text = webText;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetTextFromWeb());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}