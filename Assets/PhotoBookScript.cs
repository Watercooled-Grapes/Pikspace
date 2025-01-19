using UnityEngine;
using UnityEngine.UI;

public class PhotoBookScript : MonoBehaviour
{
    [SerializeField] GameObject photoManager;
    RenderTexture photo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        photo = photoManager.GetComponent<PhotoManagerScript>().getPhoto();
        GetComponent<RawImage>().texture = photo;
    }
}
