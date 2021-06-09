using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    
    public void closeCanvas()
    {
        this.gameObject.SetActive(false);
    }
}

