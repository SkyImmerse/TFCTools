
using System.Collections.Generic;
using System.Linq;

namespace Game.DAO
{

    public enum AnonymousEnum12
    {
        TILE_PIXELS = 32,
        c = 24,

        SEA_FLOOR = 7,
        MAX_Z = 15,
        UNDERGROUND_FLOOR = AnonymousEnum12.SEA_FLOOR + 1,
        AWARE_UNDEGROUND_FLOOR_RANGE = 2,

        INVISIBLE_TICKS_PER_FRAME = 500,
        ITEM_TICKS_PER_FRAME = 500,
        ANIMATED_TEXT_DURATION = 1000,
        STATIC_DURATION_PER_CHARACTER = 60,
        MIN_STATIC_TEXT_DURATION = 3000,
        MAX_STATIC_TEXT_WIDTH = 200,
        MAX_AUTOWALK_STEPS_RETRY = 10,
        MAX_AUTOWALK_DIST = 127,
        MAX_ELEVATION = 24,
    }

    public enum DrawFlags
    {
        DrawGround = 1,
        DrawGroundBorders = 2,
        DrawOnBottom = 4,
        DrawOnTop = 8,
        DrawItems = 16,
        DrawCreatures = 32,
        DrawEffects = 64,
        DrawMissiles = 128,
        DrawCreaturesInformation = 256,
        DrawStaticTexts = 512,
        DrawAnimatedTexts = 1024,
        DrawAnimations = 2048,
        DrawBars = 4096,
        DrawNames = 8192,
        DrawLights = 16384,
        DrawWalls = DrawOnBottom | DrawOnTop,

        DrawEverything = DrawGround | DrawGroundBorders | DrawWalls | DrawItems | DrawCreatures | DrawEffects |
                         DrawMissiles | DrawCreaturesInformation | DrawStaticTexts | DrawAnimatedTexts |
                         DrawAnimations | DrawBars | DrawNames | DrawLights
    }

    public enum DatOpts
    {
        DatGround = 0,
        DatGroundClip,
        DatOnBottom,
        DatOnTop,
        DatContainer,
        DatStackable,
        DatForceUse,
        DatMultiUse,
        DatWritable,
        DatWritableOnce,
        DatFluidContainer,
        DatSplash,
        DatBlockWalk,
        DatNotMoveable,
        DatBlockProjectile,
        DatBlockPathFind,
        DatPickupable,
        DatHangable,
        DatHookSouth,
        DatHookEast,
        DatRotable,
        DatLight,
        DatDontHide,
        DatTranslucent,
        DatDisplacement,
        DatElevation,
        DatLyingCorpse,
        DatAnimateAlways,
        DatMinimapColor,
        DatLensHelp,
        DatFullGround,
        DatIgnoreLook,
        DatCloth,
        DatAnimation, // lastest tibia
        DatLastOpt = 255
    }

    public enum InventorySlot
    {
        InventorySlotHead = 1,
        InventorySlotNecklace,
        InventorySlotBackpack,
        InventorySlotArmor,
        InventorySlotRight,
        InventorySlotLeft,
        InventorySlotLegs,
        InventorySlotFeet,
        InventorySlotRing,
        InventorySlotAmmo,
        InventorySlotPurse,
        InventorySlotExt1,
        InventorySlotExt2,
        InventorySlotExt3,
        InventorySlotExt4,
        LastInventorySlot
    }

    public enum Statistic
    {
        Health = 0,
        MaxHealth,
        FreeCapacity,
        Experience,
        Level,
        LevelPercent,
        Mana,
        MaxMana,
        MagicLevel,
        MagicLevelPercent,
        Soul,
        Stamina,
        LastStatistic
    }

    public enum Skill
    {
        Fist = 0,
        Club,
        Sword,
        Axe,
        Distance,
        Shielding,
        Fishing,
        CriticalChance,
        CriticalDamage,
        LifeLeechChance,
        LifeLeechAmount,
        ManaLeechChance,
        ManaLeechAmount,
        LastSkill
    }

    public enum Direction
    {
        North = 0,
        East,
        South,
        West,
        NorthEast,
        SouthEast,
        SouthWest,
        NorthWest,
        InvalidDirection
    }

    public enum FluidsColor
    {
        FluidTransparent = 0,
        FluidBlue,
        FluidRed,
        FluidBrown,
        FluidGreen,
        FluidYellow,
        FluidWhite,
        FluidPurple
    }

    public enum FluidsType
    {
        FluidNone = 0,
        FluidWater,
        FluidMana,
        FluidBeer,
        FluidOil,
        FluidBlood,
        FluidSlime,
        FluidMud,
        FluidLemonade,
        FluidMilk,
        FluidWine,
        FluidHealth,
        FluidUrine,
        FluidRum,
        FluidFruidJuice,
        FluidCoconutMilk,
        FluidTea,
        FluidMead
    }

    public enum FightModes
    {
        FightOffensive = 1,
        FightBalanced = 2,
        FightDefensive = 3
    }

    public enum ChaseModes
    {
        DontChase = 0,
        ChaseOpponent = 1
    }

    public enum PVPModes
    {
        WhiteDove = 0,
        WhiteHand = 1,
        YellowHand = 2,
        RedFist = 3
    }

    public enum PlayerSkulls
    {
        SkullNone = 0,
        SkullYellow,
        SkullGreen,
        SkullWhite,
        SkullRed,
        SkullBlack,
        SkullOrange
    }

    public enum PlayerShields
    {
        ShieldNone = 0,
        ShieldWhiteYellow, // 1 party leader
        ShieldWhiteBlue, // 2 party member
        ShieldBlue, // 3 party member sexp off
        ShieldYellow, // 4 party leader sexp off
        ShieldBlueSharedExp, // 5 party member sexp on
        ShieldYellowSharedExp, // 6 // party leader sexp on
        ShieldBlueNoSharedExpBlink, // 7 party member sexp inactive guilty
        ShieldYellowNoSharedExpBlink, // 8 // party leader sexp inactive guilty
        ShieldBlueNoSharedExp, // 9 party member sexp inactive innocent
        ShieldYellowNoSharedExp, // 10 party leader sexp inactive innocent
        ShieldGray // 11 member of another party
    }

    public enum PlayerEmblems
    {
        EmblemNone = 0,
        EmblemGreen,
        EmblemRed,
        EmblemBlue,
        EmblemMember,
        EmblemOther
    }

    public enum CreatureIcons
    {
        NpcIconNone = 0,
        NpcIconChat,
        NpcIconTrade,
        NpcIconQuest,
        NpcIconTradeQuest
    }

    public enum PlayerStates
    {
        None = 0,
        Poison = 1,
        Burn = 2,
        Energy = 4,
        Drunk = 8,
        ManaShield = 16,
        Paralyze = 32,
        Haste = 64,
        Swords = 128,
        Drowning = 256,
        Freezing = 512,
        Dazzled = 1024,
        Cursed = 2048,
        PartyBuff = 4096,
        PzBlock = 8192,
        Pz = 16384,
        Bleeding = 32768,
        Hungry = 65536
    }

    public enum MessageMode
    {
        MessageNone = 0,
        MessageSay = 1,
        MessageWhisper = 2,
        MessageYell = 3,
        MessagePrivateFrom = 4,
        MessagePrivateTo = 5,
        MessageChannelManagement = 6,
        MessageChannel = 7,
        MessageChannelHighlight = 8,
        MessageSpell = 9,
        MessageNpcFrom = 10,
        MessageNpcTo = 11,
        MessageGamemasterBroadcast = 12,
        MessageGamemasterChannel = 13,
        MessageGamemasterPrivateFrom = 14,
        MessageGamemasterPrivateTo = 15,
        MessageLogin = 16,
        MessageWarning = 17,
        MessageGame = 18,
        MessageFailure = 19,
        MessageLook = 20,
        MessageDamageDealed = 21,
        MessageDamageReceived = 22,
        MessageHeal = 23,
        MessageExp = 24,
        MessageDamageOthers = 25,
        MessageHealOthers = 26,
        MessageExpOthers = 27,
        MessageStatus = 28,
        MessageLoot = 29,
        MessageTradeNpc = 30,
        MessageGuild = 31,
        MessagePartyManagement = 32,
        MessageParty = 33,
        MessageBarkLow = 34,
        MessageBarkLoud = 35,
        MessageReport = 36,
        MessageHotkeyUse = 37,
        MessageTutorialHint = 38,
        MessageThankyou = 39,
        MessageMarket = 40,
        MessageMana = 41,
        MessageBeyondLast = 42,

        // deprecated
        MessageMonsterYell = 43,
        MessageMonsterSay = 44,
        MessageRed = 45,
        MessageBlue = 46,
        MessageRVRChannel = 47,
        MessageRVRAnswer = 48,
        MessageRVRContinue = 49,
        MessageGameHighlight = 50,
        MessageNpcFromStartBlock = 51,
        LastMessage = 52,
        MessageInvalid = 255
    }

    public enum GameFeature
    {
        GameProtocolChecksum = 1,
        GameAccountNames = 2,
        GameChallengeOnLogin = 3,
        GamePenalityOnDeath = 4,
        GameNameOnNpcTrade = 5,
        GameDoubleFreeCapacity = 6,
        GameDoubleExperience = 7,
        GameTotalCapacity = 8,
        GameSkillsBase = 9,
        GamePlayerRegenerationTime = 10,
        GameChannelPlayerList = 11,
        GamePlayerMounts = 12,
        GameEnvironmentEffect = 13,
        GameCreatureEmblems = 14,
        GameItemAnimationPhase = 15,
        GameMagicEffectU16 = 16,
        GamePlayerMarket = 17,
        GameSpritesU32 = 18,

        // 19 unused
        GameOfflineTrainingTime = 20,
        GamePurseSlot = 21,
        GameFormatCreatureName = 22,
        GameSpellList = 23,
        GameClientPing = 24,
        GameExtendedClientPing = 25,
        GameDoubleHealth = 28,
        GameDoubleSkills = 29,
        GameChangeMapAwareRange = 30,
        GameMapMovePosition = 31,
        GameAttackSeq = 32,
        GameBlueNpcNameColor = 33,
        GameDiagonalAnimatedText = 34,
        GameLoginPending = 35,
        GameNewSpeedLaw = 36,
        GameForceFirstAutoWalkStep = 37,
        GameMinimapRemove = 38,
        GameDoubleShopSellAmount = 39,
        GameContainerPagination = 40,
        GameThingMarks = 41,
        GameLooktypeU16 = 42,
        GamePlayerStamina = 43,
        GamePlayerAddons = 44,
        GameMessageStatements = 45,
        GameMessageLevel = 46,
        GameNewFluids = 47,
        GamePlayerStateU16 = 48,
        GameNewOutfitProtocol = 49,
        GamePVPMode = 50,
        GameWritableDate = 51,
        GameAdditionalVipInfo = 52,
        GameBaseSkillU16 = 53,
        GameCreatureIcons = 54,
        GameHideNpcNames = 55,
        GameSpritesAlphaChannel = 56,
        GamePremiumExpiration = 57,
        GameBrowseField = 58,
        GameEnhancedAnimations = 59,
        GameOGLInformation = 60,
        GameMessageSizeCheck = 61,
        GamePreviewState = 62,
        GameLoginPacketEncryption = 63,
        GameClientVersion = 64,
        GameContentRevision = 65,
        GameExperienceBonus = 66,
        GameAuthenticator = 67,
        GameUnjustifiedPoints = 68,
        GameSessionKey = 69,
        GameDeathType = 70,
        GameIdleAnimations = 71,
        GameKeepUnawareTiles = 72,
        GameIngameStore = 73,
        GameIngameStoreHighlights = 74,
        GameIngameStoreServiceType = 75,
        GameAdditionalSkills = 76,

        LastGameFeature = 101
    }

    public enum PathFindResult
    {
        PathFindResultOk = 0,
        PathFindResultSamePosition,
        PathFindResultImpossible,
        PathFindResultTooFar,
        PathFindResultNoWay
    }

    public enum PathFindFlags
    {
        PathFindAllowNotSeenTiles = 1,
        PathFindAllowCreatures = 2,
        PathFindAllowNonPathable = 4,
        PathFindAllowNonWalkable = 8
    }

    public enum AutomapFlags
    {
        MapMarkTick = 0,
        MapMarkQuestion,
        MapMarkExclamation,
        MapMarkStar,
        MapMarkCross,
        MapMarkTemple,
        MapMarkKiss,
        MapMarkShovel,
        MapMarkSword,
        MapMarkFlag,
        MapMarkLock,
        MapMarkBag,
        MapMarkSkull,
        MapMarkDollar,
        MapMarkRedNorth,
        MapMarkRedSouth,
        MapMarkRedEast,
        MapMarkRedWest,
        MapMarkGreenNorth,
        MapMarkGreenSouth
    }

    public enum VipState
    {
        VipStateOffline = 0,
        VipStateOnline = 1,
        VipStatePending = 2
    }

    public enum SpeedFormula
    {
        SpeedFormulaA = 0,
        SpeedFormulaB,
        SpeedFormulaC,
        LastSpeedFormula
    }

    public enum Blessings
    {
        BlessingNone = 0,
        BlessingAdventurer = 1,
        BlessingSpiritualShielding = 1 << 1,
        BlessingEmbraceOfTibia = 1 << 2,
        BlessingFireOfSuns = 1 << 3,
        BlessingWisdomOfSolitude = 1 << 4,
        BlessingSparkOfPhoenix = 1 << 5
    }

    public enum DeathType
    {
        DeathRegular = 0,
        DeathBlessed = 1
    }

    public enum StoreProductTypes
    {
        ProductTypeOther = 0,
        ProductTypeNameChange = 1
    }

    public enum StoreErrorTypes
    {
        StoreNoError = -1,
        StorePurchaseError = 0,
        StoreNetworkError = 1,
        StoreHistoryError = 2,
        StoreTransferError = 3,
        StoreInformation = 4
    }

    public enum StoreStates
    {
        StateNone = 0,
        StateNew = 1,
        StateSale = 2,
        StateTimed = 3
    }

    public static class GlobalMembersConst
    {
        internal const float pi = 3.14159265f;
        internal const float MIN_ALPHA = 0.003f;
    }

    public enum Key : byte
    {
        KeyUnknown = 0,
        KeyEscape = 1,
        KeyTab = 2,
        KeyBackspace = 3,

        //KeyReturn = 4,
        KeyEnter = 5,
        KeyInsert = 6,
        KeyDelete = 7,
        KeyPause = 8,
        KeyPrintScreen = 9,
        KeyHome = 10,
        KeyEnd = 11,
        KeyPageUp = 12,
        KeyPageDown = 13,
        KeyUp = 14,
        KeyDown = 15,
        KeyLeft = 16,
        KeyRight = 17,
        KeyNumLock = 18,
        KeyScrollLock = 19,
        KeyCapsLock = 20,
        KeyCtrl = 21,
        KeyShift = 22,
        KeyAlt = 23,

        //KeyAltGr = 24,
        KeyMeta = 25,
        KeyMenu = 26,
        KeySpace = 32, // ' '
        KeyExclamation = 33, // !
        KeyQuote = 34, // "
        KeyNumberSign = 35, // #
        KeyDollar = 36, // $
        KeyPercent = 37, // %
        KeyAmpersand = 38, // &
        KeyApostrophe = 39, // '
        KeyLeftParen = 40, // (
        KeyRightParen = 41, // )
        KeyAsterisk = 42, // *
        KeyPlus = 43, // +
        KeyComma = 44, // ,
        KeyMinus = 45, // -
        KeyPeriod = 46, // .
        KeySlash = 47, // /
        Key0 = 48, // 0
        Key1 = 49, // 1
        Key2 = 50, // 2
        Key3 = 51, // 3
        Key4 = 52, // 4
        Key5 = 53, // 5
        Key6 = 54, // 6
        Key7 = 55, // 7
        Key8 = 56, // 8
        Key9 = 57, // 9
        KeyColon = 58, // :
        KeySemicolon = 59, // ;
        KeyLess = 60, // <
        KeyEqual = 61, // =
        KeyGreater = 62, // >
        KeyQuestion = 63, // ?
        KeyAtSign = 64, // @
        KeyA = 65, // a
        KeyB = 66, // b
        KeyC = 67, // c
        KeyD = 68, // d
        KeyE = 69, // e
        KeyF = 70, // f
        KeyG = 71, // g
        KeyH = 72, // h
        KeyI = 73, // i
        KeyJ = 74, // j
        KeyK = 75, // k
        KeyL = 76, // l
        KeyM = 77, // m
        KeyN = 78, // n
        KeyO = 79, // o
        KeyP = 80, // p
        KeyQ = 81, // q
        KeyR = 82, // r
        KeyS = 83, // s
        KeyT = 84, // t
        KeyU = 85, // u
        KeyV = 86, // v
        KeyW = 87, // w
        KeyX = 88, // x
        KeyY = 89, // y
        KeyZ = 90, // z
        KeyLeftBracket = 91, // [
        KeyBackslash = 92, // '\'
        KeyRightBracket = 93, // ]
        KeyCaret = 94, // ^
        KeyUnderscore = 95, // _
        KeyGrave = 96, // `
        KeyLeftCurly = 123, // {
        KeyBar = 124, // |
        KeyRightCurly = 125, // }
        KeyTilde = 126, // ~
        KeyF1 = 128,
        KeyF2 = 129,
        KeyF3 = 130,
        KeyF4 = 131,
        KeyF5 = 132,
        KeyF6 = 134,
        KeyF7 = 135,
        KeyF8 = 136,
        KeyF9 = 137,
        KeyF10 = 138,
        KeyF11 = 139,
        KeyF12 = 140,
        KeyNumpad0 = 141,
        KeyNumpad1 = 142,
        KeyNumpad2 = 143,
        KeyNumpad3 = 144,
        KeyNumpad4 = 145,
        KeyNumpad5 = 146,
        KeyNumpad6 = 147,
        KeyNumpad7 = 148,
        KeyNumpad8 = 149,
        KeyNumpad9 = 150
    }

    public enum LogLevel
    {
        LogDebug = 0,
        LogInfo,
        LogWarning,
        LogError,
        LogFatal
    }

    public enum AspectRatioMode
    {
        IgnoreAspectRatio,
        KeepAspectRatio,
        KeepAspectRatioByExpanding
    }

    public enum AlignmentFlag
    {
        AlignNone = 0,
        AlignLeft = 1,
        AlignRight = 2,
        AlignTop = 4,
        AlignBottom = 8,
        AlignHorizontalCenter = 16,
        AlignVerticalCenter = 32,
        AlignTopLeft = AlignTop | AlignLeft, // 5
        AlignTopRight = AlignTop | AlignRight, // 6
        AlignBottomLeft = AlignBottom | AlignLeft, // 9
        AlignBottomRight = AlignBottom | AlignRight, // 10
        AlignLeftCenter = AlignLeft | AlignVerticalCenter, // 33
        AlignRightCenter = AlignRight | AlignVerticalCenter, // 34
        AlignTopCenter = AlignTop | AlignHorizontalCenter, // 20
        AlignBottomCenter = AlignBottom | AlignHorizontalCenter, // 24
        AlignCenter = AlignVerticalCenter | AlignHorizontalCenter // 48
    }

    public enum AnchorEdge
    {
        AnchorNone = 0,
        AnchorTop,
        AnchorBottom,
        AnchorLeft,
        AnchorRight,
        AnchorVerticalCenter,
        AnchorHorizontalCenter
    }

    public enum FocusReason
    {
        MouseFocusReason = 0,
        KeyboardFocusReason,
        ActiveFocusReason,
        OtherFocusReason
    }

    public enum AutoFocusPolicy
    {
        AutoFocusNone = 0,
        AutoFocusFirst,
        AutoFocusLast
    }

    public enum InputEventType
    {
        NoInputEvent = 0,
        KeyTextInputEvent,
        KeyDownInputEvent,
        KeyPressInputEvent,
        KeyUpInputEvent,
        MousePressInputEvent,
        MouseReleaseInputEvent,
        MouseMoveInputEvent,
        MouseWheelInputEvent
    }

    public enum MouseButton
    {
        MouseNoButton = 0,
        MouseLeftButton,
        MouseRightButton,
        MouseMidButton
    }

    public enum MouseWheelDirection
    {
        MouseNoWheel = 0,
        MouseWheelUp,
        MouseWheelDown
    }

    public enum KeyboardModifier
    {
        KeyboardNoModifier = 0,
        KeyboardCtrlModifier = 1,
        KeyboardAltModifier = 2,
        KeyboardShiftModifier = 4
    }

    public enum WidgetState
    {
        InvalidState = -1,
        DefaultState = 0,
        ActiveState = 1,
        FocusState = 2,
        HoverState = 4,
        PressedState = 8,
        DisabledState = 16,
        CheckedState = 32,
        OnState = 64,
        FirstState = 128,
        MiddleState = 256,
        LastState = 512,
        AlternateState = 1024,
        DraggingState = 2048,
        HiddenState = 4096,
        LastWidgetState = 8192
    }

    public enum DrawPane
    {
        ForegroundPane = 1,
        BackgroundPane = 2,
        BothPanes = 3
    }
    
    public enum AnonymousEnum14
    {
        BlockSize = 32
    }

    public static class MessageModeTranslator
    {
        public static Dictionary<MessageMode, byte> messageModesMap = new Dictionary<MessageMode, byte>();

        public static void buildMessageModesMap(int version)
        {
            messageModesMap.Clear();


            if (version >= 1094)
            {
                messageModesMap[MessageMode.MessageMana] = 43;
            }


            if (version >= 1055)
            {
                // might be 1054

                messageModesMap[MessageMode.MessageNone] = 0;

                messageModesMap[MessageMode.MessageSay] = 1;

                messageModesMap[MessageMode.MessageWhisper] = 2;

                messageModesMap[MessageMode.MessageYell] = 3;

                messageModesMap[MessageMode.MessagePrivateFrom] = 4;

                messageModesMap[MessageMode.MessagePrivateTo] = 5;

                messageModesMap[MessageMode.MessageChannelManagement] = 6;

                messageModesMap[MessageMode.MessageChannel] = 7;

                messageModesMap[MessageMode.MessageChannelHighlight] = 8;

                messageModesMap[MessageMode.MessageSpell] = 9;

                messageModesMap[MessageMode.MessageNpcFromStartBlock] = 10;

                messageModesMap[MessageMode.MessageNpcFrom] = 11;

                messageModesMap[MessageMode.MessageNpcTo] = 12;

                messageModesMap[MessageMode.MessageGamemasterBroadcast] = 13;

                messageModesMap[MessageMode.MessageGamemasterChannel] = 14;

                messageModesMap[MessageMode.MessageGamemasterPrivateFrom] = 15;

                messageModesMap[MessageMode.MessageGamemasterPrivateTo] = 16;

                messageModesMap[MessageMode.MessageLogin] = 17;

                messageModesMap[MessageMode.MessageWarning] = 18; // Admin

                messageModesMap[MessageMode.MessageGame] = 19;

                messageModesMap[MessageMode.MessageGameHighlight] = 20;

                messageModesMap[MessageMode.MessageFailure] = 21;

                messageModesMap[MessageMode.MessageLook] = 22;

                messageModesMap[MessageMode.MessageDamageDealed] = 23;

                messageModesMap[MessageMode.MessageDamageReceived] = 24;

                messageModesMap[MessageMode.MessageHeal] = 25;

                messageModesMap[MessageMode.MessageExp] = 26;

                messageModesMap[MessageMode.MessageDamageOthers] = 27;

                messageModesMap[MessageMode.MessageHealOthers] = 28;

                messageModesMap[MessageMode.MessageExpOthers] = 29;

                messageModesMap[MessageMode.MessageStatus] = 30;

                messageModesMap[MessageMode.MessageLoot] = 31;

                messageModesMap[MessageMode.MessageTradeNpc] = 32;

                messageModesMap[MessageMode.MessageGuild] = 33;

                messageModesMap[MessageMode.MessagePartyManagement] = 34;

                messageModesMap[MessageMode.MessageParty] = 35;

                messageModesMap[MessageMode.MessageBarkLow] = 36;

                messageModesMap[MessageMode.MessageBarkLoud] = 37;

                messageModesMap[MessageMode.MessageReport] = 38;

                messageModesMap[MessageMode.MessageHotkeyUse] = 39;

                messageModesMap[MessageMode.MessageTutorialHint] = 40;

                messageModesMap[MessageMode.MessageThankyou] = 41;

                messageModesMap[MessageMode.MessageMarket] = 42;
            }
            else if (version >= 1036)
            {
                for (int i = (int) MessageMode.MessageNone; i <= (int) MessageMode.MessageBeyondLast; ++i)
                {
                    if (i >= (int) MessageMode.MessageNpcTo)
                        messageModesMap[(MessageMode) i] = (byte) (i + 1);
                    else

                        messageModesMap[(MessageMode) i] = (byte) i;
                }
            }
            else if (version >= 900)
            {
                for (int i = (byte) MessageMode.MessageNone; i <= (byte) MessageMode.MessageBeyondLast; ++i)

                    messageModesMap[(MessageMode) i] = (byte) i;
            }
            else if (version >= 861)
            {
                messageModesMap[MessageMode.MessageNone] = 0;

                messageModesMap[MessageMode.MessageSay] = 1;

                messageModesMap[MessageMode.MessageWhisper] = 2;

                messageModesMap[MessageMode.MessageYell] = 3;

                messageModesMap[MessageMode.MessageNpcTo] = 4;

                messageModesMap[MessageMode.MessageNpcFrom] = 5;

                messageModesMap[MessageMode.MessagePrivateFrom] = 6;

                messageModesMap[MessageMode.MessagePrivateTo] = 6;

                messageModesMap[MessageMode.MessageChannel] = 7;

                messageModesMap[MessageMode.MessageChannelManagement] = 8;

                messageModesMap[MessageMode.MessageGamemasterBroadcast] = 9;

                messageModesMap[MessageMode.MessageGamemasterChannel] = 10;

                messageModesMap[MessageMode.MessageGamemasterPrivateFrom] = 11;

                messageModesMap[MessageMode.MessageGamemasterPrivateTo] = 11;

                messageModesMap[MessageMode.MessageChannelHighlight] = 12;

                messageModesMap[MessageMode.MessageMonsterSay] = 13;

                messageModesMap[MessageMode.MessageMonsterYell] = 14;

                messageModesMap[MessageMode.MessageWarning] = 15;

                messageModesMap[MessageMode.MessageGame] = 16;

                messageModesMap[MessageMode.MessageLogin] = 17;

                messageModesMap[MessageMode.MessageStatus] = 18;

                messageModesMap[MessageMode.MessageLook] = 19;

                messageModesMap[MessageMode.MessageFailure] = 20;

                messageModesMap[MessageMode.MessageBlue] = 21;

                messageModesMap[MessageMode.MessageRed] = 22;
            }
            else if (version >= 840)
            {
                messageModesMap[MessageMode.MessageNone] = 0;

                messageModesMap[MessageMode.MessageSay] = 1;

                messageModesMap[MessageMode.MessageWhisper] = 2;

                messageModesMap[MessageMode.MessageYell] = 3;

                messageModesMap[MessageMode.MessageNpcTo] = 4;

                messageModesMap[MessageMode.MessageNpcFromStartBlock] = 5;

                messageModesMap[MessageMode.MessagePrivateFrom] = 6;

                messageModesMap[MessageMode.MessagePrivateTo] = 6;

                messageModesMap[MessageMode.MessageChannel] = 7;

                messageModesMap[MessageMode.MessageChannelManagement] = 8;

                messageModesMap[MessageMode.MessageRVRChannel] = 9;

                messageModesMap[MessageMode.MessageRVRAnswer] = 10;

                messageModesMap[MessageMode.MessageRVRContinue] = 11;

                messageModesMap[MessageMode.MessageGamemasterBroadcast] = 12;

                messageModesMap[MessageMode.MessageGamemasterChannel] = 13;

                messageModesMap[MessageMode.MessageGamemasterPrivateFrom] = 14;

                messageModesMap[MessageMode.MessageGamemasterPrivateTo] = 14;

                messageModesMap[MessageMode.MessageChannelHighlight] = 15;

                // 16, 17 ??

                messageModesMap[MessageMode.MessageRed] = 18;

                messageModesMap[MessageMode.MessageMonsterSay] = 19;

                messageModesMap[MessageMode.MessageMonsterYell] = 20;

                messageModesMap[MessageMode.MessageWarning] = 21;

                messageModesMap[MessageMode.MessageGame] = 22;

                messageModesMap[MessageMode.MessageLogin] = 23;

                messageModesMap[MessageMode.MessageStatus] = 24;

                messageModesMap[MessageMode.MessageLook] = 25;

                messageModesMap[MessageMode.MessageFailure] = 26;

                messageModesMap[MessageMode.MessageBlue] = 27;
            }
            else if (version >= 760)
            {
                messageModesMap[MessageMode.MessageNone] = 0;

                messageModesMap[MessageMode.MessageSay] = 1;

                messageModesMap[MessageMode.MessageWhisper] = 2;

                messageModesMap[MessageMode.MessageYell] = 3;

                messageModesMap[MessageMode.MessagePrivateFrom] = 4;

                messageModesMap[MessageMode.MessagePrivateTo] = 4;

                messageModesMap[MessageMode.MessageChannel] = 5;

                messageModesMap[MessageMode.MessageRVRChannel] = 6;

                messageModesMap[MessageMode.MessageRVRAnswer] = 7;

                messageModesMap[MessageMode.MessageRVRContinue] = 8;

                messageModesMap[MessageMode.MessageGamemasterBroadcast] = 9;

                messageModesMap[MessageMode.MessageGamemasterChannel] = 10;

                messageModesMap[MessageMode.MessageGamemasterPrivateFrom] = 11;

                messageModesMap[MessageMode.MessageGamemasterPrivateTo] = 11;

                messageModesMap[MessageMode.MessageChannelHighlight] = 12;

                // 13, 14, 15 ??

                messageModesMap[MessageMode.MessageMonsterSay] = 16;

                messageModesMap[MessageMode.MessageMonsterYell] = 17;

                messageModesMap[MessageMode.MessageWarning] = 18;

                messageModesMap[MessageMode.MessageGame] = 19;

                messageModesMap[MessageMode.MessageLogin] = 20;

                messageModesMap[MessageMode.MessageStatus] = 21;

                messageModesMap[MessageMode.MessageLook] = 22;

                messageModesMap[MessageMode.MessageFailure] = 23;

                messageModesMap[MessageMode.MessageBlue] = 24;

                messageModesMap[MessageMode.MessageRed] = 25;
            }
        }


        public static MessageMode translateMessageModeFromServer(byte mode)
        {
            var it = messageModesMap.Where((pair => pair.Value == mode));
            var keyValuePairs = it as KeyValuePair<MessageMode, byte>[] ?? it.ToArray();

            return keyValuePairs.Any() ? keyValuePairs.First().Key : MessageMode.MessageInvalid;
        }

        public static byte translateMessageModeToServer(MessageMode mode)
        {

            if (mode < 0 || mode >= MessageMode.LastMessage)

                return (byte)MessageMode.MessageInvalid;

            var it = messageModesMap.Where(pair => pair.Key == mode);

            var keyValuePairs = it as IList<KeyValuePair<MessageMode, byte>> ?? it.ToList();
            return keyValuePairs.Any() ? (byte)keyValuePairs.First().Value : (byte)MessageMode.MessageInvalid;
        }
    }
}