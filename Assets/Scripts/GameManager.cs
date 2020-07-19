using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Sprite circleSprite;
    public Sprite hexagonSprite;
    public Sprite diamondSprite;

    public Color blue;
    public Color red;
    public Color green;

    private List<PanelController> selectedPanels;

    void Start()
    {
        selectedPanels = new List<PanelController>();
    }

    public void selectPanel(PanelController panel)
    {
        if (selectedPanels.Contains(panel)) return;

        selectedPanels.Add(panel);
        if (selectedPanels.Count == 3)
        {
            Debug.Log(checkGroup(selectedPanels));
            if (checkGroup(selectedPanels))
            {
                refill();
            } else
            {
                refresh();
            }
        }
    }

    public void deselectPanel(PanelController panel)
    {
        if (!selectedPanels.Contains(panel)) return;

        selectedPanels.Remove(panel);
    }

    public void refill()
    {
        List<PanelController> tmp = new List<PanelController>(selectedPanels);
        foreach (PanelController panel in tmp)
        {
            panel.randomize();
            panel.deselect();
        }
    }

    public void refresh()
    {
        List<PanelController> tmp = new List<PanelController>(selectedPanels);
        foreach (PanelController panel in tmp)
        {
            panel.deselect();
        }
    }

    bool checkGroup(List<PanelController> panels)
    {
        if (panels.Count != 3) return false;

        return (checkGroupColor(panels) && checkGroupShape(panels));
    }

    bool checkGroupShape(List<PanelController> panels)
    {
        if (panels[0].shape == panels[1].shape && panels[1].shape == panels[2].shape) return true;
        if (panels[0].shape != panels[1].shape && panels[1].shape != panels[2].shape && panels[0].shape != panels[2].shape) return true;
        return false;
    }

    bool checkGroupColor(List<PanelController> panels)
    {
        if (panels[0].color == panels[1].color && panels[1].color == panels[2].color) return true;
        if (panels[0].color != panels[1].color && panels[1].color != panels[2].color && panels[0].color != panels[2].color) return true;
        return false;
    }
}

public enum PShape { circle, hexagon, diamond };
public enum PColor { blue, red, green };
