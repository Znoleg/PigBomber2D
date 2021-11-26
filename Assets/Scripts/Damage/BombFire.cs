using UnityEngine;

public enum FireType
{
    Straight, Center, End
}

public class BombFire : DamageSource
{
    public enum Direction
    {
        Right = 0, Down = 1, Left = 2, Up = 3
    }

    [SerializeField]
    private FireGraphics _fireGraphics;

    [SerializeField]
    private SpriteSequenceAnimation _spriteAnimation;

    [SerializeField]
    private SpriteRenderer _fireRenderer;

    public void Activate(FireType fireType, Direction direction)
    {
        const float deltaRotation = 90f;
        Vector3 defaultRotation = _fireRenderer.transform.eulerAngles;
        _fireRenderer.transform.Rotate(new Vector3(defaultRotation.x,
            defaultRotation.y, deltaRotation * (int)direction));
        
        var sprites = _fireGraphics.GetFireSprites(fireType);
        _spriteAnimation.Initialize(_fireRenderer, sprites);
        
        _spriteAnimation.OnAnimationEnd += SelfDestroy;
        _spriteAnimation.Play();
    }

    protected override bool CheckHitConditions(IHitable _)
        => true;

    private void SelfDestroy()
    {
        _spriteAnimation.OnAnimationEnd -= SelfDestroy;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IHitable hitable))
        {
            hitable.GetHit();
        }
    }
}

