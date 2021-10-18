using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScreen 
{
    Canvas CanvasFHD { set; }
    
    void Show();
    void Hide();
}
