using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class exit_btn : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update

    public void OnPointerClick(PointerEventData e)
    {
        Application.Quit();
    }

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
