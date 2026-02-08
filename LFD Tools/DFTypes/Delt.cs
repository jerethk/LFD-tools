using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFD_Tools.DFTypes;

public class Delt
{
    public Delt()
    {
    }

    public string? Name { get; set; }
    public Int16 OffsetX { get; set; }
    public Int16 OffsetY { get; set; }
    public Int16 SizeX { get; set; }    // equals actual SizeX - 1;
    public Int16 SizeY { get; set; }    // equals actual SizeY - 1;

    public int[,]? Pixels { get; set; }

    public void LoadFromFile(string filename)
    {
        this.Name = Path.GetFileNameWithoutExtension(filename);
        
        using (var fileStream = File.Open(filename, FileMode.Open, FileAccess.Read))
        {
            this.LoadFromStream(fileStream);
        }
    }

    public void LoadFromStream(Stream data)
    {
        using var reader = new BinaryReader(data);
        this.OffsetX = (Int16)reader.ReadInt16();
        this.OffsetY = (Int16)reader.ReadInt16();
        this.SizeX = (Int16)(reader.ReadInt16() + 1);    // for some reason SizeX and SizeY are 1 less than actual...
        this.SizeY = (Int16)(reader.ReadInt16() + 1);

        // Hack for bad data eg. CURSORS.ANIM
        var sizeX = this.SizeX < 0 ? 0 : this.SizeX;
        var sizeY = this.SizeY < 0 ? 0 : this.SizeY;

        // Set all pixels to transparent initially
        this.Pixels = new int[sizeX, sizeY];
        for (var x = 0; x < sizeX; x++)
        {
            for (var y = 0; y < sizeY; y++)
            {
                this.Pixels[x, y] = -1;
            }
        }

        // Each DELT line is a horizontal line starting at startX, startY
        // Bit 0 of sizeAndType gives compression (1 = compressed)
        // Bits 1-15 of sizeAndType gives number of pixels in the line
        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            UInt16 sizeAndType = (UInt16)reader.ReadInt16();
            if (sizeAndType == 0)
            {
                break;
            }

            var compressed = sizeAndType & 0b_0000_0000_0000_0001;
            var lineSize = sizeAndType >> 1;
            UInt16 startX = (UInt16)reader.ReadInt16();
            UInt16 startY = (UInt16)reader.ReadInt16();

            List<int> linePixels;
            if (compressed == 0)
            {
                linePixels = GetUncompressedLine(reader, lineSize).ToList();
            }
            else
            {
                linePixels = GetCompressedLine(reader, lineSize);
            }

            for (var x = 0; x < lineSize; x++)
            {
                this.Pixels[startX + x, startY] = linePixels[x];
            }
        }
    }

    public Bitmap? CreateBitmap(Pltt pltt, bool subtractOffsets, bool keepTransparent = true)
    {
        if (this.Pixels == null || this.SizeX <= 0 || this.SizeY <= 0)
        {
            return null;
        }

        var offsetX = subtractOffsets ? this.OffsetX : 0;
        var offsetY = subtractOffsets ? this.OffsetY : 0;
        
        var bitmap = new Bitmap(this.SizeX - offsetX, this.SizeY - offsetY);
        var alpha = keepTransparent ? 0 : 255;

        for (var x = 0; x < this.SizeX - offsetX; x++)
        {
            for (var y = 0; y < this.SizeY - offsetY; y++)
            {
                var index = this.Pixels[x + offsetX, y + offsetY];
                var colour = index == -1
                    ? Color.FromArgb(alpha, 0, 0, 0)
                    : Color.FromArgb(255, pltt.Colours[index].R, pltt.Colours[index].G, pltt.Colours[index].B);

                bitmap.SetPixel(x, y, colour);
            }
        }

        return bitmap;
    }

    public void CreateFromBitmap(Bitmap bitmap, Pltt pltt, int offsetX, int offsetY, bool addOffsets)
    {
        if (bitmap == null || pltt == null)
        {
            throw new Exception("Cannot create DELT with null bitmap or null PLTT");
        }

        if (offsetX < 0 || offsetY < 0)
        {
            throw new Exception("Offsets cannot be negative.");
        }

        var width = addOffsets ? bitmap.Width + offsetX : bitmap.Width;
        var height = addOffsets ? bitmap.Height + offsetY : bitmap.Height;

        this.SizeX = (Int16)(width - 1);
        this.SizeY = (Int16)(height - 1);
        this.OffsetX = (Int16)offsetX;
        this.OffsetY = (Int16)offsetY;

        // Convert bitmap to Pixels
        var pixelsOffsetX = addOffsets ? offsetX : 0;
        var pixelsOffsetY = addOffsets ? offsetY : 0;
        this.Pixels = GetPixelsFromBitmap(bitmap, pltt, width, height, pixelsOffsetX, pixelsOffsetY);
    }

    public void SaveToFile(string fileName)
    {

    }

    private static IEnumerable<int> GetUncompressedLine(BinaryReader reader, int lineSize)
    {
        var lineData = reader.ReadBytes(lineSize);
        foreach (byte b in lineData)
        {
            yield return b;
        }
    }

    private static List<int> GetCompressedLine(BinaryReader reader, int lineSize)
    {
        var result = new List<int>();

        while (result.Count < lineSize)
        {
            // For the first byte of each line segment,
            // if bit 0 == 1 it is an RLE segment, otherwise it is direct values to copy
            // bits 1-7 give the count of pixels in the segment
            byte next = reader.ReadByte();
            var isRLE = (next & 0b_00000001) == 1;
            var count = next >> 1;

            if (!isRLE)  // direct values
            {
                for (int p = 0; p < count; p++)
                {
                    result.Add(reader.ReadByte());
                }
            }
            else    // repeating value
            {
                var repeatingColour = reader.ReadByte();

                for (int p = 0; p < count; p++)
                {
                    result.Add(repeatingColour);
                }
            }
        }

        return result;
    }

    /// <summary>
    /// Create the DELT image as an array of Pixels
    /// </summary>
    /// <param name="bitmap">Source bitmap</param>
    /// <param name="pltt">Source PLTT</param>
    /// <param name="width">Width of the DELT image (equals source bitmap width + offsetX)</param>
    /// <param name="height">Height of the DELT image (equals source bitmap height + offsetY)</param>
    /// <param name="offsetX"></param>
    /// <param name="offsetY"></param>
    /// <returns></returns>
    private static int[,] GetPixelsFromBitmap(Bitmap bitmap, Pltt pltt, int width, int height, int offsetX, int offsetY)
    {
        // Set all pixels to transparent initially
        var pixels = new int[width, height];
        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                pixels[x, y] = -1;
            }
        }

        for (int x = 0; x < bitmap.Width; x++)
        {
            for (int y = 0; y < bitmap.Height; y++)
            {
                var pixel = pltt.GetClosestMatch(bitmap.GetPixel(x, y));
                pixels[x + offsetX, y + offsetY] = pixel;
            }
        }
        
        return pixels;
    }
}