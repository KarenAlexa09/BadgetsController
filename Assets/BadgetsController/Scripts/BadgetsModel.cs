using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BadgetsModel
{
    [SerializeField] private List<Badget> badgetList;

    public List<Badget> BadgetList => badgetList;
}

[Serializable]
public class Badget
{
    public string badgetName;
    public BadgetType badgetType;
    public Sprite badgeImage;
}
