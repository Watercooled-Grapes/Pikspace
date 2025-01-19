using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PhotoManagerScript : MonoBehaviour
{
    private List<RenderTexture> photoData;
    [SerializeField] private GameObject photoDisplay;
    [SerializeField] private Camera handheldCamera;


// Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
    {
        photoData = new List<RenderTexture>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public int getSize()
    {
        return photoData.Count;
    }

    public void addPhoto(RenderTexture photo)
    {
        photoData.Add(photo);
    }

    public RenderTexture getPhoto()
    {
        return photoData.ElementAt(getSize());
    }

    public RenderTexture getPhoto(int index)
    {
        if (index < 0 || index >= getSize())
        {
            return null;
        }

        return photoData.ElementAt(index);
    }

    public void takePhoto()
    { 
        RenderTexture photoTexture = new RenderTexture(handheldCamera.targetTexture.width, handheldCamera.targetTexture.width, 16, handheldCamera.targetTexture.graphicsFormat);
        handheldCamera.Render();
        Graphics.CopyTexture(handheldCamera.targetTexture, photoTexture);
        addPhoto(photoTexture);
        photoDisplay.GetComponent<PhotoBookScript>().nextPhoto();
    }
}
