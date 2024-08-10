using UnityEngine;
using UnityEngine.UI;
using CodeJay.Classes;
using CodeJay.MVC;

public class TestScripts : MonoBehaviour
{
    private Image image;

    private ObservedProperty<Color> colorProperty;



    private void Awake()
    {
        image = GetComponent<Image>();
        colorProperty = new ObservedProperty<Color>(new Color(1, 0, 0, 1));
        colorProperty.OnChangedValue += this.OnColorChanged;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            colorProperty.Value = Random.ColorHSV();
    }

    private void OnColorChanged()
    {

    }
}
