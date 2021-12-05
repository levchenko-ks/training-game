using UnityEngine;
using UnityEngine.UI;

public class TaskWidget : BaseView, ITaskWidget
{
    public Text Name;
    public Text Description;
    public Image CheckMark;

    private Color _baseColor;
    private Color _doneColor;


    private void Awake()
    {
        _baseColor = Description.color;
        _doneColor = _baseColor;
        _doneColor.a = 0.5f;
    }

    public void SetCheckMark(bool done)
    {
        
        if (done)
        {
            CheckMark.enabled = true;
            Description.color = _doneColor;
        }
        else
        {
            CheckMark.enabled = false;
            Description.color = _baseColor;
        }
    }

    public void SetDescription(string description)
    {
        Description.text = description;
    }

    public void SetName(string name)
    {
        Name.text = name;
    }
}
