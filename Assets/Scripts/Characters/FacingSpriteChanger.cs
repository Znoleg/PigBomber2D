using System;
using UnityEngine;

public class FacingSpriteChanger : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _characterRenderer;

    [SerializeField]
    private CharacterSpritesContainer _spritesContainer; // made
    // because serialization may crash therefore it is more
    // convinient to store data in SO

    public void UpdateSprite(MoveDirection moveDirection)
    {
        switch (moveDirection)
        {
            case MoveDirection.Right:
                SetSprite(_spritesContainer.FacingRight);
                break;
            case MoveDirection.Left:
                SetSprite(_spritesContainer.FacingLeft);
                break;
            case MoveDirection.Up:
                SetSprite(_spritesContainer.FacingUp);
                break;
            case MoveDirection.Down:
                SetSprite(_spritesContainer.FacingDown);
                break;
            case MoveDirection.None:
                break;
            default:
                throw new NotImplementedException(
                    $"Unknown value {moveDirection} of " +
                    $"{nameof(MoveDirection)} in {nameof(UpdateSprite)}");
        }
    }

    private void SetSprite(Sprite sprite)
        => _characterRenderer.sprite = sprite;
}
