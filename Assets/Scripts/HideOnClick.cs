using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideOnClick : MonoBehaviour
{
    public GameObject parentToToggle;
    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>(); // Get the Button component
        button.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void OnClick()
    {
        parentToToggle.SetActive(!parentToToggle.activeSelf);
    }
}
