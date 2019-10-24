using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getImage : MonoBehaviour
{
    public string url = "https://naturealizor.github.io/Naturealizor/Nebula%20Aqua-Pink.png";
    public Texture webImage;
    
    IEnumerator GetImageFromWeb() {
        using (WWW www = new WWW(url)) {
            yield return www;
            Renderer renderer = this.GetComponent<Renderer>();
            renderer.material.mainTexture = www.texture;
            webImage = www.texture;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetImageFromWeb());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


/* 
public class ExampleClass : MonoBehaviour
{
    public string url = "http://images.earthcam.com/ec_metros/ourcams/fridays.jpg";
    IEnumerator Start()
    {
        using (WWW www = new WWW(url))
        {
            yield return www;
            Renderer renderer = GetComponent<Renderer>();
            renderer.material.mainTexture = www.texture;
        }
    }
} */