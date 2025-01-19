using UnityEngine;
using UnityEngine.UI;

public class PhotoBookScript : MonoBehaviour
{
    [SerializeField] private GameObject photoManager;
    PhotoManagerScript photoManagerScript;
    private RenderTexture photo;
    private int idx = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        photoManagerScript = photoManager.GetComponent<PhotoManagerScript>();
        //updatePhoto(0);
    }

    // Update is called once per frame
    void Update()
    {
        //updatePhoto(0);
    }

    public void updatePhoto()
    {
        photo = photoManagerScript.getPhoto(idx);
        GetComponent<RawImage>().texture = photo;
    }

    public void nextPhoto()
    {
        idx = Mathf.Min(photoManagerScript.getSize() - 1, idx + 1);
        updatePhoto();
    }

    public void prevPhoto()
    {
        idx = Mathf.Max(0, idx - 1);
        updatePhoto();
    }

    public void resetPhoto()
    {
        idx = photoManagerScript.getSize();
        updatePhoto();
    }
}
