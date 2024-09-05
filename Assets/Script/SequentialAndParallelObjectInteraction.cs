using System.Collections.Generic;
using UnityEngine;

public class SequentialAndParallelObjectInteraction : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> interactionObjects; // Danh sách đơn giản hiển thị trong Inspector

    private int currentObjectIndex = 0;

    void Start()
    {
        EnableCurrentObject();
    }

    private void EnableCurrentObject()
    {
        if (currentObjectIndex < interactionObjects.Count)
        {
            interactionObjects[currentObjectIndex].GetComponent<Collider>().enabled = true;
        }
    }

    private void DisableCurrentObject()
    {
        if (currentObjectIndex < interactionObjects.Count)
        {
            interactionObjects[currentObjectIndex].GetComponent<Collider>().enabled = false;
        }
    }

    public void OnObjectInteracted(GameObject interactedObject)
    {
        if (interactionObjects[currentObjectIndex] == interactedObject)
        {
            DisableCurrentObject();
            currentObjectIndex++;

            if (currentObjectIndex < interactionObjects.Count)
            {
                EnableCurrentObject();
            }
        }
    }
}
