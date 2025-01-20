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
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void updatePhoto()
    {
        GetComponent<RawImage>().color = new Color(1f, 1f, 1f, 1f);
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
        if (photoManagerScript.getPhoto(idx) == null)
        {
            return;
        }
        idx = photoManagerScript.getSize() - 1;
        updatePhoto();
    }

    public void deletePhoto()
    {
        photoManagerScript.removePhoto(idx);
        if (idx >= photoManagerScript.getSize())
        {
            idx = photoManagerScript.getSize() - 1;
        }
        updatePhoto();
    }
}