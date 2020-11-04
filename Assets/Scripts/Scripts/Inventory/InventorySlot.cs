using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IEndDragHandler, IDragHandler
{

    [SerializeField] private Canvas canvas;
    public Image icon;
    Item item;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void AddItem (Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
            if(item.removeFromInventoryWhenUsed)
                RemoveItem();
            FindObjectOfType<InventoryUI>().ToggleUI();
        }

    }

    public void RemoveItem()
    {
        Inventory.instance.Remove(item);
    }

    //void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    //{
    //    Debug.Log("Begin dragging");
    //    canvasGroup.alpha = 0.6f;
    //    canvasGroup.blocksRaycasts = false;
    //}

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        //rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        transform.position = Input.mousePosition;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end dragging");
        //canvasGroup.alpha = 1f;
        //canvasGroup.blocksRaycasts = true;
        //transform.localPosition = Vector3.zero;

        //if (Input.GetMouseButtonUp(0))
        //{
        //    RaycastHit hitInfo;
        //    GameObject target = ReturnClickedObject(out hitInfo);
        //    if (target != null)
        //    {
        //        Debug.Log("target position :" + target.transform.position);
        //        //Convert world position to screen position.
        //        //screenPosition = Camera.main.WorldToScreenPoint(target.transform.position);
        //        //offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));
        //    }
        //}

       

        //if (isMouseDrag)
        //{
        //    //track mouse position.
        //    Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);

        //    //convert screen position to world position with offset changes.
        //    Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;

        //    //It will update target gameobject's current postion.
        //    target.transform.position = currentPosition;
        //}
    }


    //GameObject ReturnClickedObject(out RaycastHit hit)
    //{
    //    GameObject target = null;
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
    //    {
    //        target = hit.collider.gameObject;
    //    }
    //    return target;
    //}

    //void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    //{
    //    Debug.Log("on pointer down");
    //}
}
