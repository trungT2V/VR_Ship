using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    private SequentialObjectHighlight sequentialObjectHighlight;

    void Start()
    {
        // Tìm đối tượng SequentialObjectHighlight trong scene
        sequentialObjectHighlight = FindObjectOfType<SequentialObjectHighlight>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Kiểm tra nếu object khác chạm vào chính object này
        if (sequentialObjectHighlight != null)
        {
            sequentialObjectHighlight.OnObjectInteracted(gameObject);
        }
    }
}
