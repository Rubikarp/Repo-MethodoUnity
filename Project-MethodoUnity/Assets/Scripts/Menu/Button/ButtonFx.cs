using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonFx : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    Button selfButton;
    Image selfImage;

    private void Awake()
    {
        selfButton = GetComponent<Button>();
        selfImage = GetComponent<Image>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        selfImage.rectTransform.localPosition += new Vector3(0.5f, 0, 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        selfImage.rectTransform.localPosition += new Vector3(-0.5f, 0, 0);
    }
}
