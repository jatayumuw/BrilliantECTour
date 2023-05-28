using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrintObjectPosition : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject objects;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"{objects.name}-{objects.transform.position.x},{objects.transform.position.y},{objects.transform.position.z}";
    }
}
