using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "New Book", 
    menuName = "Custom/Book")]
public class BookData : ScriptableObject
{
    public string ID;

    [TextArea]
    public List<string> Pages;
}
