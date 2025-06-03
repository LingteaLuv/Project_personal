using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverUI : MonoBehaviour
{
    [Header("Drag&drop")]
    [SerializeField] private TMP_Text _text;
    
    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        StartCoroutine(WriteWords("Welcome to hell..."));
    }
   

    private IEnumerator WriteWords(string str)
    {
        StringBuilder strText = new StringBuilder();
        for (int i = 0; i < str.Length; i++)
        {
            strText.Append(str[i]);
            _text.text = strText.ToString();
            yield return new WaitForSeconds(0.1f);
        }
        
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Title");
    }
    
    private void Init()
    {

    }
}
