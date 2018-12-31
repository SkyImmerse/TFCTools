using System;
using System.Collections.Generic;
using System.Drawing;
using TibiaUCStudio.Forms;

namespace Game.DAO
{
    public enum ItemAttr : byte
    {
        AttrEnd = 0,

        //ATTR_DESCRIPTION = 1,
        //ATTR_EXT_FILE = 2,
        AttrTileFlags = 3,
        AttrActionId = 4,
        AttrUniqueId = 5,
        AttrText = 6,
        AttrDesc = 7,
        AttrTeleDest = 8,
        AttrItem = 9,
        AttrDepotId = 10,

        //ATTR_EXT_SPAWN_FILE = 11,
        AttrRuneCharges = 12,

        //ATTR_EXT_HOUSE_FILE = 13,
        AttrHousedoorid = 14,
        AttrCount = 15,
        AttrDuration = 16,
        AttrDecayingState = 17,
        AttrWrittendate = 18,
        AttrWrittenby = 19,
        AttrSleeperguid = 20,
        AttrSleepstart = 21,
        AttrCharges = 22,
        AttrContainerItems = 23,
        AttrName = 30,
        AttrPluralname = 31,
        AttrAttack = 33,
        AttrExtraattack = 34,
        AttrDefense = 35,
        AttrExtradefense = 36,
        AttrArmor = 37,
        AttrAttackspeed = 38,
        AttrHitchance = 39,
        AttrShootrange = 40,
        AttrArticle = 41,
        AttrScriptprotected = 42,
        AttrDualwield = 43,
        AttrAttributeMap = 128
    }

// @bindclass
//C++ TO C# CONVERTER TODO TASK: There is no equivalent to most C++ 'pragma' directives in C#:
//#pragma pack(push,1) // disable memory alignment
    public class Item : Thing, IDisposable
    {
        //C++ TO C# CONVERTER TODO TASK: There is no equivalent to most C++ 'pragma' directives in C#:
        //#pragma pack(pop)


        public Item()
        {
            _mClientId = 0;
            _mServerId = 0;
            _mCountOrSubType = 1;
            _mColor = new Color();
            _mAsync = true;
            _mPhase = 0;
            _mLastPhase = 0;
        }

//	public override void Dispose()
//	{
//		base.Dispose();
//	}
//
        public static Item Create(int id)
        {
            Item item = new Item();
            item.SetId((ushort) id);
            return item;
        }

//	public static stdext.shared_object_ptr<Item> createFromOtb(int id)
//	{
//		stdext.shared_object_ptr<Item> item = new stdext.shared_object_ptr<Item>(new Item());
//		item.setOtbId(id);
//		return item;
//	}
//
//	public new void draw(TPoint<int> dest, float scaleFactor, bool animate)
//	{
//		draw(dest, scaleFactor, animate, null);
//	}
////C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
////ORIGINAL LINE: void draw(const TPoint<int>& dest, float scaleFactor, bool animate, LightView *lightView = null)
//	public new void draw(TPoint<int> dest, float scaleFactor, bool animate, LightView lightView)
//	{
//		if(m_clientId == 0)
//			return;
//
//		// determine animation phase
//		int animationPhase = calculateAnimationPhase(animate);
//
//		// determine x,y,z patterns
//		int xPattern = 0;
//		int yPattern = 0;
//		int zPattern = 0;
//		calculatePatterns(ref xPattern, ref yPattern, ref zPattern);
//
//		if(m_color != Color.alpha)
//			g_painter.setColor(m_color);
////C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
////ORIGINAL LINE: rawGetThingType()->draw(dest, scaleFactor, 0, xPattern, yPattern, zPattern, animationPhase, lightView);
//		rawGetThingType().draw(new TPoint(dest), scaleFactor, 0, xPattern, yPattern, zPattern, animationPhase, lightView);
//
//		/// Sanity check
//		/// This is just to ensure that we don't overwrite some color and
//		/// screw up the whole rendering.
//		if(m_color != Color.alpha)
//			g_painter.resetColor();
//	}
//
        public void SetId(ushort id)
        {
            if (!MainForm.TTM.IsValidDatId(id, ThingCategory.ThingCategoryItem))
                id = 0;
            _mServerId = MainForm.TTM.FindItemTypeByClientId(id).GetServerId();
            _mClientId = id;
            DatId = id;
        }

//	public void setOtbId(UInt16 id)
//	{
//		if(!GameMain.ttm.isValidOtbId(id))
//			id = 0;
//		var itemType = GameMain.ttm.getItemType(id);
//		m_serverId = id;
//
//		id = itemType.getClientId();
//		if(!GameMain.ttm.isValidDatId(id, ThingCategory.ThingCategoryItem))
//			id = 0;
//		m_clientId = id;
//	}
        public void SetCountOrSubType(int value)
        {
            _mCountOrSubType = (byte) value;
        }

//	public void setCount(int count)
//	{
//		m_countOrSubType = count;
//	}
//	public void setSubType(int subType)
//	{
//		m_countOrSubType = subType;
//	}
//	public void setColor(Color c)
//	{
////C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
////ORIGINAL LINE: m_color = c;
//		m_color.CopyFrom(c);
//	}
//
//	public int getCountOrSubType()
//	{
//		return m_countOrSubType;
//	}
//	public int getSubType()
//	{
//		if(isSplash() || isFluidContainer())
//			return m_countOrSubType;
//		if(GlobalMembersGame.g_game.getClientVersion() > 862)
//			return 0;
//		return 1;
//	}
//	public int getCount()
//	{
//		if(isStackable())
//			return m_countOrSubType;
//		return 1;
//	}
        public new ushort GetId()
        {
            return _mClientId;
        }

//	public UInt16 getClientId()
//	{
//		return m_clientId;
//	}
//	public UInt16 getServerId()
//	{
//		return m_serverId;
//	}
//	public string getName()
//	{
//		return GameMain.ttm.findItemTypeByClientId(m_clientId).getName();
//	}
        public bool IsValid()
        {
            return MainForm.TTM.IsValidDatId(_mClientId, ThingCategory.ThingCategoryItem);
        }

//
//	public void unserializeItem(BinaryTreePtr @in)
//	{
//		try
//		{
//			while(@in.canRead())
//			{
//				int attrib = @in.getU8();
//				if(attrib == 0)
//					break;
//
//				switch(attrib)
//				{
//					case ItemAttr.ATTR_COUNT:
//					case ItemAttr.ATTR_RUNE_CHARGES:
//						setCount(@in.getU8());
//						break;
//					case ItemAttr.ATTR_CHARGES:
//						setCount(@in.getU16());
//						break;
//					case ItemAttr.ATTR_HOUSEDOORID:
//					case ItemAttr.ATTR_SCRIPTPROTECTED:
//					case ItemAttr.ATTR_DUALWIELD:
//					case ItemAttr.ATTR_DECAYING_STATE:
//						m_attribs.set(attrib, @in.getU8());
//						break;
//					case ItemAttr.ATTR_ACTION_ID:
//					case ItemAttr.ATTR_UNIQUE_ID:
//					case ItemAttr.ATTR_DEPOT_ID:
//						m_attribs.set(attrib, @in.getU16());
//						break;
//					case ItemAttr.ATTR_CONTAINER_ITEMS:
//					case ItemAttr.ATTR_ATTACK:
//					case ItemAttr.ATTR_EXTRAATTACK:
//					case ItemAttr.ATTR_DEFENSE:
//					case ItemAttr.ATTR_EXTRADEFENSE:
//					case ItemAttr.ATTR_ARMOR:
//					case ItemAttr.ATTR_ATTACKSPEED:
//					case ItemAttr.ATTR_HITCHANCE:
//					case ItemAttr.ATTR_DURATION:
//					case ItemAttr.ATTR_WRITTENDATE:
//					case ItemAttr.ATTR_SLEEPERGUID:
//					case ItemAttr.ATTR_SLEEPSTART:
//					case ItemAttr.ATTR_ATTRIBUTE_MAP:
//						m_attribs.set(attrib, @in.getU32());
//						break;
//					case ItemAttr.ATTR_TELE_DEST:
//					{
//						Position pos = new Position();
//						pos.x = @in.getU16();
//						pos.y = @in.getU16();
//						pos.z = @in.getU8();
//						m_attribs.set(attrib, pos);
//						break;
//					}
//					case ItemAttr.ATTR_NAME:
//					case ItemAttr.ATTR_TEXT:
//					case ItemAttr.ATTR_DESC:
//					case ItemAttr.ATTR_ARTICLE:
//					case ItemAttr.ATTR_WRITTENBY:
//						m_attribs.set(attrib, @in.getString());
//						break;
//					default:
//						stdext.throw_exception(GlobalMembersOutfit.format("invalid item attribute %d", attrib));
//						break;
//				}
//			}
//		}
//		catch(stdext.exception e)
//		{
//			g_logger.error(GlobalMembersOutfit.format("Failed to unserialize OTBM item: %s", e.what()));
//		}
//	}
//	public void serializeItem(OutputBinaryTreePtr @out)
//	{
//		@out.startNode(OTBM_ITEM);
//		@out.addU16(getServerId());
//
//		@out.addU8(ItemAttr.ATTR_COUNT);
//		@out.addU8(getCount());
//
//		@out.addU8(ItemAttr.ATTR_CHARGES);
//		@out.addU16(getCountOrSubType());
//
//		Position dest = m_attribs.get<Position>(ItemAttr.ATTR_TELE_DEST);
//		if(dest.isValid())
//		{
//			@out.addU8(ItemAttr.ATTR_TELE_DEST);
//			@out.addPos(dest.x, dest.y, dest.z);
//		}
//
//		if(isDepot())
//		{
//			@out.addU8(ItemAttr.ATTR_DEPOT_ID);
//			@out.addU16(getDepotId());
//		}
//
//		if(isHouseDoor())
//		{
//			@out.addU8(ItemAttr.ATTR_HOUSEDOORID);
//			@out.addU8(getDoorId());
//		}
//
//		UInt16 aid = m_attribs.get<UInt16>(ItemAttr.ATTR_ACTION_ID);
//		UInt16 uid = m_attribs.get<UInt16>(ItemAttr.ATTR_UNIQUE_ID);
//		if (aid != null)
//		{
//			@out.addU8(ItemAttr.ATTR_ACTION_ID);
//			@out.addU16(aid);
//		}
//
//		if (uid != null)
//		{
//			@out.addU8(ItemAttr.ATTR_UNIQUE_ID);
//			@out.addU16(uid);
//		}
//
//		string text = getText();
//		if(GameMain.ttm.getItemType(m_serverId).isWritable() && !string.IsNullOrEmpty(text))
//		{
//			@out.addU8(ItemAttr.ATTR_TEXT);
//			@out.addString(text);
//		}
//		string desc = getDescription();
//		if(!string.IsNullOrEmpty(desc))
//		{
//			@out.addU8(ItemAttr.ATTR_DESC);
//			@out.addString(desc);
//		}
//
//		@out.endNode();
//		for(auto i : m_containerItems)
//			i.serializeItem(@out);
//	}
//
//	public void setDepotId(UInt16 depotId)
//	{
//		m_attribs.set(ItemAttr.ATTR_DEPOT_ID, depotId);
//	}
//	public UInt16 getDepotId()
//	{
//		return m_attribs.get<UInt16>(ItemAttr.ATTR_DEPOT_ID);
//	}
//
//	public void setDoorId(byte doorId)
//	{
//		m_attribs.set(ItemAttr.ATTR_HOUSEDOORID, doorId);
//	}
//	public byte getDoorId()
//	{
//		return m_attribs.get<byte>(ItemAttr.ATTR_HOUSEDOORID);
//	}
//
//	public UInt16 getUniqueId()
//	{
//		return m_attribs.get<UInt16>(ItemAttr.ATTR_ACTION_ID);
//	}
//	public UInt16 getActionId()
//	{
//		return m_attribs.get<UInt16>(ItemAttr.ATTR_UNIQUE_ID);
//	}
//	public void setActionId(UInt16 actionId)
//	{
//		m_attribs.set(ItemAttr.ATTR_ACTION_ID, actionId);
//	}
//	public void setUniqueId(UInt16 uniqueId)
//	{
//		m_attribs.set(ItemAttr.ATTR_UNIQUE_ID, uniqueId);
//	}
//
//	public string getText()
//	{
//		return m_attribs.get<string>(ItemAttr.ATTR_TEXT);
//	}
//	public string getDescription()
//	{
//		return m_attribs.get<string>(ItemAttr.ATTR_DESC);
//	}
//	public void setDescription(string desc)
//	{
//		m_attribs.set(ItemAttr.ATTR_DESC, desc);
//	}
//	public void setText(string txt)
//	{
//		m_attribs.set(ItemAttr.ATTR_TEXT, txt);
//	}
//
//	public Position getTeleportDestination()
//	{
//		return m_attribs.get<Position>(ItemAttr.ATTR_TELE_DEST);
//	}
//	public void setTeleportDestination(Position pos)
//	{
//		m_attribs.set(ItemAttr.ATTR_TELE_DEST, pos);
//	}
//
//	public void setAsync(bool enable)
//	{
//		m_async = enable;
//	}
//
//	public bool isHouseDoor()
//	{
//		return m_attribs.has(ItemAttr.ATTR_HOUSEDOORID);
//	}
//	public bool isDepot()
//	{
//		return m_attribs.has(ItemAttr.ATTR_DEPOT_ID);
//	}
//	public new bool isContainer()
//	{
//		return m_attribs.has(ItemAttr.ATTR_CONTAINER_ITEMS);
//	}
//	public bool isDoor()
//	{
//		return m_attribs.has(ItemAttr.ATTR_HOUSEDOORID);
//	}
//	public bool isTeleport()
//	{
//		return m_attribs.has(ItemAttr.ATTR_TELE_DEST);
//	}
//	public bool isMoveable()
//	{
//		return !rawGetThingType().isNotMoveable();
//	}
//	public new bool isGround()
//	{
//		return rawGetThingType().isGround();
//	}
//
//	public stdext.shared_object_ptr<Item> clone()
//	{
//		stdext.shared_object_ptr<Item> item = new stdext.shared_object_ptr<Item>(new Item());
//		*(item.get()) = this;
//		return item;
//	}
//	public stdext.shared_object_ptr<Item> asItem()
//	{
//		return static_self_cast<Item>();
//	}
//	public new bool isItem()
//	{
//		return true;
//	}
//
//	public List<stdext.shared_object_ptr<Item>> getContainerItems()
//	{
//		return m_containerItems;
//	}
//	public stdext.shared_object_ptr<Item> getContainerItem(int slot)
//	{
//		return m_containerItems[slot];
//	}
//	public void addContainerItemIndexed(stdext.shared_object_ptr<Item> i, int slot)
//	{
//		m_containerItems[slot] = i;
//	}
//	public void addContainerItem(stdext.shared_object_ptr<Item> i)
//	{
//		m_containerItems.Add(i);
//	}
//	public void removeContainerItem(int slot)
//	{
//		m_containerItems[slot] = null;
//	}
//	public void clearContainerItems()
//	{
//		m_containerItems.Clear();
//	}
//

        public new int GetExactSize(int layer, int xPattern, int yPattern, int zPattern)
        {
            return GetExactSize(layer, xPattern, yPattern, zPattern, 0);
        }

        public new int GetExactSize(int layer, int xPattern, int yPattern)
        {
            return GetExactSize(layer, xPattern, yPattern, 0, 0);
        }

        public new int GetExactSize(int layer, int xPattern)
        {
            return GetExactSize(layer, xPattern, 0, 0, 0);
        }

        public new int GetExactSize(int layer)
        {
            return GetExactSize(layer, 0, 0, 0, 0);
        }

        public new int GetExactSize()
        {
            return GetExactSize(0, 0, 0, 0, 0);
        }
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: int getExactSize(int layer = 0, int xPattern = 0, int yPattern = 0, int zPattern = 0, int animationPhase = 0)
//	public new int getExactSize(int layer, int xPattern, int yPattern, int zPattern, int animationPhase)
//	{
//		calculatePatterns(ref xPattern, ref yPattern, ref zPattern);
//		animationPhase = calculateAnimationPhase(true);
//		return base.getExactSize(layer, xPattern, yPattern, zPattern, animationPhase);
//	}

        public new ThingType GetThingType()
        {
            return MainForm.TTM.GetThingType(_mClientId, ThingCategory.ThingCategoryItem);
        }

        public new ThingType RawGetThingType()
        {
            return MainForm.TTM.RawGetThingType(_mClientId, ThingCategory.ThingCategoryItem);
        }

        private UInt16 _mClientId = new UInt16();
        private UInt16 _mServerId = new UInt16();
        private byte _mCountOrSubType = new byte();
        private List<byte> _mAttribs = new List<byte>();
        private List<Item> _mContainerItems = new List<Item>();
        private Color _mColor = new Color();
        private bool _mAsync;

        private byte _mPhase = new byte();
        private Int64 _mLastPhase = new Int64();

        public void Dispose()
        {
        }
    }

// vim: set ts=4 sw=4 et :
}