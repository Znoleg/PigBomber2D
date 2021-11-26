using UnityEngine;

[CreateAssetMenu(fileName = "Sprite Container", 
    menuName = "ScriptableObjects/Graphics/CharacterSpriteContainer")]
public class CharacterSpritesContainer : ScriptableObject
{
    [SerializeField]
    private Sprite _facingRight;

    [SerializeField]
    private Sprite _facingLeft;

    [SerializeField]
    private Sprite _facingUp;

    [SerializeField]
    private Sprite _facingDown;

    public Sprite FacingRight => _facingRight;
    public Sprite FacingLeft => _facingLeft;
    public Sprite FacingUp => _facingUp;
    public Sprite FacingDown => _facingDown;
}
