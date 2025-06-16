using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLoader : MonoBehaviour
{
    private Dictionary<string, string> _popupTexts;

    private void Awake()
    {
        Init();
    }
    
    private void Init()
    {
        _popupTexts = new Dictionary<string, string>();
            
        TextAsset csvFile = Resources.Load<TextAsset>("popup_texts");
        if (csvFile == null) return;

        string[] lines = csvFile.text.Split('\n');

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i].Trim();
            if (string.IsNullOrEmpty(line)) continue;

            string[] parts = line.Split(',');

            if (parts.Length >= 2)
            {
                string id = parts[0];
                string text = parts[1];

                if (parts.Length > 2)
                {
                    for (int j = 2; j < parts.Length; j++)
                    {
                        text += "," + parts[j];
                    }
                }
                _popupTexts[id] = text;
            }
        }
    }

    public string GetPopupText(string id)
    {
        return _popupTexts[id];
    }
}
