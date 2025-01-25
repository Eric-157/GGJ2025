using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameInput : MonoBehaviour
{
    public GameObject cursor;

    public List<TMP_Text> letters;

    private int selected = 0;

    public void Start()
    {
        // Otherwise things get funky
        MoveCursor();
    }

    public void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            selected += (int)Input.GetAxisRaw("Horizontal");

            // Wrap around array bounds
            if (selected < 0) selected = letters.Count - 1;
            if (selected >= letters.Count) selected = 0;

            MoveCursor();
        }

        if (Input.GetButtonDown("Vertical"))
        {
            // Evil and intimidating horse
            char fuck = (char)(letters[selected].text[0] + (int)Input.GetAxisRaw("Vertical"));

            // Wrap around the capitals
            if (fuck < 'A') fuck = 'Z';
            if (fuck > 'Z') fuck = 'A';

            letters[selected].text = fuck.ToString();
        }
    }

    public void MoveCursor()
    {
        // Who cares about parent transforms, this is way easier
        cursor.transform.position = letters[selected].transform.position;
    }

    public string Name()
    {
        // Awesome lesbian couple
        return String.Join("", from letter in letters select letter.text);
    }
}
