using System;
using System.Collections.Generic;
using System.IO;
using Game.Core;
using Game.SpecialMath;
using Rect = Game.SpecialMath.Rect;
using TibiaUCStudio.Forms;
using TibiaUCStudio.Core;

namespace Game.DAO
{
    public enum FrameGroupType : short
    {
        FrameGroupDefault = 0,
        FrameGroupIdle = FrameGroupDefault,
        FrameGroupMoving
    }

    public enum ThingCategory : short
    {
        ThingCategoryItem = 0,
        ThingCategoryCreature,
        ThingCategoryEffect,
        ThingCategoryMissile,
        ThingInvalidCategory,
        ThingLastCategory = ThingInvalidCategory
    }

    public enum ThingAttr : short
    {
        ThingAttrGround = 0,
        ThingAttrGroundBorder = 1,
        ThingAttrOnBottom = 2,
        ThingAttrOnTop = 3,
        ThingAttrContainer = 4,
        ThingAttrStackable = 5,
        ThingAttrForceUse = 6,
        ThingAttrMultiUse = 7,
        ThingAttrWritable = 8,
        ThingAttrWritableOnce = 9,
        ThingAttrFluidContainer = 10,
        ThingAttrSplash = 11,
        ThingAttrNotWalkable = 12,
        ThingAttrNotMoveable = 13,
        ThingAttrBlockProjectile = 14,
        ThingAttrNotPathable = 15,
        ThingAttrPickupable = 16,
        ThingAttrHangable = 17,
        ThingAttrHookSouth = 18,
        ThingAttrHookEast = 19,
        ThingAttrRotateable = 20,
        ThingAttrLight = 21,
        ThingAttrDontHide = 22,
        ThingAttrTranslucent = 23,
        ThingAttrDisplacement = 24,
        ThingAttrElevation = 25,
        ThingAttrLyingCorpse = 26,
        ThingAttrAnimateAlways = 27,
        ThingAttrMinimapColor = 28,
        ThingAttrLensHelp = 29,
        ThingAttrFullGround = 30,
        ThingAttrLook = 31,
        ThingAttrCloth = 32,
        ThingAttrMarket = 33,
        ThingAttrUsable = 34,
        ThingAttrWrapable = 35,
        ThingAttrUnwrapable = 36,
        ThingAttrTopEffect = 37,

        // additional
        ThingAttrOpacity = 100,
        ThingAttrNotPreWalkable = 101,

        ThingAttrFloorChange = 252,
        ThingAttrNoMoveAnimation = 253, // 10.10: real value is 16, but we need to do this for backwards compatibility
        ThingAttrChargeable = 254, // deprecated
        ThingLastAttr = 255
    }

    public enum SpriteMask
    {
        SpriteMaskRed = 1,
        SpriteMaskGreen,
        SpriteMaskBlue,
        SpriteMaskYellow
    }

    public class MarketData
    {
        public string Name;
        public int Category;
        public UInt16 RequiredLevel = new UInt16();
        public UInt16 RestrictVocation = new UInt16();
        public UInt16 ShowAs = new UInt16();
        public UInt16 TradeAs = new UInt16();
    }

    public class Light
    {
        public Light()
        {
            Intensity = 0;
            Color = 215;
        }

        public byte Intensity = new byte();
        public byte Color = new byte();
    }

    [Serializable]
    public class ThingType
    {
        public ThingType()
        {
            _mCategory = ThingCategory.ThingInvalidCategory;
            _mId = 0;
            _mNull = true;
            _mExactSize = 0;
            _mRealSize = 0;
    
            _mNumPatternX = _mNumPatternY = _mNumPatternZ = 0;
            _mAnimationPhases = 0;
            _mLayers = 0;
            _mElevation = 0;
            _mOpacity = 1.0f;
        }

        public void Unserialize(ushort clientId, ThingCategory category, BinaryReader fin)
        {
            _mNull = false;
            _mId = clientId;
            _mCategory = category;

            int count = 0;
            int attr = -1;
            bool done = false;
            for (int i = 0; i < (int) ThingAttr.ThingLastAttr; ++i)
            {
                count++;
                attr = fin.ReadByte();
                if (attr == (int) ThingAttr.ThingLastAttr)
                {
                    done = true;
                    break;
                }

//                if (attr == 254)
//                {
//                    continue;
//                }


                if (GameConfig.ClientVersion >= 1000)
                {
                    //             In 10.10+ all attributes from 16 and up were
                    //             * incremented by 1 to make space for 16 as
                    //             * "No Movement Animation" flag.
                    //
                    if (attr == 16)
                        attr = (int) ThingAttr.ThingAttrNoMoveAnimation;
                    else if (attr > 16)
                        attr -= 1;
                }
                else if (GameConfig.ClientVersion >= 860)
                {
                    //             Default attribute values follow
                    //             * the format of 8.6-9.86.
                    //             * Therefore no changes here.
                    //
                }
                else if (GameConfig.ClientVersion >= 780)
                {
                    //             In 7.80-8.54 all attributes from 8 and higher were
                    //             * incremented by 1 to make space for 8 as
                    //             * "Item Charges" flag.
                    //
                    if (attr == 8)
                    {
                        MAttribs[ThingAttr.ThingAttrChargeable] = true;
                        continue;
                    }
                    else if (attr > 8)
                        attr -= 1;
                }
                else if (GameConfig.ClientVersion >= 755)
                {
                    // In 7.55-7.72 attributes 23 is "Floor Change".
                    if (attr == 23)
                        attr = (int) ThingAttr.ThingAttrFloorChange;
                }
                else if (GameConfig.ClientVersion >= 740)
                {
                    //             In 7.4-7.5 attribute "Ground Border" did not exist
                    //             * attributes 1-15 have to be adjusted.
                    //             * Several other changes in the format.
                    //
                    if (attr > 0 && attr <= 15)
                        attr += 1;
                    else if (attr == 16)
                        attr = (int) ThingAttr.ThingAttrLight;
                    else if (attr == 17)
                        attr = (int) ThingAttr.ThingAttrFloorChange;
                    else if (attr == 18)
                        attr = (int) ThingAttr.ThingAttrFullGround;
                    else if (attr == 19)
                        attr = (int) ThingAttr.ThingAttrElevation;
                    else if (attr == 20)
                        attr = (int) ThingAttr.ThingAttrDisplacement;
                    else if (attr == 22)
                        attr = (int) ThingAttr.ThingAttrMinimapColor;
                    else if (attr == 23)
                        attr = (int) ThingAttr.ThingAttrRotateable;
                    else if (attr == 24)
                        attr = (int) ThingAttr.ThingAttrLyingCorpse;
                    else if (attr == 25)
                        attr = (int) ThingAttr.ThingAttrHangable;
                    else if (attr == 26)
                        attr = (int) ThingAttr.ThingAttrHookSouth;
                    else if (attr == 27)
                        attr = (int) ThingAttr.ThingAttrHookEast;
                    else if (attr == 28)
                        attr = (int) ThingAttr.ThingAttrAnimateAlways;

                    // "Multi Use" and "Force Use" are swapped
                    if (attr == (int) ThingAttr.ThingAttrMultiUse)
                        attr = (int) ThingAttr.ThingAttrForceUse;
                    else if (attr == (int) ThingAttr.ThingAttrForceUse)
                        attr = (int) ThingAttr.ThingAttrMultiUse;
                }

                switch (attr)
                {
                    case (int) ThingAttr.ThingAttrDisplacement:
                    {
                        if (GameConfig.ClientVersion >= 755)
                        {
                            _mDisplacement.X = fin.ReadUInt16();
                            _mDisplacement.Y = fin.ReadUInt16();
                        }
                        else
                        {
                            _mDisplacement.X = 8;
                            _mDisplacement.Y = 8;
                        }
                        MAttribs[(ThingAttr) attr] = true;
                        break;
                    }
                    case (int) ThingAttr.ThingAttrLight:
                    {
                        Light light = new Light();
                        light.Intensity = (byte) fin.ReadUInt16();
                        light.Color = (byte) fin.ReadUInt16();
                        MAttribs[(ThingAttr) attr] = light;
                        break;
                    }
                    case (int) ThingAttr.ThingAttrMarket:
                    {
                        MarketData market = new MarketData();
                        market.Category = fin.ReadUInt16();
                        market.TradeAs = fin.ReadUInt16();
                        market.ShowAs = fin.ReadUInt16();
                        var nameLength = fin.ReadUInt16();
                        var chars = fin.ReadChars(nameLength);
                        market.Name = new string(chars);
                        market.RestrictVocation = fin.ReadUInt16();
                        market.RequiredLevel = fin.ReadUInt16();
                        MAttribs[(ThingAttr) attr] = market;
                        break;
                    }
                    case (int) ThingAttr.ThingAttrElevation:
                    {
                        _mElevation = fin.ReadUInt16();
                        MAttribs[(ThingAttr) attr] = _mElevation;
                        break;
                    }
                    case (int) ThingAttr.ThingAttrUsable:
                    case (int) ThingAttr.ThingAttrGround:
                    case (int) ThingAttr.ThingAttrWritable:
                    case (int) ThingAttr.ThingAttrWritableOnce:
                    case (int) ThingAttr.ThingAttrMinimapColor:
                    case (int) ThingAttr.ThingAttrCloth:
                    case (int) ThingAttr.ThingAttrLensHelp:
                        MAttribs[(ThingAttr) attr] = fin.ReadUInt16();
                        ;
                        break;
                    default:
                        MAttribs[(ThingAttr) attr] = true;
                        break;
                }
                ;
//                switch (attr)
//                {
//                    case (int) ThingTypeFlags6.HAS_OFFSET:
//                    {
//                        if (GameConfig.ClientVersion >= 755)
//                        {
//                            m_displacement.x = fin.ReadUInt16();
//                            m_displacement.y = fin.ReadUInt16();
//                        }
//                        else
//                        {
//                            m_displacement.x = 8;
//                            m_displacement.y = 8;
//                        }
//                        m_attribs[(ThingAttr) attr] = true;
//                        break;
//                    }
//                    case (int) ThingTypeFlags6.HAS_LIGHT:
//                    {
//                        Light light = new Light();
//                        light.intensity = (byte) fin.ReadUInt16();
//                        light.color = (byte) fin.ReadUInt16();
//                        m_attribs[(ThingAttr) attr] = light;
//                        break;
//                    }
//                    case (int) ThingTypeFlags6.MARKET_ITEM:
//                    {
//                        MarketData market = new MarketData();
//                        market.category = fin.ReadUInt16();
//                        market.tradeAs = fin.ReadUInt16();
//                        market.showAs = fin.ReadUInt16();
//                        var nameLength = fin.ReadUInt16();
//                        market.name = new string(fin.ReadChars(nameLength));
//                        market.restrictVocation = fin.ReadUInt16();
//                        market.requiredLevel = fin.ReadUInt16();
//                        m_attribs[(ThingAttr) attr] = market;
//                        break;
//                    }
//                    case (int) ThingTypeFlags6.HAS_ELEVATION:
//                    {
//                        m_elevation = fin.ReadUInt16();
//                        m_attribs[(ThingAttr) attr] = m_elevation;
//                        break;
//                    }
//                    case (int) ThingTypeFlags6.USABLE:
//                    case (int) ThingTypeFlags6.GROUND:
//                    case (int) ThingTypeFlags6.WRITABLE:
//                    case (int) ThingTypeFlags6.WRITABLE_ONCE:
//                    case (int) ThingTypeFlags6.MINI_MAP:
//                    case (int) ThingTypeFlags6.CLOTH:
//                    case (int) ThingTypeFlags6.LENS_HELP:
//                        m_attribs[(ThingAttr) attr] = fin.ReadUInt16();
//                        ;
//                        break;
//                    default:
//                        m_attribs[(ThingAttr)attr] = true;
//                        break;
//                };
            }

            if (!done)
            {
                return;
            }

            bool hasFrameGroups = (category == ThingCategory.ThingCategoryCreature && GameConfig.GameIdleAnimations);
            groupCount = hasFrameGroups ? fin.ReadByte() : (byte) 1;

            _mAnimationPhases = 0;

            if (groupCount == 0)
            {
                _mAnimator.Add(new Animator());
            }

            for (int i = 0; i < groupCount; ++i)
            {
                uint frameGroupType = (uint) FrameGroupType.FrameGroupDefault;
                if (hasFrameGroups)
                    frameGroupType = fin.ReadByte();

                uint width = fin.ReadByte();
                uint height = fin.ReadByte();
                _mSize = new Rect(0, 0, (int) width, (int) height);
                if (width > 1 || height > 1)
                {
                    _mRealSize = fin.ReadByte();
                    _mExactSize = Math.Min(_mRealSize, Math.Max((int) width * (int) 32, (int) height * (int) 32));
                }
                else
                    _mExactSize = 32;

                _mLayers = fin.ReadByte();
                _mNumPatternX = fin.ReadByte();
                _mNumPatternY = fin.ReadByte();
                if (GameConfig.ClientVersion >= 755)
                    _mNumPatternZ = fin.ReadByte();
                else
                    _mNumPatternZ = 1;

                var groupAnimationsPhases = fin.ReadByte();
                _mAnimationPhases += groupAnimationsPhases;

                if (groupAnimationsPhases > 1 && GameConfig.GameEnhancedAnimations)
                {
                    _mAnimator.Add(new Animator());
                    _mAnimator[i].Unserialize(groupAnimationsPhases, fin);
                }
                else
                {
                    _mAnimator.Add(new Animator());
                    _mAnimator[i]._mAnimationPhases = groupAnimationsPhases;
                }

                int totalSprites = (int) _mSize.Width() * (int) _mSize.Height() * _mLayers * _mNumPatternX *
                                   _mNumPatternY *
                                   _mNumPatternZ * groupAnimationsPhases;

                if (totalSprites > 4096)
                {
                    return;
                }

                for (int x = 0; x < totalSprites; x++)
                {
                    _mSpritesIndex.Add(GameConfig.GameSpritesU32 ? (int) fin.ReadUInt32() : fin.ReadUInt16());
                }
            }

//            m_textures.resize(m_animationPhases);
//            m_texturesFramesRects.resize(m_animationPhases);
            for (int i = 0; i < _mAnimationPhases; i++)
            {
                _mTexturesFramesRects.Add(new List<Rect>());
            }
//            m_texturesFramesOriginRects.resize(m_animationPhases);
            for (int i = 0; i < _mAnimationPhases; i++)
            {
                _mTexturesFramesOriginRects.Add(new List<Rect>());
            }
//            m_texturesFramesOffsets.resize(m_animationPhases);
            for (int i = 0; i < _mAnimationPhases; i++)
            {
                _mTexturesFramesOffsets.Add(new List<Position>());
            }
        }

//        public void unserialize(UInt16 clientId, ThingCategory category, BinaryReader fin)
//        {
//            m_null = false;
//            m_id = clientId;
//            m_category = category;
//
//            int count = 0;
//            int attr = -1;
//            bool done = false;
//            for (int i = 0; i < (int) ThingAttr.ThingLastAttr; ++i)
//            {
//                count++;
//                attr = fin.ReadByte();
//                if (attr == (int) ThingAttr.ThingLastAttr)
//                {
//                    done = true;
//                    break;
//                }
//
//
//                if (GameConfig.ClientVersion >= 1000)
//                {
//                    //             In 10.10+ all attributes from 16 and up were
//                    //             * incremented by 1 to make space for 16 as
//                    //             * "No Movement Animation" flag.
//                    //
//                    if (attr == 16)
//                        attr = (int) ThingAttr.ThingAttrNoMoveAnimation;
//                    else if (attr > 16)
//                        attr -= 1;
//                }
//
//                switch (attr)
//                {
//                    case (int) ThingAttr.ThingAttrDisplacement:
//                    {
//                        m_displacement.x = fin.ReadUInt16();
//                        m_displacement.y = fin.ReadUInt16();
//                        m_attribs[(ThingAttr) attr] = m_displacement;
//                        break;
//                    }
//                    case (int) ThingAttr.ThingAttrLight:
//                    {
//                        Light light = new Light();
//                        light.intensity = (byte) fin.ReadUInt16();
//                        light.color = (byte) fin.ReadUInt16();
//                        m_attribs[(ThingAttr) attr] = light;
//                        break;
//                    }
//                    case (int) ThingAttr.ThingAttrMarket:
//                    {
//                        MarketData market = new MarketData();
//                        market.category = fin.ReadUInt16();
//                        market.tradeAs = fin.ReadUInt16();
//                        market.showAs = fin.ReadUInt16();
//                        var nameLength = fin.ReadUInt16();
//                        market.name = new string(fin.ReadChars(nameLength));
//                        market.restrictVocation = fin.ReadUInt16();
//                        market.requiredLevel = fin.ReadUInt16();
//                        m_attribs[(ThingAttr) attr] = market;
//                        break;
//                    }
//                    case (int) ThingAttr.ThingAttrElevation:
//                    {
//                        m_elevation = fin.ReadUInt16();
//                        m_attribs[(ThingAttr) attr] = m_elevation;
//                        break;
//                    }
////                    case (int) ThingAttr.ThingAttrUsable:
////                    case (int) ThingAttr.ThingAttrGround:
//                        //UnityEngine.Debug.Log("ground");
////                        fin.ReadUInt16();
////                        break;
////                    case (int) ThingAttr.ThingAttrWritable:
//                        //fin.ReadUInt16();
////                        break;
////                    case (int) ThingAttr.ThingAttrWritableOnce:
//                        //fin.ReadUInt16();
////                        break;
//                    case (int) ThingAttr.ThingAttrMinimapColor:
//                        m_attribs[(ThingAttr) attr] = fin.ReadUInt16();
//                        break;
////                    case (int) ThingAttr.ThingAttrCloth:
//                        //fin.ReadUInt16();
////                        break;
//                    case (int) ThingAttr.ThingAttrLensHelp:
//                        m_attribs[(ThingAttr) attr] = fin.ReadUInt16();
//                        break;
////                    case (int) ThingAttr.ThingAttrWrapable:
//                        //fin.ReadUInt16();
////                        break;
//                    default:
//                        m_attribs[(ThingAttr) attr] = true;
//                        break;
//                }
//                ;
//            }
//
//            if (!done)
//                UnityEngine.Debug.LogError(String.Format("corrupt data (id: {0}, category: {1}, count: {2}, lastAttr: {3})",
//                    m_id, m_category, count, attr));
//
//            bool hasFrameGroups = (category == ThingCategory.ThingCategoryCreature && GameConfig.GameIdleAnimations);
//            byte groupCount = hasFrameGroups ? fin.ReadByte() : (byte) 1;
//
//            for (int i = 0; i < groupCount; ++i)
//            {
//                byte frameGroupType = (byte) FrameGroupType.FrameGroupDefault;
//                if (hasFrameGroups)
//                    frameGroupType = fin.ReadByte();
//
//                byte width = fin.ReadByte();
//                byte height = fin.ReadByte();
//                m_size = new Rect(0, 0, width, height);
//                if (width > 1 || height > 1)
//                {
//                    m_realSize = fin.ReadByte();
//                    m_exactSize = Math.Min(m_realSize, Math.Max(width * 32, height * 32));
//                }
//                else
//                    m_exactSize = 32;
//
//                m_layers = fin.ReadByte();
//                m_numPatternX = fin.ReadByte();
//                m_numPatternY = fin.ReadByte();
//                if (GameConfig.ClientVersion >= 755)
//                    m_numPatternZ = fin.ReadByte();
//                else
//                    m_numPatternZ = 1;
//                m_animationPhases = fin.ReadByte();
//
//                if (m_animationPhases > 1 && GameConfig.GameEnhancedAnimations)
//                {
//                    m_animator = (new Animator());
//                    m_animator.unserialize(m_animationPhases, fin);
//                }
//
//                int totalSprites = ( /* area */ (int) m_size.width * (int) m_size.height) * m_layers * m_numPatternX *
//                                   m_numPatternY * m_numPatternZ * m_animationPhases;
//
//                if (totalSprites > 4096)
//                {
//                    UnityEngine.Debug.LogError("a thing type has more than 4096 sprites " + m_layers + " ID: " + clientId);
//                    return;
//                }
//
//                //m_spritesIndex.resize(totalSprites);
//                for (int x = 0; x < totalSprites; x++)
//                    m_spritesIndex.Add(GameConfig.GameSpritesU32 ? (int) fin.ReadUInt32() : fin.ReadUInt16());
//            }
//
////            m_textures.Add(m_animationPhases);
//        //m_texturesFramesRects.resize(m_animationPhases);
//        //m_texturesFramesOriginRects.resize(m_animationPhases);
//        //m_texturesFramesOffsets.resize(m_animationPhases);
//        }

        public UInt16 GetId()
        {
            return _mId;
        }

        public ThingCategory GetCategory()
        {
            return _mCategory;
        }

        public bool IsNull()
        {
            return _mNull;
        }

        public bool HasAttr(ThingAttr attr)
        {
            return MAttribs.ContainsKey(attr);
        }

        public Rect GetSize()
        {
            return _mSize;
        }

        public int GetWidth()
        {
            return (int) _mSize.Width();
        }

        public int GetHeight()
        {
            return (int) _mSize.Height();
        }

        public int GetRealSize()
        {
            return _mRealSize;
        }

        public int GetLayers()
        {
            return _mLayers;
        }

        public int GetNumPatternX()
        {
            return _mNumPatternX;
        }

        public int GetNumPatternY()
        {
            return _mNumPatternY;
        }

        public int GetNumPatternZ()
        {
            return _mNumPatternZ;
        }

        public int GetAnimationPhases()
        {
            return _mAnimationPhases;
        }

        public List<Animator> GetAnimator()
        {
            return _mAnimator;
        }

        public Position GetDisplacement()
        {
            return _mDisplacement;
        }

        public int GetDisplacementX()
        {
            return (int) GetDisplacement().X;
        }

        public int GetDisplacementY()
        {
            return (int) GetDisplacement().Y;
        }

        public int GetElevation()
        {
            return _mElevation;
        }

        public int GetGroundSpeed()
        {
            return (UInt16) MAttribs[ThingAttr.ThingAttrGround];
        }

        public int GetMaxTextLength()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrWritableOnce)
                ? (UInt16) MAttribs[ThingAttr.ThingAttrWritableOnce]
                : (UInt16) MAttribs[ThingAttr.ThingAttrWritable];
        }

        public Light GetLight()
        {
            return (Light) MAttribs[ThingAttr.ThingAttrLight];
        }

        public int GetMinimapColor()
        {
            return (UInt16) MAttribs[ThingAttr.ThingAttrMinimapColor];
        }

        public int GetLensHelp()
        {
            return (UInt16) MAttribs[ThingAttr.ThingAttrLensHelp];
        }

        public int GetClothSlot()
        {
            return (UInt16) MAttribs[ThingAttr.ThingAttrCloth];
        }

        public MarketData GetMarketData()
        {
            if (!HasAttr(ThingAttr.ThingAttrMarket)) return null;
            return (MarketData) MAttribs[ThingAttr.ThingAttrMarket];
        }

        public bool IsGround()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrGround);
        }

        public bool IsGroundBorder()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrGroundBorder);
        }

        public bool IsOnBottom()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrOnBottom);
        }

        public bool IsOnTop()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrOnTop);
        }

        public bool IsContainer()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrContainer);
        }

        public bool IsStackable()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrStackable);
        }

        public bool IsForceUse()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrForceUse);
        }

        public bool IsMultiUse()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrMultiUse);
        }

        public bool IsWritable()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrWritable);
        }

        public bool IsChargeable()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrChargeable);
        }

        public bool IsWritableOnce()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrWritableOnce);
        }

        public bool IsFluidContainer()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrFluidContainer);
        }

        public bool IsSplash()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrSplash);
        }

        public bool IsNotWalkable()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrNotWalkable);
        }

        public bool IsNotMoveable()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrNotMoveable);
        }

        public bool BlockProjectile()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrBlockProjectile);
        }

        public bool IsNotPathable()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrNotPathable);
        }

        public bool IsPickupable()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrPickupable);
        }

        public bool IsHangable()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrHangable);
        }

        public bool IsHookSouth()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrHookSouth);
        }

        public bool IsHookEast()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrHookEast);
        }

        public bool IsRotateable()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrRotateable);
        }

        public bool HasLight()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrLight);
        }

        public bool IsDontHide()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrDontHide);
        }

        public bool IsTranslucent()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrTranslucent);
        }

        public bool HasDisplacement()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrDisplacement);
        }

        public bool HasElevation()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrElevation);
        }

        public bool IsLyingCorpse()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrLyingCorpse);
        }

        public bool IsAnimateAlways()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrAnimateAlways);
        }

        public bool HasMiniMapColor()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrMinimapColor);
        }

        public bool HasLensHelp()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrLensHelp);
        }

        public bool IsFullGround()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrFullGround);
        }

        public bool IsIgnoreLook()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrLook);
        }

        public bool IsCloth()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrCloth);
        }

        public bool IsMarketable()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrMarket);
        }

        public bool IsUsable()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrUsable);
        }

        public bool IsWrapable()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrWrapable);
        }

        public bool IsUnwrapable()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrUnwrapable);
        }

        public bool IsTopEffect()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrTopEffect);
        }

        public List<int> GetSprites()
        {
            return _mSpritesIndex;
        }

        // additional
        public float GetOpacity()
        {
            return _mOpacity;
        }

        public bool IsNotPreWalkable()
        {
            return MAttribs.ContainsKey(ThingAttr.ThingAttrNotPreWalkable);
        }

        public int GetTotalSprites()
        {
            return this.GetWidth() *
                   this.GetHeight() *
                   this.GetNumPatternX() *
                   this.GetNumPatternY() *
                   this.GetNumPatternZ() *
                   this.GetAnimationPhases() *
                   this.GetLayers();
        }

        public int GetTotalTextures()
        {
            return this.GetNumPatternX() *
                   this.GetNumPatternY() *
                   this.GetNumPatternZ() *
                   this.GetAnimationPhases() *
                   this.GetLayers();
        }

        public int GetSpriteIndex(int width,
            int height,
            int layer,
            int patternX,
            int patternY,
            int patternZ,
            int frame)
        {
            return ((((((frame % this._mAnimationPhases) *
                        this._mNumPatternZ + patternZ) *
                       this._mNumPatternY + patternY) *
                      this._mNumPatternX + patternX) *
                     this._mLayers + layer) *
                    this.GetHeight() + height) *
                   this.GetWidth() + width;
        }

        public int GetTextureIndex2(int layer,
            int patternX,
            int patternY,
            int patternZ,
            int frame)
        {
            return Convert.ToInt32((((frame % this._mAnimationPhases *
                                      this._mNumPatternZ + patternZ) *
                                     this._mNumPatternY + patternY) *
                                    this._mNumPatternX + patternX) *
                                   this._mLayers + layer);
        }

        public int GetTextureIndex(int l, int x, int y, int z)
        {
            return ((l * _mNumPatternZ + z)
                    * _mNumPatternY + y)
                   * _mNumPatternX + x;
        }


        public Rect GetSpriteSheetSize()
        {
            var size = new Rect();
            size.SetWidth(this._mNumPatternZ * this._mNumPatternX * this._mLayers * this.GetWidth() *
                          SpriteManager.SpriteSize);
            size.SetHeight(this._mAnimationPhases * this._mNumPatternY * this.GetHeight() * SpriteManager.SpriteSize);
            return size;
        }

        public int GetExactSize(int layer, int xPattern, int yPattern, int zPattern, int animationPhase)
        {
            if (_mNull)
                return 0;

            //getTexture(animationPhase); // we must calculate it anyway.

            int frameIndex = GetTextureIndex(layer, xPattern, yPattern, zPattern);

            Size size = _mTexturesFramesOriginRects[animationPhase][frameIndex].Size() -
                        _mTexturesFramesOffsets[animationPhase][frameIndex].ToSize();

            return Math.Max(size.Width(), size.Height());
        }
        public Size GetBestTextureDimension(int w, int h, int count)

        {

            const int MAX = 32;



            int k = 1;

            while(k < w)

                k<<=1;

            w = k;



            k = 1;

            while(k < h)

                k<<=1;

            h = k;



            int numSprites = w*h*count;



            Size bestDimension = new Size(MAX, MAX);

            for(int i=w;i<=MAX;i<<=1) {

                for(int j=h;j<=MAX;j<<=1) {

                    Size candidateDimension = new Size(i, j);

                    if(candidateDimension.Area() < numSprites)

                        continue;

                    if((candidateDimension.Area() < bestDimension.Area()) ||

                       (candidateDimension.Area() == bestDimension.Area() && candidateDimension.Width() + candidateDimension.Height() < bestDimension.Width() + bestDimension.Height()))

                        bestDimension = candidateDimension;

                }

            }



            return bestDimension;

        }
//C++ TO C# CONVERTER NOTE: This was formerly a static local variable declaration (not allowed in C#):

        public ThingCategory _mCategory;
        public UInt16 _mId = new UInt16();
        public bool _mNull;
        public Dictionary<ThingAttr, object> MAttribs = new Dictionary<ThingAttr, object>();

        public Rect _mSize = new Rect();
        public Position _mDisplacement = new Position(0, 0, 0);
        public List<Animator> _mAnimator = new List<Animator>();
        public byte groupCount;
        public int _mAnimationPhases;
        public int _mExactSize;
        public int _mRealSize;
        public int _mNumPatternX;
        public int _mNumPatternY;
        public int _mNumPatternZ;
        public int _mLayers;
        public int _mElevation;
        public float _mOpacity;
        public string _mCustomImage;

        public List<int> _mSpritesIndex = new List<int>();
        public List<List<Rect>> _mTexturesFramesRects = new List<List<Rect>>();
        public List<List<Rect>> _mTexturesFramesOriginRects = new List<List<Rect>>();
        public List<List<Position>> _mTexturesFramesOffsets = new List<List<Position>>();
    }
}