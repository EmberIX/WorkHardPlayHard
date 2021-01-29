using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseInteract : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{

    [SerializeField] public Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public bool isDraging;
    public bool isDrop;

    public GameObject Object;

    public Image Range;
    public GameObject R;

    //public int resourceNeed;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        //Range = GetComponentInChildren<Image>();
    }

    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("BeginDrag");
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
            isDraging = true;
            isDrop = false;

            if (R != null)
            {
                R.SetActive(true);
            }

            if (Range != null)
            {
                Range.color = new Color(Range.color.r, Range.color.g, Range.color.b, 0.34f);
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0))
        {
            //Debug.Log("Draging");
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("EndDrag");
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
            isDraging = false;


            if (isDrop == false)
            {

                
                    Instantiate(Object, transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                
            }

            if (Range != null)
            {
                Range.color = new Color(Range.color.r, Range.color.g, Range.color.b, 0f);
            }
        }
    }

    public void OnPointerDown (PointerEventData eventData)
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("MouseDown");
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        
        isDrop = true;

        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }

}

