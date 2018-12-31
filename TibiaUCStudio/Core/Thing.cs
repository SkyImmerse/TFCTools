using System;
using System.Collections.Generic;
using Game.SpecialMath;
using Rect = Game.SpecialMath.Rect;
using TibiaUCStudio.Forms;

namespace Game.DAO
{
    public class Thing
    {
        public Thing()
        {
            DatId = 0;
        }

        public int StackPos = -1;

        public int Order = -1;

        public int GetStackPriority()
        {
            if (IsGround())
                return 0;
            else if (IsGroundBorder())
                return 1;
            else if (IsOnBottom())
                return 2;
            else if (IsOnTop())
                return 3;
            else if (IsCreature())
                return 4;
            else // common items
                return 5;
        }

        public virtual void CalculatePatterns(ref int xPattern, ref int yPattern, ref int zPattern)
        {
            
        }


        public virtual bool IsItem()
        {
            return MIsItem;
        }

        public virtual bool IsEffect()
        {
            return MIsEffect;
        }

        public virtual bool IsMissile()
        {
            return MIsMissile;
        }

        public virtual bool IsCreature()
        {
            return MIsCreature;
        }

        public virtual bool IsNpc()
        {
            return false;
        }

        public virtual bool IsMonster()
        {
            return false;
        }

        public virtual bool IsPlayer()
        {
            return false;
        }

        public virtual bool IsLocalPlayer()
        {
            return false;
        }

        public virtual bool IsAnimatedText()
        {
            return false;
        }

        public virtual bool IsStaticText()
        {
            return false;
        }

        // type shortcuts
        public virtual ThingType GetThingType()
        {
            return ThingTypeManager.GetNullThingType();
        }

        public virtual ThingType RawGetThingType()
        {
            return MainForm.TTM.GetThingType(DatId,
                IsItem() ? ThingCategory.ThingCategoryItem : IsCreature() ? ThingCategory.ThingCategoryCreature : IsMissile() ? ThingCategory.ThingCategoryMissile : IsEffect() ? ThingCategory.ThingCategoryEffect : ThingCategory.ThingInvalidCategory);
        }

        public Rect GetSize()
        {
            return RawGetThingType().GetSize();
        }

        public int GetWidth()
        {
            return RawGetThingType().GetWidth();
        }

        public int GetHeight()
        {
            return RawGetThingType().GetHeight();
        }

        public virtual Position GetDisplacement()
        {
            return RawGetThingType().GetDisplacement();
        }

        public virtual int GetDisplacementX()
        {
            return RawGetThingType().GetDisplacementX();
        }

        public virtual int GetDisplacementY()
        {
            return RawGetThingType().GetDisplacementY();
        }

        public virtual int GetExactSize(int layer, int xPattern, int yPattern, int zPattern, int animationPhase)
        {
            return RawGetThingType().GetExactSize(layer, xPattern, yPattern, zPattern, animationPhase);
        }

        public int GetLayers()
        {
            return RawGetThingType().GetLayers();
        }

        public int GetNumPatternX()
        {
            return RawGetThingType().GetNumPatternX();
        }

        public int GetNumPatternY()
        {
            return RawGetThingType().GetNumPatternY();
        }

        public int GetNumPatternZ()
        {
            return RawGetThingType().GetNumPatternZ();
        }

        public int GetAnimationPhases()
        {
            return RawGetThingType().GetAnimationPhases();
        }
        

        public int GetGroundSpeed()
        {
            return RawGetThingType().GetGroundSpeed();
        }

        public int GetMaxTextLength()
        {
            return RawGetThingType().GetMaxTextLength();
        }

        public Light GetLight()
        {
            return RawGetThingType().GetLight();
        }

        public int GetMinimapColor()
        {
            return RawGetThingType().GetMinimapColor();
        }

        public int GetLensHelp()
        {
            return RawGetThingType().GetLensHelp();
        }

        public int GetClothSlot()
        {
            return RawGetThingType().GetClothSlot();
        }

        public int GetElevation()
        {
            return RawGetThingType().GetElevation();
        }

        public bool IsGround()
        {
            return RawGetThingType().IsGround();
        }

        public bool IsGroundBorder()
        {
            return RawGetThingType().IsGroundBorder();
        }

        public bool IsOnBottom()
        {
            return RawGetThingType().IsOnBottom();
        }

        public bool IsOnTop()
        {
            return RawGetThingType().IsOnTop();
        }

        public bool IsContainer()
        {
            return RawGetThingType().IsContainer();
        }

        public bool IsStackable()
        {
            return RawGetThingType().IsStackable();
        }

        public bool IsForceUse()
        {
            return RawGetThingType().IsForceUse();
        }

        public bool IsMultiUse()
        {
            return RawGetThingType().IsMultiUse();
        }

        public bool IsWritable()
        {
            return RawGetThingType().IsWritable();
        }

        public bool IsChargeable()
        {
            return RawGetThingType().IsChargeable();
        }

        public bool IsWritableOnce()
        {
            return RawGetThingType().IsWritableOnce();
        }

        public bool IsFluidContainer()
        {
            return RawGetThingType().IsFluidContainer();
        }

        public bool IsSplash()
        {
            return RawGetThingType().IsSplash();
        }

        public bool IsNotWalkable()
        {
            return RawGetThingType().IsNotWalkable();
        }

        public bool IsNotMoveable()
        {
            return RawGetThingType().IsNotMoveable();
        }

        public bool BlockProjectile()
        {
            return RawGetThingType().BlockProjectile();
        }

        public bool IsNotPathable()
        {
            return RawGetThingType().IsNotPathable();
        }

        public bool IsPickupable()
        {
            return RawGetThingType().IsPickupable();
        }

        public bool IsHangable()
        {
            return RawGetThingType().IsHangable();
        }

        public bool IsHookSouth()
        {
            return RawGetThingType().IsHookSouth();
        }

        public bool IsHookEast()
        {
            return RawGetThingType().IsHookEast();
        }

        public bool IsRotateable()
        {
            return RawGetThingType().IsRotateable();
        }

        public bool HasLight()
        {
            return RawGetThingType().HasLight();
        }

        public bool IsDontHide()
        {
            return RawGetThingType().IsDontHide();
        }

        public bool IsTranslucent()
        {
            return RawGetThingType().IsTranslucent();
        }

        public bool HasDisplacement()
        {
            return RawGetThingType().HasDisplacement();
        }

        public bool HasElevation()
        {
            return RawGetThingType().HasElevation();
        }

        public bool IsLyingCorpse()
        {
            return RawGetThingType().IsLyingCorpse();
        }

        public bool IsAnimateAlways()
        {
            return RawGetThingType().IsAnimateAlways();
        }

        public bool HasMiniMapColor()
        {
            return RawGetThingType().HasMiniMapColor();
        }

        public bool HasLensHelp()
        {
            return RawGetThingType().HasLensHelp();
        }

        public bool IsFullGround()
        {
            return RawGetThingType().IsFullGround();
        }

        public bool IsIgnoreLook()
        {
            return RawGetThingType().IsIgnoreLook();
        }

        public bool IsCloth()
        {
            return RawGetThingType().IsCloth();
        }

        public bool IsMarketable()
        {
            return RawGetThingType().IsMarketable();
        }

        public bool IsUsable()
        {
            return RawGetThingType().IsUsable();
        }

        public bool IsWrapable()
        {
            return RawGetThingType().IsWrapable();
        }

        public bool IsUnwrapable()
        {
            return RawGetThingType().IsUnwrapable();
        }

        public bool IsTopEffect()
        {
            return RawGetThingType().IsTopEffect();
        }
//    public MarketData getMarketData()
//    {
//        return rawGetThingType().getMarketData();
//    }

        public virtual void OnAppear()
        {
        }

        public virtual void OnDisappear()
        {
        }

        public Position Position = new Position(0, 0, 0);
        public UInt16 DatId = new UInt16();
        public bool MIsItem;
        public bool MIsEffect;
        public bool MIsMissile;
        public bool MIsCreature;

        public Position GetPosition()
        {
            return Position;
        }
    }
}