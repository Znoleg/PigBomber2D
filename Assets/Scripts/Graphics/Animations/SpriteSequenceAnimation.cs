using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SpriteSequenceAnimation : AnimationBase
{
    private SpriteRenderer _source;
    private IEnumerable<Sprite> _forwardSprites;

    private float _frameTime;

    public override event Action OnAnimationEnd;

    public void Initialize(SpriteRenderer source, 
        IReadOnlyCollection<Sprite> sprites)
    {
        _source = source;
        _forwardSprites = sprites;
        _frameTime = AnimationTime / sprites.Count;
    }

    public override void Play(int loops = 1)
        => StartCoroutine(PlaySequence(_forwardSprites, loops));

    private IEnumerator PlaySequence(IEnumerable<Sprite> sprites, 
        int loops)
    {
        if (_source == null)
        {
            throw new InvalidOperationException($"Can't play animation " +
                $"before initialization in {GetType().Name}");
        }
        for (int i = 1; i <= loops; i++)
        {
            foreach (Sprite sprite in sprites)
            {
                yield return new WaitForSeconds(_frameTime);
                SetSRSprite(sprite);
            }
        }
        
        OnAnimationEnd?.Invoke();
    }

    private void SetSRSprite(Sprite sprite)
    {
        _source.sprite = sprite;
    }
}

