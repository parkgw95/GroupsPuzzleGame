using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public int id;
    public bool selected { get; private set; }
    public MeshRenderer backplate;
    public Material backplateDefault;
    public Material backplateSelected;
    public SpriteRenderer sprite;

    private GameManager gm;

    public PShape shape { get; private set; }
    public PColor color { get; private set; }

    void Start()
    {
        selected = false;
        gm = GameObject.Find("Background Board").GetComponent<GameManager>();
        randomize();
    }

    void OnMouseDown()
    {
        if (selected)
        {
            deselect();
        } else
        {
            select();
        }
    }

    public void select()
    {
        if (selected) return;
        selected = true;
        backplate.material = backplateSelected;
        gm.selectPanel(this);
    }

    public void deselect()
    {
        if (!selected) return;
        selected = false;
        backplate.material = backplateDefault;
        gm.deselectPanel(this);
    }

    public void randomize()
    {
        changeShape((PShape)UnityEngine.Random.Range(0, 3));
        changeColor((PColor)UnityEngine.Random.Range(0, 3));
    }

    void changeShape(PShape newShape)
    {
        shape = newShape;
        if (newShape == PShape.circle)
        {
            sprite.sprite = gm.circleSprite;
        } else if (newShape == PShape.hexagon)
        {
            sprite.sprite = gm.hexagonSprite;
        } else if (newShape == PShape.diamond)
        {
            sprite.sprite = gm.diamondSprite;
        }
    }

    void changeColor(PColor newColor)
    {
        color = newColor;
        if (newColor == PColor.blue)
        {
            sprite.color = gm.blue;
        } else if (newColor == PColor.red)
        {
            sprite.color = gm.red;
        } else if (newColor == PColor.green)
        {
            sprite.color = gm.green;
        }
    }
}
