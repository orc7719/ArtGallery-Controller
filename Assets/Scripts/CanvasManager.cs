using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour {

    [SerializeField] float scale = 0.1f;

    public Texture pictureImage;
    public string pictureName;
    public string artistName;

    Transform pictureCanvas;
    

    [ContextMenu("Size Canvas")]
    public void SetupCanvas()
    {
        pictureCanvas = transform.Find("Canvas");
        pictureCanvas.GetComponent<Renderer>().material.SetTexture("_BaseMap", pictureImage);

        Vector2 pictureSize = new Vector2(pictureImage.width,pictureImage.height);
        float ratio = pictureSize.x / pictureSize.y;
        Vector3 pictureScale = new Vector3(1,1,1);

        bool horizontal = pictureSize.x > pictureSize.y;
        bool equal = pictureSize.x == pictureSize.y;

        if(!horizontal)
        {
            ratio = pictureSize.y / pictureSize.x;
            Debug.Log(ratio);
            Debug.Log("Vertical");
            pictureScale.x = scale;
            pictureScale.z = scale * ratio;
        }
        else if(equal)
        {
            Debug.Log("Square");
            pictureScale.x=scale;
            pictureScale.z=scale;
        }
        else
        {
            Debug.Log("Horizontal");
            pictureScale.z = scale;
            pictureScale.x = scale * ratio;
        }

        pictureCanvas.localScale = pictureScale;

        Transform textPos = transform.Find("Text");
        textPos.localPosition = new Vector3(pictureScale.x * 5 + 0.1f, -0.25f, 0);

        TextMeshPro artistNameTxt = textPos.GetChild(0).GetComponent<TextMeshPro>();
        artistNameTxt.text= artistName;
        TextMeshPro imageNameTxt = textPos.GetChild(1).GetComponent<TextMeshPro>();
        imageNameTxt.text = pictureImage.name;

    }
    Transform go;
}
