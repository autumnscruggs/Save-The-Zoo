using UnityEngine;
using System.Collections;

public class SpriteHolderOnMouseDown : MonoBehaviour {

    [SerializeField]
    private AvatarUI avatarUI;
    [SerializeField]
    private DragAndDropAvatar dragNDrop;

    public void ClickedSpriteHolder()
    {
        dragNDrop.ShowThisImage(true);
        dragNDrop.canDrag = true;
        dragNDrop.ChangeSprite(avatarUI.spriteHolder.sprite);
    }
}
