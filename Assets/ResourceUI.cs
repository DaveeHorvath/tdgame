using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(100)]
public class ResourceUI : MonoBehaviour
{
    public int size;
    public GameObject textContainer;
    public GameObject textObject;
    public GameObject imageContainer;
    public GameObject imageObject;
    private List<MaterialObject> registered;
    public List<Text> fields;
    public List<Image> sprites;
    public static ResourceUI instance;
    void Start()
    {
        fields = new List<Text>();
        sprites = new List<Image>();
        registered = new List<MaterialObject>();
        if (instance != null)
            instance = this;
        UpdateValues();
    }

    public void UpdateMaterial(MaterialObject mat, float val)
    {
        if (registered.Contains(mat))
        {
            fields[registered.IndexOf(mat)].text = mat._name + ": " + val.ToString();
        }
        else
        {
            GameObject text = Instantiate(textObject, textContainer.transform);
            Text t = text.GetComponent<Text>();
            fields.Add(t);
            t.text = mat._name + ": " + val.ToString();
            GameObject image = Instantiate(imageObject, imageContainer.transform);
            Image i = image.GetComponent<Image>();
            sprites.Add(i);
            i.sprite = mat._sprite;
            registered.Add(mat);
        }
    }

    public void UpdateValues()
    {
        foreach (KeyValuePair<MaterialObject, float> f in PlayerResourcePool.instance._resources)
        {
            UpdateMaterial(f.Key, f.Value);
        }
    }
}
