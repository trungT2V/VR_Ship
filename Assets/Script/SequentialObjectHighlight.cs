using System.Collections.Generic;
using UnityEngine;

public class SequentialObjectHighlight : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectsToHighlight; // Danh sách các object cần highlight, được thiết lập từ Inspector

    private int currentIndex = 0; // Chỉ số của object hiện tại
    private GameObject currentHighlight; // Object hiện đang được highlight

    void Start()
    {
        HighlightCurrentObject();
    }

    private void HighlightCurrentObject()
    {
        // Tắt highlight của object trước đó
        if (currentHighlight != null)
        {
            currentHighlight.GetComponent<Outline>().enabled = false;
        }

        // Kiểm tra nếu còn object để highlight
        if (currentIndex < objectsToHighlight.Count)
        {
            currentHighlight = objectsToHighlight[currentIndex]; // Lấy object hiện tại

            // Kích hoạt highlight
            if (currentHighlight.GetComponent<Outline>() != null)
            {
                currentHighlight.GetComponent<Outline>().enabled = true;
            }
            else
            {
                Outline outline = currentHighlight.AddComponent<Outline>();
                outline.enabled = true;
                outline.OutlineColor = Color.magenta;
                outline.OutlineWidth = 7.0f;
            }
        }
    }

    public void OnObjectInteracted(GameObject interactedObject)
    {
        // Kiểm tra xem object được tương tác có phải là object hiện tại hay không
        if (interactedObject == currentHighlight)
        {
            // Tắt highlight của object hiện tại
            currentHighlight.GetComponent<Outline>().enabled = false;

            // Chuyển sang object tiếp theo
            currentIndex++;

            // Highlight object tiếp theo nếu còn
            if (currentIndex < objectsToHighlight.Count)
            {
                HighlightCurrentObject();
            }
            else
            {
                Debug.Log("All objects have been interacted with.");
            }
        }
    }
}
