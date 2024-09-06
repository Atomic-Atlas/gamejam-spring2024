using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class CreepClass : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> _characterExpressions = new List<Sprite>();

    public string ExpressionFolder;

    private SpriteRenderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        if (TryGetComponent<SpriteRenderer>(out _renderer))
        {
            LoadExpressions(ExpressionFolder);
            ApplySprite("Jeremy_embarass_Outlined");
        }
        else
        {
            Debug.Log("Couldn't Find Renderer");
        }
        
    }

    /// <summary>
    /// Load images that are character expressions
    /// </summary>
    /// <param name="path">Path to the folder containing the expressions</param>
    void LoadExpressions(string path)
    {
        var expressions = Resources.LoadAll<Sprite>(path);
        _characterExpressions.AddRange(expressions);
    }

    /// <summary>
    /// Apply a sprite to the game object by name
    /// </summary>
    /// <param name="spriteName">Name of the sprite to apply</param>
    public void ApplySprite(string spriteName)
    {
        var sprite = _characterExpressions.Find(s => s.name == spriteName);
        if (sprite != null)
        {
            _renderer.sprite = sprite;
        }
        else
        {
            Debug.LogError("Sprite not found: " + spriteName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
