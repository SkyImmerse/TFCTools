using System;
using System.Collections.Generic;
using System.IO;

namespace Game.DAO

{
    public class ThingTypeManager
    {
        public bool IsLoaded = false;

        public BinaryReader _ttmReader;

        public void Init()
        {
            _mNullThingType = new ThingType();
            _mNullItemType = new ItemType();
            _mDatSignature = 0;
            _mContentRevision = 0;
            _mOtbMinorVersion = 0;
            _mOtbMajorVersion = 0;
            _mDatLoaded = false;
            _mXmlLoaded = false;
            _mOtbLoaded = false;
            for (int i = 0; i < (int) ThingCategory.ThingLastCategory; ++i)
                _mThingTypes.Add(i, new Dictionary<int, ThingType> { });

            _mItemTypes.Add(_mNullItemType);
        }

        public void Terminate()
        {
            for (int i = 0; i < (int) ThingCategory.ThingLastCategory; ++i)
                _mThingTypes[i].Clear();
            _mItemTypes.Clear();
            _mReverseItemTypes.Clear();
            _mNullThingType = null;
            _mNullItemType = null;
        }

        public void LoadDat(BinaryReader fin)
        {
            _mDatLoaded = false;
            _mDatSignature = 0;
            _mContentRevision = 0;

            var lastCategory = 0;

            var lastId = 0;

            _mDatSignature = (int) fin.ReadUInt32();
            _mContentRevision = (UInt16) (_mDatSignature);

            for (int category = 0; category < (int) ThingCategory.ThingLastCategory; ++category)
            {
                int count = fin.ReadUInt16()+1;
                _mThingTypes[category].Clear();
                for (int i = 1; i <= count; ++i)
                    _mThingTypes[category].Add(i, _mNullThingType);
            }

            for (int category = 0; category < (int) ThingCategory.ThingLastCategory; ++category)
            {
                lastCategory = category;
                UInt16 firstId = 1;
                if (category == (int) ThingCategory.ThingCategoryItem)
                    firstId = 100;
                for (   UInt16 id = firstId; id < _mThingTypes[category].Count; ++id)
                {
                    lastId = id;
                        ThingType typename = new ThingType();
                     typename.Unserialize(id, (ThingCategory) category, fin);
                    _mThingTypes[category][id] = typename;
                }
            }

            _mDatLoaded = true; 
//            }
//            catch (Exception e)
//            {
//                Debug.LogError(String.Format("Failed to read dat '{0}': {1}'", fin.BaseStream.Position + "/" + fin.BaseStream.Length, last_id));
//            }
        }


        public void AddItemType(ItemType itemType)
        {
            UInt16 id = itemType.GetServerId();
//        if(id >= m_itemTypes.Count)
//            m_itemTypes.resize(id + 1, m_nullItemType);
            _mItemTypes[id] = itemType;
        }

        public ItemType FindItemTypeByClientId(UInt16 id)
        {
            if (id == 0 || id >= _mReverseItemTypes.Count)
                return _mNullItemType;

            if (_mReverseItemTypes[id] != null)
                return _mReverseItemTypes[id];
            else
                return _mNullItemType;
        }

        internal void OpenThingsFile(FileStream fileStream)
        {
            LoadDat(new BinaryReader(fileStream, System.Text.Encoding.UTF8));
        }

        public ItemType FindItemTypeByName(string name)
        {
            foreach (ItemType it in _mItemTypes)
                if (it.GetName() == name)
                    return it;
            return _mNullItemType;
        }

        public List<ItemType> FindItemTypesByName(string name)
        {
            List<ItemType> ret = new List<ItemType>();
            foreach (ItemType it in _mItemTypes)
                if (it.GetName() == name)
                    ret.Add(it);
            return ret;
        }

        public List<ItemType> FindItemTypesByString(string name)
        {
            List<ItemType> ret = new List<ItemType>();
//        foreach(ItemType it in m_itemTypes)
//        if(it.getName().find(name) != string.Empty)
//            ret.Add(it);
            return ret;
        }

        public static ThingType GetNullThingType()
        {
            return _mNullThingType;
        }

        public ItemType GetNullItemType()
        {
            return _mNullItemType;
        }

        public ThingType GetThingType(UInt16 id, ThingCategory category)
        {
            if (category >= ThingCategory.ThingLastCategory || id >= _mThingTypes[(int) category].Count)
            {
                return _mNullThingType;
            }
            return _mThingTypes[(int) category][id];
        }

        public ItemType GetItemType(UInt16 id)
        {
            if (id >= _mItemTypes.Count || _mItemTypes[id] == _mNullItemType)
            {
                return _mNullItemType;
            }
            return _mItemTypes[id];
        }

        public ThingType RawGetThingType(UInt16 id, ThingCategory category)
        {
            return _mThingTypes[(int) category][id];
        }

        public ItemType RawGetItemType(UInt16 id)
        {
            return _mItemTypes[id];
        }

        public List<ThingType> FindThingTypeByAttr(ThingAttr attr, ThingCategory category)
        {
            List<ThingType> ret = new List<ThingType>();
            foreach (ThingType typename in _mThingTypes[(int) category].Values)
                if (typename.HasAttr(attr))
                    ret.Add(typename);
            return ret;
        }

        public List<ItemType> FindItemTypeByCategory(ItemCategory category)
        {
            List<ItemType> ret = new List<ItemType>();
            foreach (ItemType typename in _mItemTypes)
                if (typename.GetCategory() == category)
                    ret.Add(typename);
            return ret;
        }

        public Dictionary<int, ThingType> GetThingTypes(ThingCategory category)
        {
            List<ThingType> ret = new List<ThingType>();
            if (category >= ThingCategory.ThingLastCategory)
                throw new Exception(String.Format("invalid thing type category {0}", category));
            return _mThingTypes[(int)category];
        }

        public List<ItemType> GetItemTypes()
        {
            return _mItemTypes;
        }

        public int GetDatSignature()
        {
            return _mDatSignature;
        }

        public int GetOtbMajorVersion()
        {
            return _mOtbMajorVersion;
        }

        public int GetOtbMinorVersion()
        {
            return _mOtbMinorVersion;
        }

        public UInt16 GetContentRevision()
        {
            return _mContentRevision;
        }

        public bool IsDatLoaded()
        {
            return _mDatLoaded;
        }

        public bool IsXmlLoaded()
        {
            return _mXmlLoaded;
        }

        public bool IsOtbLoaded()
        {
            return _mOtbLoaded;
        }

        public bool IsValidDatId(UInt16 id, ThingCategory category)
        {
            return id >= 1 && id < _mThingTypes[(int) category].Count;
        }

        public bool IsValidOtbId(UInt16 id)
        {
            return id >= 1 && id < _mItemTypes.Count;
        }

        public Dictionary<int, Dictionary<int, ThingType>> _mThingTypes =
            new Dictionary<int, Dictionary<int, ThingType>>();

        private List<ItemType> _mReverseItemTypes = new List<ItemType>();
        private List<ItemType> _mItemTypes = new List<ItemType>();

        private static ThingType _mNullThingType = null;
        private ItemType _mNullItemType = new ItemType();

        private bool _mDatLoaded;
        private bool _mXmlLoaded;
        private bool _mOtbLoaded;

        private int _mOtbMinorVersion = new int();
        private int _mOtbMajorVersion = new int();
        private int _mDatSignature = new int();
        private UInt16 _mContentRevision = new UInt16();
    }

// vim: set ts=4 sw=4 et:
}