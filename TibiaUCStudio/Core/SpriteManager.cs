using Game.DAO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using TibiaUCStudio.Forms;



using Imager;
using Imager.Interface;
using word = System.UInt16;
using Classes;
using Classes.ScriptActions;
using System.Windows.Forms;
using TibiaUCStudio.Properties;
using System.Diagnostics.Contracts;
using Classes.ImageManipulators;
using System.IO.Compression;
using TeximpNet;
using TeximpNet.Compression;
using TeximpNet.DDS;
using ICSharpCode.SharpZipLib.GZip;

namespace TibiaUCStudio.Core
{
    public class SpriteManager
    {
        public SpriteManager()
        {
            InitResizer();
        }
        private readonly ScriptEngine _scriptEngine = new ScriptEngine();
        private Image _source;
        #region props
        /// <summary>
        /// Gets or sets the source image.
        /// </summary>
        /// <value>
        /// The source image.
        /// </value>
        private Image _SourceImage
        {
            get => _source;
            set
            {
                this._TargetImage = null;
                _source = value;
                this._CorrectAspectRatioIfNeeded(false);
            }
        }

        /// <summary>
        /// Gets or sets the target image.
        /// </summary>
        /// <value>
        /// The target image.
        /// </value>
        private Image _TargetImage;

        #endregion

        #region ctor
        public void InitResizer()
        {

            this.cmbResizeMethod = SupportedManipulators.MANIPULATORS.Where(e => e.Key == string.Format("XBR {0}x", antialiasingLevel)).Select(e => e.Value).FirstOrDefault();

            this._SourceImage = null;

            this.chkUseThresholds = sPixel.AllowThresholds;

        }

        #endregion

        bool chkKeepAspect = true;
        double nudWidth = 128;
        double nudHeight = 128;
        bool chkUseThresholds = false;
        IImageManipulator cmbResizeMethod;
        bool chkUseCenteredGrid = false;
        int nudRepetitionCount = 1;
        float nudRadius = 1;
        OutOfBoundsMode cmbHorizontalBPH = OutOfBoundsMode.ConstantExtension;
        OutOfBoundsMode cmbVerticalBPH = OutOfBoundsMode.ConstantExtension;
        /// <summary>
        /// Resizes the given image with the currently set parameters from the GUI.
        /// </summary>
        private void _ScaleImageWithCurrentParameters(bool applyToTarget)
        {
            var method = (IImageManipulator)this.cmbResizeMethod;
            var targetWidth = (word)this.nudWidth;
            var targetHeight = (word)this.nudHeight;
            var maintainAspect = this.chkKeepAspect;
            var useThresholds = this.chkUseThresholds;
            var useCenteredGrid = this.chkUseCenteredGrid;
            var repetitionCount = (byte)this.nudRepetitionCount;
            var horizontalBph = (OutOfBoundsMode)this.cmbHorizontalBPH;
            var verticalBph = (OutOfBoundsMode)this.cmbVerticalBPH;
            var radius = (float)this.nudRadius;

            if ((targetWidth <= 0 && method.SupportsWidth) || (targetHeight <= 0 && method.SupportsHeight))
            {
                return;
            }

            var command = new ResizeCommand(applyToTarget, method, targetWidth, targetHeight, 0, maintainAspect, horizontalBph, verticalBph, repetitionCount, useThresholds, useCenteredGrid, radius);

            this._ExecuteScriptActions(command);
        }

        /// <summary>
        /// Executes the given script actions.
        /// </summary>
        /// <param name="commands">The commands.</param>
        private void _ExecuteScriptActions(params IScriptAction[] commands)
        {
            Contract.Requires(commands != null);

            // filter image

            _scriptEngine.SourceImage = cImage.FromBitmap((Bitmap)_SourceImage);
            foreach (var command in commands)
                this._scriptEngine.ExecuteAction(command);

            var gdiSource = this._scriptEngine.GdiSource;
            var gdiTarget = this._scriptEngine.GdiTarget;

            this._SourceImage = gdiSource;
            this._TargetImage = gdiTarget;

        }

        /// <summary>
        /// Corrects target width/height if forced to keep aspect ratio.
        /// </summary>
        /// <param name="useHeight">if set to <c>true</c> we calculate target width from height; otherwise, we calculate target height from width.</param>
        private void _CorrectAspectRatioIfNeeded(bool useHeight)
        {
            if (!this.chkKeepAspect)
                return;

            var image = this._SourceImage;
            if (image == null)
                return;

            var width = this.nudWidth;
            var height = this.nudHeight;
            if (useHeight)
            {
                width = Math.Round(height * image.Width / image.Height);
            }
            else
            {
                height = Math.Round(width * image.Height / image.Width);
            }

            if (width != this.nudWidth)
                this.nudWidth = width;

            if (height != this.nudHeight)
                this.nudHeight = height;
        }

        /// <summary>
        /// Determines whether or not the given file extension is usable for the program.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <returns><c>true</c> if we accept this file extensions; otherwise, <c>false</c>.</returns>
        private static bool _IsSupportedFileExtension(string extension)
        {
            if (string.IsNullOrWhiteSpace(extension))
                return (false);
            extension = extension.Trim().ToUpper();
            if (extension == ".JPEG" || extension == ".JPG")
                return (true);
            if (extension == ".BMP")
                return (true);
            if (extension == ".PNG")
                return (true);
            if (extension == ".GIF")
                return (true);
            if (extension == ".TIF" || extension == ".TIFF")
                return (true);
            return (false);
        }

        /// <summary>
        /// Gets all supported file names from a Drag'N'Drop operation.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.DragEventArgs"/> instance containing the event data.</param>
        /// <returns>The list of files which could be accepted.</returns>
        private static string[] _GetSupportedFiles(DragEventArgs e)
        {
            var files = e == null ? null : ((Array)e.Data.GetData(DataFormats.FileDrop)).OfType<string>().ToArray();
            if (files == null || files.Length < 1)
                return (null);
            return (files.Where(f => _IsSupportedFileExtension(Path.GetExtension(f)) || string.Equals(ScriptSerializer.DEFAULT_FILE_EXTENSION, Path.GetExtension(f))).ToArray());
        }

        /// <summary>
        /// Applies the given script file to the source image.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        private void _ApplyScriptFile(string fileName)
        {
            var localEngine = new ScriptEngine();
            localEngine.AddWithoutExecution(new NullTransformCommand());
            ScriptSerializer.LoadFromFile(localEngine, fileName);
            this._ExecuteScriptActions(localEngine.Actions.ToArray());
        }

        public bool IsLoaded = false;

        public BinaryReader _sprReader;

        public const int SpriteSize = 32;
        public const int SpriteDataSize = SpriteSize * SpriteSize * 4;

        private long _spritesOffset;

        public int SpritesCount;

        private int antialiasingLevel;
        public int AntialiasingLevel
        {
            set {
                if (value == 1 || value == 2 || value == 4)
                {
                    antialiasingLevel = value;
                    InitResizer();
                }
            }
            get => antialiasingLevel;
        }

        public void OpenSpriteFile(FileStream fs)
        {
            IsLoaded = true;

            _sprReader = new BinaryReader(fs);

            var signature = _sprReader.ReadUInt32();

            SpritesCount = Game.Core.GameConfig.GameSpritesU32 ? (int)_sprReader.ReadUInt32() : (int)_sprReader.ReadUInt16();

            _spritesOffset = _sprReader.BaseStream.Position;
        }

        public Image GetSpriteImage(int id)
        {
            if (!IsLoaded) return null;

            if (id == 0)
                return null;

            _sprReader.BaseStream.Seek(((id - 1) * 4) + _spritesOffset, SeekOrigin.Begin);

            UInt32 spriteAddress = _sprReader.ReadUInt32();


            // no sprite? return an empty texture

            if (spriteAddress == 0)
            {
                Bitmap i = new Bitmap(SpriteSize, SpriteSize);
                return i;
            }


            _sprReader.BaseStream.Seek(spriteAddress, SeekOrigin.Begin);


            // skip color key

            _sprReader.ReadByte();

            _sprReader.ReadByte();

            _sprReader.ReadByte();


            UInt16 pixelDataSize = _sprReader.ReadUInt16();


            byte[] pixels = new byte[SpriteDataSize];

            int writePos = 0;

            int read = 0;

            bool useAlpha = false;

            byte channels = useAlpha ? (byte)4 : (byte)3;


            // decompress pixels

            while (read < pixelDataSize && writePos < SpriteDataSize)
            {
                UInt16 transparentPixels = _sprReader.ReadUInt16();

                UInt16 coloredPixels = _sprReader.ReadUInt16();


                for (int i = 0; i < transparentPixels && writePos < SpriteDataSize; i++)
                {
                    pixels[writePos + 0] = 0x00;

                    pixels[writePos + 1] = 0x00;

                    pixels[writePos + 2] = 0x00;

                    pixels[writePos + 3] = 0x00;

                    writePos += 4;
                }


                for (int i = 0; i < coloredPixels && writePos < SpriteDataSize; i++)
                {
                    pixels[writePos + 2] = _sprReader.ReadByte();

                    pixels[writePos + 1] = _sprReader.ReadByte();

                    pixels[writePos + 0] = _sprReader.ReadByte();

                    pixels[writePos + 3] = useAlpha ? _sprReader.ReadByte() : (byte)0xFF;

                    writePos += 4;
                }


                read += 4 + (channels * coloredPixels);
            }


            // fill remaining pixels with alpha

            while (writePos < SpriteDataSize)
            {
                pixels[writePos + 0] = 0x00;

                pixels[writePos + 1] = 0x00;

                pixels[writePos + 2] = 0x00;

                pixels[writePos + 3] = 0x00;

                writePos += 4;
            }


            Bitmap output = new Bitmap(SpriteSize, SpriteSize, PixelFormat.Format32bppArgb);
            Rectangle rect = new Rectangle(0, 0, output.Width, output.Height);
            BitmapData bmpData = output.LockBits(rect, ImageLockMode.ReadWrite, output.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            System.Runtime.InteropServices.Marshal.Copy(pixels, 0, ptr, pixels.Length);
            output.UnlockBits(bmpData);


            return output;
        }


        public void ExportAtlasSpriteFile(string filename)
        {
            BinaryWriter bw = new BinaryWriter(File.OpenWrite(filename + ".aspr0"));

            int atlasId = 0;
            Dictionary<int, Tuple<byte[], int>> atlasesList = new Dictionary<int, Tuple<byte[], int>>();
            Dictionary<int, Dictionary<int, TextureLocation>> locations = new Dictionary<int, Dictionary<int, TextureLocation>>();

            var atlasListCount = 150;

            bw.Write(antialiasingLevel);
            bw.Write(atlasListCount);

            for (int v = 0; v < 4; v++)
            {

                var category = (ThingCategory)v;

                var types = MainForm.TTM.GetThingTypes(category);

                List<Bitmap> textures = new List<Bitmap>();



                int maxTextureWH = 8192;

                int textureWidth = 0;
                int textureHeight = 0;

                int maxSpriteHeight = 0;

                var atlasTex = new Bitmap((int)(maxTextureWH), (int)(maxTextureWH), PixelFormat.Format32bppArgb);

                Graphics gfx = Graphics.FromImage(atlasTex);
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(0, 255, 255, 255)))
                {
                    gfx.FillRectangle(brush, 0, 0, atlasTex.Size.Width, atlasTex.Size.Height);
                }

                locations.Add(v, new Dictionary<int, TextureLocation>());



                for (var i = 0; i < types.Count; i++)
                {
                    var thingType = MainForm.TTM.GetThingType((ushort)(i + 1), category);
                    var tex = CreateThingTypeSprite(thingType);

                    if (tex == null)
                    {
                        continue;
                    }

                    var texSizeWidth = tex.Size.Width;
                    var texSizeHeight = tex.Size.Height;

                    var x = 0;
                    var y = 0;

                   

                    if (textureWidth + texSizeWidth > maxTextureWH)
                    {
                        textureWidth = 0;
                        textureHeight += maxSpriteHeight;
                        maxSpriteHeight = 0;

                        x = textureWidth;
                        y = textureHeight;
                        textureWidth += texSizeWidth;
                    }
                    else
                    {
                        x = textureWidth;
                        y = textureHeight;
                        textureWidth += texSizeWidth;
                    }

                    if (texSizeHeight > maxSpriteHeight)
                    {
                        maxSpriteHeight = texSizeHeight;
                    }

                    if (y - maxSpriteHeight >= maxTextureWH)
                    {
                        //next atlas
                        textureWidth = texSizeWidth;
                        textureHeight = 0;

                        maxSpriteHeight = 0;

                        x = 0;
                        y = 0;

                        var texturePath = atlasId + ".png";
                        // TODO: write to binary
                        var byteImage = BitmapToByteArray((Bitmap)atlasTex);
                        File.WriteAllBytes(texturePath, byteImage);

                        var tuple = new Tuple<byte[], int>(byteImage, v);

                        bw.Write(tuple.Item2);
                        bw.Write(tuple.Item1.Length);
                        bw.Write(tuple.Item1);
                        bw.Flush();

                        atlasTex = new Bitmap((int)(maxTextureWH), (int)(maxTextureWH), PixelFormat.Format32bppArgb);

                        // ------- Reset all pixels color to transparent
                        gfx = Graphics.FromImage(atlasTex);
                        using (SolidBrush brush = new SolidBrush(Color.FromArgb(0, 255, 255, 255)))
                        {
                            gfx.FillRectangle(brush, 0, 0, atlasTex.Size.Width, atlasTex.Size.Height);
                        }



                        atlasId++;
                        System.GC.Collect();
                    }

                    if (texSizeWidth > atlasTex.Size.Width)
                    {
                        atlasTex = Resize(atlasTex, texSizeWidth, atlasTex.Size.Height);
                    }

                    var iy = maxTextureWH - y - texSizeHeight;
                    gfx.DrawImage(tex, x, (y));


                    locations[v].Add(i, new TextureLocation()
                    {
                        atlasId = atlasId,
                        id = i + 1,
                        x = x,
                        y = y,
                        width = texSizeWidth,
                        height = texSizeHeight
                    });

                    if (i == types.Count - 2)
                    {
                        //next atlas
                        textureWidth = texSizeWidth;
                        textureHeight = 0;

                        maxSpriteHeight = 0;

                        x = 0;
                        y = 0;

                        var texturePath = atlasId + ".png";
                        // TODO: write to binary
                        var byteImage = BitmapToByteArray((Bitmap)atlasTex);
                        File.WriteAllBytes(texturePath, byteImage);
                        var tuple = new Tuple<byte[], int>(byteImage, v);
                        bw.Write(tuple.Item2);
                        bw.Write(tuple.Item1.Length);
                        bw.Write(tuple.Item1);
                        bw.Flush();

                        atlasTex = new Bitmap((int)(maxTextureWH), (int)(maxTextureWH), PixelFormat.Format32bppArgb);

                        // ------- Reset all pixels color to transparent
                        gfx = Graphics.FromImage(atlasTex);
                        using (SolidBrush brush = new SolidBrush(Color.FromArgb(0, 255, 255, 255)))
                        {
                            gfx.FillRectangle(brush, 0, 0, atlasTex.Size.Width, atlasTex.Size.Height);
                        }


                        atlasId++;
                        System.GC.Collect();
                    }

                }


            }

            if (atlasId < atlasListCount)
                for (int i = atlasId; i < atlasListCount; i++)
                {
                    bw.Write(99);
                    bw.Write(1);
                    bw.Write(new byte[1] { 88 });
                }

            bw.Write((locations.ContainsKey(0) ? locations[0].Count : 0) + (locations.ContainsKey(1) ? locations[1].Count : 0) + (locations.ContainsKey(2) ? locations[2].Count : 0) + (locations.ContainsKey(3) ? locations[3].Count : 0));
            foreach (var locKV in locations)
            {
                foreach (var loc1KV in locKV.Value)
                {
                    var loc = loc1KV.Value;
                    bw.Write(locKV.Key);
                    bw.Write(loc.id);
                    bw.Write(loc.atlasId);
                    bw.Write(loc.x);
                    bw.Write(loc.y);
                    bw.Write(loc.width);
                    bw.Write(loc.height);
                }
            }
            bw.Flush();
            bw.Close();
            GC.Collect();
            GZip.Compress(File.OpenRead(filename+".aspr0"), File.OpenWrite(filename+".aspr"), true, 512, 9);


            
        }
        // Clamps value between 0 and 1 and returns value
        public static float Clamp01(float value)
        {
            if (value < 0F)
                return 0F;
            else if (value > 1F)
                return 1F;
            else
                return value;
        }

        // Interpolates between /a/ and /b/ by /t/. /t/ is clamped between 0 and 1.
        public static float Lerp(float a, float b, float t)
        {
            return a + (b - a) * Clamp01(t);
        }


        // Calculates the ::ref::Lerp parameter between of two values.
        public static float InverseLerp(float a, float b, float value)
        {
            if (a != b)
                return Clamp01((value - a) / (b - a));
            else
                return 0.0f;
        }

        private byte[] BitmapToByteArray(Bitmap atlasTex)
        {
            using (var stream = new MemoryStream())
            {
                var bitmapData = atlasTex.LockBits(
                new Rectangle(0, 0, atlasTex.Width, atlasTex.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb
                );
                

                Surface surfaceFromFile = Surface.LoadFromRawData(bitmapData.Scan0, atlasTex.Width, atlasTex.Height, bitmapData.Stride, true, true);
                
                Compressor compressor = new Compressor();
                compressor.Compression.Format = CompressionFormat.DXT5;
                compressor.Compression.Quality = CompressionQuality.Fastest;
                compressor.Input.GenerateMipmaps = false;
                compressor.Input.SetData(surfaceFromFile);
                MemoryStream m = new MemoryStream();
                compressor.Process(m);
                
                atlasTex.UnlockBits(bitmapData);

                m.Position = 0;

                Surface surface = Surface.LoadFromStream(m);

                surface.FlipVertically();

                MemoryStream m2 = new MemoryStream();
                surface.SaveToStream(TeximpNet.ImageFormat.PNG, m2);

                return m2.ToArray();
            }
        }
        
        private Bitmap Resize(Bitmap b, int newWidth, int newHeight)
        {
            var newTex = new Bitmap((int)(newWidth), (int)(newHeight), PixelFormat.Format32bppArgb);

            Graphics gfx = Graphics.FromImage(newTex);
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(0, 255, 255, 255)))
            {
                gfx.DrawImage(b, 0, 0);
            }

            return newTex;
        }

        public Bitmap CreateThingTypeSprite(ThingType thing)
        {

            if (thing.GetId() == 0 || thing.GetWidth() == 0)
            {
                return null;
            }

            // Sprite Path: Animation Phase -> Direction (by patternX) -> Addon (by patternY) -> Mount (by patternZ) -> Mount (by layer) ->
            // ------- create layer texture
            var layerTexture = new Bitmap((int)(SpriteSize * thing.GetWidth()  * thing.GetNumPatternX()
                                             + SpriteSize * thing.GetWidth()  * thing.GetNumPatternX() * (thing.GetAnimationPhases()-1)),
                                         (int)(SpriteSize * thing.GetHeight() * thing.GetNumPatternY())
                                             + SpriteSize * thing.GetHeight() * thing.GetNumPatternY() * (thing.GetNumPatternZ()-1)
                                             + SpriteSize * thing.GetHeight()  * thing.GetNumPatternY() * thing.GetNumPatternZ() * (thing.GetLayers()-1)
                                         , PixelFormat.Format32bppArgb);


            Graphics gfx = Graphics.FromImage(layerTexture);
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(0, 255, 255, 255)))
            {
                gfx.FillRectangle(brush, 0, 0, layerTexture.Size.Width, layerTexture.Size.Height);
            }
            
            // every animator group
            for (int group = 0; group < thing._mAnimator.Count;group++)
            {
                // ------- iterate animation phases
                for (int animationPhase = 0; animationPhase < thing._mAnimator[group]._mAnimationPhases; ++animationPhase)
                {

                    // iterate Z direction
                    for (int z = 0; z < thing.GetNumPatternZ(); ++z)
                    {
                        // iterate Y direction
                        for (int y = 0; y < thing.GetNumPatternY(); ++y)
                        {
                            // iterate X direction
                            for (int x = 0; x < thing.GetNumPatternX(); ++x)
                            {

                                // iterate layers
                                for (int l = 0; l < thing.GetLayers(); ++l)
                                {

                                    var posX = thing.GetDisplacementX() * 0.031f
                                                      + x * thing.GetWidth() * SpriteSize

                                                      // animation phases
                                                      + animationPhase * thing.GetNumPatternX() * thing.GetWidth() * SpriteSize

                                                      + group * thing._mAnimator[(int)Math.Max(0, group - 1)]._mAnimationPhases * thing.GetNumPatternX() * thing.GetWidth() * SpriteSize;

                                    var posY = thing.GetDisplacementY() * 0.031f
                                                      + y * thing.GetHeight() * SpriteSize

                                                      + z * thing.GetNumPatternY() * thing.GetHeight() * SpriteSize
                                                      // encoded blend layers
                                                      + l * thing.GetNumPatternY() * thing.GetNumPatternZ() * thing.GetHeight() * SpriteSize;



                                    // iterate height & width
                                    for (int h = 0; h < thing.GetHeight(); ++h)
                                    {
                                        for (int w = 0; w < thing.GetWidth(); ++w)
                                        {
                                            // sprite index
                                            int spriteIndex =
                                                thing.GetSpriteIndex(w, h, l, x, y, z, animationPhase);

                                            // get sprite id
                                            if (spriteIndex >= thing.GetSprites().Count)
                                            {
                                                continue;
                                            }
                                            var id = thing.GetSprites()[spriteIndex];

                                            // shift
                                            var pX = (((thing.GetWidth() - 1) * SpriteSize - w * (int)SpriteSize));
                                            var pY = (((thing.GetHeight() - 1) * SpriteSize)) - ((h) * (int)SpriteSize);

                                            // get texture
                                            var tex = GetSpriteImage(id);

                                            if (id == 0)
                                            {
                                                continue;
                                            }

                                            if (tex != null)
                                            {

                                                gfx.DrawImage(tex, (int)posX + (int)pX, (int)posY + (int)pY);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            var layerTexturePadding = new Bitmap((int)(layerTexture.Width), (int)(layerTexture.Height ), PixelFormat.Format32bppArgb);

            gfx = Graphics.FromImage(layerTexturePadding);
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(0, 255, 255, 255)))
            {
                gfx.FillRectangle(brush, 0, 0, layerTexturePadding.Size.Width, layerTexturePadding.Size.Height);
            }
            gfx.DrawImage(layerTexture, 0, 0);

            if (antialiasingLevel > 1)
            {
                _SourceImage = (Bitmap)layerTexturePadding;
                _ScaleImageWithCurrentParameters(false);

                return (Bitmap)_TargetImage;
            }

            return layerTexturePadding;

        }


    }

    [Serializable]
    public class TextureLocation
    {
        [XmlAttribute]
        public int id;

        [XmlAttribute]
        public float x;

        [XmlAttribute]
        public float y;

        [XmlAttribute]
        public float width;
        [XmlAttribute]
        public float height;

        [XmlAttribute]
        public int atlasId;
    }
}

